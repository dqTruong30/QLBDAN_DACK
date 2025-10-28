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

        private readonly QLBDANmodel db = new QLBDANmodel();
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
                lblHoTen.Font = new Font(lblHoTen.Font, FontStyle.Bold);
                lblHoTen.Font = new Font(lblHoTen.Font.FontFamily, 14, FontStyle.Bold);

                lblChucVu.Text = CurrentUser.VaiTro;
                lblChucVu.Font = new Font(lblChucVu.Font.FontFamily, 14, FontStyle.Bold);
            }
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);


                decimal tongDoanhThu = db.HOADONs
              .Sum(hd => (decimal?)hd.TongTien) ?? 0;
                /*
                // Doanh thu tháng
                decimal doanhThuThang = db.HOADONs
                    .Where(hd => hd.NgayLap >= startOfMonth && hd.NgayLap <= today)
                    .Sum(hd => (decimal?)hd.TongTien) ?? 0;*/

                lblDoanhThuThang.Text = $"{tongDoanhThu:N0} VND";

                // Tổng nhân viên
                int tongNV = db.NHANVIENs.Count();
                lblTongNhanVien.Text = tongNV.ToString();

                // === Doanh thu hôm nay ===
                decimal doanhThuHomNay = db.HOADONs
                    .Where(hd => hd.NgayLap.HasValue &&
                                 System.Data.Entity.DbFunctions.TruncateTime(hd.NgayLap.Value) == today)
                    .Sum(hd => (decimal?)hd.TongTien) ?? 0;

                // === Doanh thu tuần (từ đầu tuần đến hôm nay) ===
                decimal doanhThuTuan = db.HOADONs
                    .Where(hd => hd.NgayLap.HasValue &&
                                 System.Data.Entity.DbFunctions.TruncateTime(hd.NgayLap.Value) >= startOfWeek &&
                                 System.Data.Entity.DbFunctions.TruncateTime(hd.NgayLap.Value) <= today)
                    .Sum(hd => (decimal?)hd.TongTien) ?? 0;

                // === Doanh thu tháng (từ đầu tháng đến hôm nay) ===
                decimal doanhThuThang = db.HOADONs
                    .Where(hd => hd.NgayLap.HasValue &&
                                 System.Data.Entity.DbFunctions.TruncateTime(hd.NgayLap.Value) >= startOfMonth &&
                                 System.Data.Entity.DbFunctions.TruncateTime(hd.NgayLap.Value) <= today)
                    .Sum(hd => (decimal?)hd.TongTien) ?? 0;

                // === Số lượng hóa đơn hôm nay ===
                int tongHoaDonHomNay = db.HOADONs
            .Count(hd => hd.NgayLap.HasValue &&
                         System.Data.Entity.DbFunctions.TruncateTime(hd.NgayLap.Value) == today);
                lblHoaDonHomNay.Text = $"{tongHoaDonHomNay:N0}";
                // === Hiển thị lên label ===
               

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}");
            }
        }

        private void lblDoanhThuThang_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblHoaDonHomNay_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
