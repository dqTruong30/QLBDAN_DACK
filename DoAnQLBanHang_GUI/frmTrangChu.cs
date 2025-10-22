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
    public partial class frmTrangChu : Form
    {
        public NHANVIEN CurrentUser { get; set; }
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            if (CurrentUser != null)
            {
                lblHoTen.Text = CurrentUser.TenNV;
                lblChucVu.Text = CurrentUser.VaiTro;
            }
        }

    }
}
