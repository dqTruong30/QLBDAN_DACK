using DoAnQLBanHang_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnQLBanHang_GUI
{
    public partial class frmHeThong : Form
    {

        private readonly QLBDANmodel qLBDA = new QLBDANmodel();
        private NHANVIEN currentUser;

        public frmHeThong(NHANVIEN user)
        {
            InitializeComponent();
            currentUser = user;
        }

        // (nếu bạn vẫn cần constructor rỗng)
        public frmHeThong()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadChildForm(Form childForm)
        {

            // Thiết lập form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào form hiện tại
            this.Controls.Add(childForm);
            childForm.Show();
        }

        private void frmHeThong_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            Form parentForm = this.ParentForm;
            if (parentForm is frmChucNang mainForm)
            {
                frmThemNV frmTNV = new frmThemNV();
                mainForm.LoadChildForm(frmTNV); // Gọi hàm có sẵn trong frmChucNang
            }
            /*
            using (var f = new frmThemNV())
            {
                f.ShowDialog();
            }*/
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            Form parentForm = this.ParentForm;
            if (parentForm is frmChucNang mainForm)
            {
                frmDoanhThu frmDT = new frmDoanhThu();
                mainForm.LoadChildForm(frmDT); // Gọi hàm có sẵn trong frmChucNang
            }
        }
    }
}
