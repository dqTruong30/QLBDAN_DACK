using DoAnQLBanHang_BUS;
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
    public partial class frmKhoHang : Form
    {
        private readonly KhoService khoService = new KhoService();
        private readonly QLBDANmodel db = new QLBDANmodel();
        public frmKhoHang()
        {
            InitializeComponent();
        }


        private void LoadComboBox()
        {
            try
            {
                using (var db = new QLBDANmodel())
                {
                    // 🔹 Lấy danh sách nhà cung cấp từ CSDL bằng Entity Framework
                    var dsNCC = db.NHACUNGCAPs
                        .Select(n => new
                        {
                            n.MaNCC,
                            n.TenNCC
                        })
                        .ToList();

                    // 🔹 Thêm lựa chọn "Tất cả nhà cung cấp" vào đầu danh sách
                    var allOption = new { MaNCC = 0, TenNCC = "— Tất cả nhà cung cấp —" };
                    var dataWithAll = new[] { allOption }.Concat(dsNCC).ToList();

                    // 🔹 Gán dữ liệu vào combobox
                    cbbNhaCungCap.DisplayMember = "TenNCC";
                    cbbNhaCungCap.ValueMember = "MaNCC";
                    cbbNhaCungCap.DataSource = dataWithAll;

                    // 🔹 Chọn mặc định dòng đầu tiên (“Tất cả…”)
                    cbbNhaCungCap.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDuLieuKhoHang()
        {
            try
            {
                var data = db.KHOes
                    .Include("NGUYENLIEU.NHACUNGCAP")
                    .AsEnumerable() // chuyển sang LINQ-to-Objects để dùng ?.
                    .Select(k => new
                    {
                        MaNL = k.MaNL,
                        TenNguyenLieu = k.NGUYENLIEU?.TenNL ?? "(Không có dữ liệu)",
                        SoLuongNhap = k.NGUYENLIEU?.DonViTinh ?? "",
                        GiaNhap = k.SoLuong ?? 0,
                        HanSuDung = k.HanSuDung.HasValue
                            ? k.HanSuDung.Value.ToString("dd/MM/yyyy")
                            : "N/A",
                        NhaCungCap = k.NGUYENLIEU?.NHACUNGCAP?.TenNCC ?? "(Chưa có NCC)"
                    })
                    .ToList();

                dgvKhoHang.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu kho: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadDuLieuKhoHang();
            SetPlaceholder(txtLocTheoMaTenSP, "Lọc theo Mã/Tên nguyên liệu.");
        }

        private void SetPlaceholder(TextBox txt, string text)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = text;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == text)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = text;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void btnThemSanPhamVaoKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNguyenLieu.Text) ||
                    string.IsNullOrWhiteSpace(txtTenNguyenLieu.Text) ||
                    string.IsNullOrWhiteSpace(txtSoLuongTon.Text) ||
                    string.IsNullOrWhiteSpace(txtDonViTinh.Text) ||
                    cbbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nguyên liệu!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNL = int.Parse(txtMaNguyenLieu.Text);
                decimal soLuong = decimal.Parse(txtSoLuongTon.Text);
                DateTime? hanSD = dtpHanSuDung.Checked ? dtpHanSuDung.Value : (DateTime?)null;

                string tenNguyenLieu = txtTenNguyenLieu.Text.Trim();
                string donViTinh = txtDonViTinh.Text.Trim();
                int? maNCC = Convert.ToInt32(cbbNhaCungCap.SelectedValue);

                khoService.ThemHoacCapNhatKho(maNL, soLuong, hanSD, tenNguyenLieu, donViTinh, maNCC);

                MessageBox.Show("✅ Cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 🔄 Reset form sau khi thêm thành công
                txtMaNguyenLieu.Clear();
                txtTenNguyenLieu.Clear();
                txtSoLuongTon.Clear();
                txtDonViTinh.Clear();
                cbbNhaCungCap.SelectedIndex = 0;
                dtpHanSuDung.Value = DateTime.Now;

                LoadDuLieuKhoHang();
            }
            catch (FormatException)
            {
                MessageBox.Show("Dữ liệu không hợp lệ! Vui lòng kiểm tra lại các ô nhập số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi thêm nguyên liệu vào kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtLocTheoMaTenSP.Text.Trim().ToLower();

                var data = db.KHOes
                    .Include("NGUYENLIEU.NHACUNGCAP")
                    .AsEnumerable() // chuyển sang LINQ-to-Objects để EF không cần dịch sang SQL
                    .Where(k =>
                        string.IsNullOrEmpty(tuKhoa) ||
                        (k.NGUYENLIEU?.TenNL?.ToLower().Contains(tuKhoa) ?? false) ||
                        k.MaNL.ToString().Contains(tuKhoa)
                    )
                    .Select(k => new
                    {
                        MaNL = k.MaNL,
                        TenNguyenLieu = k.NGUYENLIEU?.TenNL ?? "(Không có dữ liệu)",
                        DonViTinh = k.NGUYENLIEU?.DonViTinh ?? "",
                        SoLuongTon = k.SoLuong ?? 0,
                        HanSuDung = k.HanSuDung.HasValue
                            ? k.HanSuDung.Value.ToString("dd/MM/yyyy")
                            : "N/A",
                        NhaCungCap = k.NGUYENLIEU?.NHACUNGCAP?.TenNCC ?? "(Chưa có NCC)"
                    })
                    .ToList();

                dgvKhoHang.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBoLoc_Click(object sender, EventArgs e)
        {
            txtLocTheoMaTenSP.Clear();  // chỉ cần xóa ô tìm kiếm
            LoadDuLieuKhoHang();        // load lại toàn bộ kho
        }

        private void btnXoaNguyenLieu_Click(object sender, EventArgs e)
        {
            if (dgvKhoHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNL = (int)dgvKhoHang.SelectedRows[0].Cells["MaNL"].Value;

            if (MessageBox.Show("Bạn có chắc muốn xóa nguyên liệu này khỏi kho?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    khoService.XoaKho(maNL);
                    MessageBox.Show("✅ Xóa nguyên liệu khỏi kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDuLieuKhoHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi khi xóa nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNguyenLieu.Clear();
            txtTenNguyenLieu.Clear();
            txtDonViTinh.Clear();
            txtSoLuongTon.Clear();
            dtpHanSuDung.Value = DateTime.Now;
            cbbNhaCungCap.SelectedIndex = -1;

            LoadDuLieuKhoHang();
        }

        private void dgvKhoHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
