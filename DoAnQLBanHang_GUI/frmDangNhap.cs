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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DoAnQLBanHang_GUI
{
    public partial class frmDangNhap : Form
    {
        private readonly QLBDANmodel db = new QLBDANmodel();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
        }



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // 1️⃣ Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2️⃣ Tìm nhân viên theo tài khoản và mật khẩu (dùng Entity Framework)
                var user = db.NHANVIENs
                             .FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);

                // 3️⃣ Kiểm tra kết quả
                if (user != null)
                {
                    MessageBox.Show("Đăng nhập thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ẩn form đăng nhập, mở form chức năng chính
                    this.Hide();
                    frmChucNang mainForm = new frmChucNang(user); // truyền thông tin người dùng
                    mainForm.ShowDialog();

                    // Khi form chính đóng, thoát hẳn ứng dụng
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi đăng nhập: " + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
