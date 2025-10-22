using DoAnQLBanHang_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQLBanHang_GUI
{
    public partial class frmBanHang : Form
    {
        private readonly QLBDANmodel db = new QLBDANmodel();
        private readonly NHANVIEN currentUser;
        private int? foodLoaiId;
        private int? drinkLoaiId; // Explicitly treat MaLoai == 4 as drinks per requirement

        public frmBanHang(NHANVIEN user)
        {
            InitializeComponent();
            currentUser = user;

            // Wire events
            btn_food.Click += btn_food_Click;
            btn_drink.Click += btn_drink_Click;
            button_add_listview.Click += button_add_listview_Click;
            btn_deleteListview.Click += btn_deleteListview_Click;
            btn_inhoadon.Click += btn_inhoadon_Click;

            // Configure grid and list view
            dgvMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMon.MultiSelect = true;
            dgvMon.ReadOnly = true;

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Mã món", 80);
                listView1.Columns.Add("Tên món", 220);
                listView1.Columns.Add("Giá", 100);
                listView1.Columns.Add("Số lượng", 80);
                listView1.Columns.Add("Thành tiền", 120);
            }

            ResolveLoaiIds();
            LoadDataByLoaiId(null);
        }

        private void ResolveLoaiIds()
        {
            var loais = db.LOAIMONs.ToList();
            // Drinks fixed to MaLoai = 4
            drinkLoaiId = 4;
            // Food: pick any category that is not drink (!= 4) when pressing Food button we will explicitly exclude 4
            foodLoaiId = loais.FirstOrDefault(l => l.MaLoai != 4)?.MaLoai;
        }

        private void LoadDataByLoaiId(int? loaiId)
        {
            var query = db.MONANs.Where(m => m.TrangThai == true || m.TrangThai == null);
            if (loaiId.HasValue)
            {
                int id = loaiId.Value;
                query = query.Where(m => m.MaLoai == id);
            }

            var data = query
                .Select(m => new { m.MaMon, m.TenMon, m.DonGia })
                .ToList();
            dgvMon.DataSource = null;
            dgvMon.DataSource = data;
        }

        private void btn_food_Click(object sender, EventArgs e)
        {
            // Load all active items EXCEPT drinks (MaLoai != 4)
            ResolveLoaiIds();
            var data = db.MONANs
                .Where(m => (m.TrangThai == true || m.TrangThai == null) && m.MaLoai != (drinkLoaiId ?? 4))
                .Select(m => new { m.MaMon, m.TenMon, m.DonGia })
                .ToList();
            dgvMon.DataSource = null;
            dgvMon.DataSource = data;
        }

        private void btn_drink_Click(object sender, EventArgs e)
        {
            if (!drinkLoaiId.HasValue) ResolveLoaiIds();
            LoadDataByLoaiId(drinkLoaiId);
        }

        private void button_add_listview_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMon.SelectedRows)
            {
                if (row.DataBoundItem == null) continue;

                int maMon = (int)row.Cells["MaMon"].Value;
                string tenMon = row.Cells["TenMon"].Value?.ToString() ?? string.Empty;
                decimal gia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                // If item already exists in list, increase quantity
                var existing = listView1.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => i.SubItems[0].Text == maMon.ToString());
                if (existing != null)
                {
                    int soLuong = int.Parse(existing.SubItems[3].Text) + 1;
                    existing.SubItems[3].Text = soLuong.ToString();
                    existing.SubItems[4].Text = (soLuong * gia).ToString("N0");
                    continue;
                }

                var item = new ListViewItem(new[]
                {
                    maMon.ToString(),
                    tenMon,
                    gia.ToString("N0"),
                    "1",
                    gia.ToString("N0")
                });
                listView1.Items.Add(item);
            }
        }

        private void btn_deleteListview_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm món vào danh sách trước khi in hoá đơn.",
                    "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1) Create/Update customer if any info is provided (phone optional)
            KHACHHANG kh = null;
            string tenNhap = tb_name.Text?.Trim();
            string sdt = tb_sdt.Text?.Trim();
            string diaChiNhap = tb_diachi.Text?.Trim();
            bool coNhapThongTin =
                !string.IsNullOrWhiteSpace(tenNhap) ||
                !string.IsNullOrWhiteSpace(sdt) ||
                !string.IsNullOrWhiteSpace(diaChiNhap);

            if (coNhapThongTin)
            {
                if (!string.IsNullOrWhiteSpace(sdt))
                {
                    // Upsert theo số điện thoại nếu có
                    kh = db.KHACHHANGs.FirstOrDefault(x => x.SDT == sdt);
                }

                if (kh == null)
                {
                    kh = new KHACHHANG
                    {
                        TenKH = string.IsNullOrWhiteSpace(tenNhap) ? "Khách lẻ" : tenNhap,
                        SDT = sdt, // có thể null
                        DiaChi = diaChiNhap
                    };
                    db.KHACHHANGs.Add(kh);
                    db.SaveChanges();
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(tenNhap)) kh.TenKH = tenNhap;
                    if (!string.IsNullOrWhiteSpace(diaChiNhap)) kh.DiaChi = diaChiNhap;
                    db.SaveChanges();
                }
            }

            // 2) Create invoice
            decimal tong = 0;
            var hoaDon = new HOADON
            {
                MaKH = kh?.MaKH,
                MaNV = currentUser.MaNV,
                NgayLap = DateTime.Now,
                TrangThai = "Hoàn tất"
            };
            db.HOADONs.Add(hoaDon);
            db.SaveChanges();

            // 3) Add details
            foreach (ListViewItem item in listView1.Items)
            {
                int maMon = int.Parse(item.SubItems[0].Text);
                int soLuong = int.Parse(item.SubItems[3].Text);
                decimal donGia = decimal.Parse(item.SubItems[2].Text, System.Globalization.NumberStyles.AllowThousands);
                var ct = new CHITIETHOADON
                {
                    MaHD = hoaDon.MaHD,
                    MaMon = maMon,
                    SoLuong = soLuong,
                    DonGia = donGia
                };
                tong += donGia * soLuong;
                db.CHITIETHOADONs.Add(ct);
            }
            hoaDon.TongTien = tong;
            db.SaveChanges();
            var sb = new StringBuilder();
            sb.AppendLine("HOÁ ĐƠN");
            sb.AppendLine(new string('-', 40));
            sb.AppendLine($"Thời gian: {DateTime.Now:HH:mm:ss dd/MM/yyyy}");
            sb.AppendLine($"Thu ngân: {currentUser?.TenNV}");
            if (!string.IsNullOrWhiteSpace(tb_name.Text) || !string.IsNullOrWhiteSpace(tb_sdt.Text) || !string.IsNullOrWhiteSpace(tb_diachi.Text))
            {
                sb.AppendLine(new string('-', 40));
                sb.AppendLine($"Khách hàng: {tb_name.Text}");
                sb.AppendLine($"SĐT: {tb_sdt.Text}");
                sb.AppendLine($"Địa chỉ: {tb_diachi.Text}");
            }
            sb.AppendLine(new string('-', 40));
            foreach (ListViewItem item in listView1.Items)
            {
                string tenMon = item.SubItems[1].Text;
                decimal gia = decimal.Parse(item.SubItems[2].Text, System.Globalization.NumberStyles.AllowThousands);
                int soLuong = int.Parse(item.SubItems[3].Text);
                decimal thanhTien = gia * soLuong;
                tong += thanhTien;
                sb.AppendLine($"{tenMon} x{soLuong} - {thanhTien:N0}");
            }
            sb.AppendLine(new string('-', 40));
            sb.AppendLine($"Tổng: {tong:N0}");
            // Always show preview dialog (no save)
            MessageBox.Show(sb.ToString(), "Xem hoá đơn");

            // After preview, clear customer info fields
            tb_name.Text = string.Empty;
            tb_sdt.Text = string.Empty;
            tb_diachi.Text = string.Empty;
            listView1.Items.Clear();
        }

        private void btn_food_Click_1(object sender, EventArgs e)
        {

        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {

        }

        private void btn_deleteListview_Click_1(object sender, EventArgs e)
        {

        }
    }
}
