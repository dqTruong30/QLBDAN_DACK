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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = db.NHANVIENs
                             .FirstOrDefault(u => u.TenDangNhap == username && u.MatKhau == password);

                if (user != null)
                {
                    this.Hide();

                    // Sử dụng using để đảm bảo dispose form con
                    using (frmChucNang mainForm = new frmChucNang(user))
                    {
                        mainForm.ShowDialog();
                    }

                    // Khi frmChucNang đóng (người dùng đăng xuất hoặc đóng), hiện lại frmDangNhap
                    this.Show();

                    // (Tùy chọn) Xóa mật khẩu/clear các ô để bảo mật
                    txtMatKhau.Clear();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
