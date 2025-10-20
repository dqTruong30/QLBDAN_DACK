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
    public partial class frmKhachHang : Form
    {
        private readonly QLBDANmodel db = new QLBDANmodel();

        public frmKhachHang()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            
            if (listView1.Columns.Count == 0)
            {
                listView1.Columns.Add("Tên", 160);
                listView1.Columns.Add("SĐT", 100);
            }
            if (listView2.Columns.Count == 0)
            {
                listView2.Columns.Add("Ngày", 140);
                listView2.Columns.Add("Món", 220);
                listView2.Columns.Add("SL", 50);
                listView2.Columns.Add("Thành tiền", 120);
            }
            LoadCustomers(null);
        }

        private void LoadCustomers(string phone)
        {
            listView1.Items.Clear();
            var query = db.KHACHHANGs
                .Where(k => k.HOADONs.Any()) // chỉ khách có hoá đơn
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                query = query.Where(k => k.SDT.Contains(phone));
            }
            foreach (var kh in query.OrderBy(k => k.TenKH).Select(k => new { k.MaKH, k.TenKH, k.SDT }).ToList())
            {
                var item = new ListViewItem(new[] { kh.TenKH ?? string.Empty, kh.SDT ?? string.Empty });
                item.Tag = kh.MaKH;
                listView1.Items.Add(item);
            }
        }

        private void btn_search_info_khachhang_Click(object sender, EventArgs e)
        {
            LoadCustomers(tb_search_telephone.Text.Trim());
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var selected = listView1.SelectedItems[0];
            if (selected.Tag == null) return;
            int maKh = (int)selected.Tag;
            var kh = db.KHACHHANGs.FirstOrDefault(k => k.MaKH == maKh);
            if (kh == null) return;

            tb_tenkhachhang.Text = kh.TenKH;
            tb_sodienthoai.Text = kh.SDT;
            tb_diachi.Text = kh.DiaChi;

            // Load purchase history into listView2
            listView2.Items.Clear();
            var lichSu = db.HOADONs
                .Where(h => h.MaKH == maKh)
                .OrderByDescending(h => h.NgayLap)
                .SelectMany(h => h.CHITIETHOADONs.Select(ct => new
                {
                    Ngay = h.NgayLap,
                    Mon = ct.MONAN.TenMon,
                    SL = ct.SoLuong,
                    ThanhTien = (ct.ThanhTien ?? (ct.DonGia * ct.SoLuong))
                }))
                .ToList();

            foreach (var r in lichSu)
            {
                var item = new ListViewItem(new[]
                {
                    (r.Ngay?.ToString("dd/MM/yyyy HH:mm") ?? string.Empty),
                    r.Mon ?? string.Empty,
                    r.SL.ToString(),
                    r.ThanhTien.ToString("N0")
                });
                listView2.Items.Add(item);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = listView1.SelectedItems[0];
            int maKh = (int)selected.Tag;

            var kh = db.KHACHHANGs.FirstOrDefault(k => k.MaKH == maKh);
            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận trước khi xóa
            if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng '{kh.TenKH}' không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Xóa tất cả hóa đơn liên quan (nếu có)
                    var hoaDons = db.HOADONs.Where(h => h.MaKH == maKh).ToList();
                    foreach (var hd in hoaDons)
                    {
                        // Xóa chi tiết hóa đơn trước
                        var chiTiet = db.CHITIETHOADONs.Where(ct => ct.MaHD == hd.MaHD).ToList();
                        db.CHITIETHOADONs.RemoveRange(chiTiet);

                        // Sau đó xóa hóa đơn
                        db.HOADONs.Remove(hd);
                    }

                    // Cuối cùng xóa khách hàng
                    db.KHACHHANGs.Remove(kh);
                    db.SaveChanges();

                    // Xóa dòng trong ListView
                    listView1.Items.Remove(selected);
                    listView2.Items.Clear();

                    tb_tenkhachhang.Text = "";
                    tb_sodienthoai.Text = "";
                    tb_diachi.Text = "";

                    MessageBox.Show("Đã xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}