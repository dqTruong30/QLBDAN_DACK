using DoAnQLBanHang_DAL.Entities; // nếu chưa có, thêm namespace này để dùng QLBDANmodel
using System;
using System.Linq;
using System.Windows.Forms;

namespace DoAnQLBanHang_GUI
{
    public partial class frmSuMk : Form
    {
        private int maNV; // Mã nhân viên cần đổi mật khẩu
        private readonly QLBDANmodel db = new QLBDANmodel();

        public frmSuMk(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void frmSuMk_Load(object sender, EventArgs e)
        {
            var nv = db.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string newPassword = tb_newPasswork.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mật khẩu mới!", "Thông báo");
                return;
            }

            var nv = db.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
            if (nv != null)
            {
                nv.MatKhau = newPassword; // Có thể mã hóa MD5 nếu cần
                db.SaveChanges();

                MessageBox.Show("✅ Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ Không tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = tb_newPasswork.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("⚠️ Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tìm nhân viên theo mã
                var nv = db.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                if (nv == null)
                {
                    MessageBox.Show("❌ Không tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật mật khẩu mới
                nv.MatKhau = newPassword;  // Có thể mã hóa bằng MD5 hoặc SHA256 nếu cần
                db.SaveChanges();

                MessageBox.Show("✅ Mật khẩu đã được thay đổi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form sau khi đổi xong
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi cập nhật mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
