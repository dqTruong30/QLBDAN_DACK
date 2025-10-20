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
    public partial class frmChucNang : Form
    {
        private NHANVIEN currentUser;
        private readonly QLBDANmodel db = new QLBDANmodel();
        public frmChucNang()
        {
            InitializeComponent();
			btnBanHang.Click += btnBanHang_Click;
			btnKhachHang.Click += btnKhachHang_Click;
        }


        public frmChucNang(NHANVIEN user)
        {
            InitializeComponent();
			btnBanHang.Click += btnBanHang_Click;
			btnKhachHang.Click += btnKhachHang_Click;
            currentUser = user;
            if (currentUser.VaiTro != null && currentUser.VaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                lblWelcome.Text = $"Admin: {currentUser.TenNV}";
            }
            else
            {
                lblWelcome.Text = $"Nhân viên: {currentUser.TenNV}";
            }

            PhanQuyen();

            ThongTinNguoiDung();
        }


        private void ThongTinNguoiDung()
        {
            if (currentUser != null)
            {
                string vaiTro = currentUser.VaiTro?.Trim();

                if (!string.IsNullOrEmpty(vaiTro) && vaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    lblWelcome.Text = $"Admin: {currentUser.TenNV}";
                }
                else
                {
                    lblWelcome.Text = $"Nhân viên: {currentUser.TenNV}";
                }
            }
        }

        private void PhanQuyen()
        {
            if (currentUser == null) return;

            // Lấy lại dữ liệu vai trò mới nhất (phòng trường hợp dữ liệu thay đổi)
            var nv = db.NHANVIENs.FirstOrDefault(n => n.MaNV == currentUser.MaNV);
            string role = nv?.VaiTro?.Trim();

            if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnBanHang.Enabled = true;
                btnKhachHang.Enabled = true;
                btnHoaDon.Enabled = true;
                btnSanPham.Enabled = true;
                btnKhoHang.Enabled = true;
                btnHeThong.Enabled = true;
            }
            else
            {
                btnBanHang.Enabled = true;
                btnKhachHang.Enabled = true;
                btnHoaDon.Enabled = true;
                btnSanPham.Enabled = false;
                btnKhoHang.Enabled = false;
                btnHeThong.Enabled = false;
            }
        }

        private void LoadChildForm(Form childForm)
        {
            // 1. Xóa tất cả các controls cũ trong panel
            this.pnlNoiDung.Controls.Clear();

            // 2. Thiết lập thuộc tính cho Form con
            childForm.TopLevel = false; // Báo hiệu đây là Form con, không phải cửa sổ độc lập
            childForm.FormBorderStyle = FormBorderStyle.None; // Xóa viền Form con
            childForm.Dock = DockStyle.Fill; // Fill đầy Panel

            // 3. Thêm Form con vào Panel và hiển thị
            this.pnlNoiDung.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            frmKhoHang fKho = new frmKhoHang();
            LoadChildForm(fKho);
        }

		private void btnBanHang_Click(object sender, EventArgs e)
		{
			var f = new frmBanHang(currentUser);
			LoadChildForm(f);
		}

		private void btnKhachHang_Click(object sender, EventArgs e)
		{
			var f = new frmKhachHang();
			LoadChildForm(f);
		}

    }
}
