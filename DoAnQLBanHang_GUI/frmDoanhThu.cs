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
using System.Data.Entity;

namespace DoAnQLBanHang_GUI
{
    public partial class frmDoanhThu : Form
    {
        private readonly QLBDANmodel db = new QLBDANmodel();

        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            loadNhanVien();

            cbbLoaiThongKe.Items.AddRange(new string[] { "Tất cả", "Theo ngày", "Theo tháng", "Theo năm" });
            cbbLoaiThongKe.SelectedIndex = 0;

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;

            // Đổi nhãn label trung bình thành “Số đơn hàng/ngày”
            lblTrungBinhDon.Text = "0 đơn/ngày";
        }

        private void loadNhanVien()
        {
            var dsNV = db.NHANVIENs.Select(nv => new { nv.MaNV, nv.TenNV }).ToList();
            cbbNhanVien.DataSource = dsNV;
            cbbNhanVien.DisplayMember = "TenNV";
            cbbNhanVien.ValueMember = "MaNV";
            cbbNhanVien.SelectedIndex = -1;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);

            string maNVStr = cbbNhanVien.SelectedValue?.ToString();
            string loaiThongKe = cbbLoaiThongKe.Text;

            var query = db.HOADONs
                .Include(h => h.NHANVIEN)
                .Where(h => h.NgayLap >= tuNgay && h.NgayLap < denNgay);

            if (!string.IsNullOrEmpty(maNVStr))
            {
                int maNV = int.Parse(maNVStr);
                query = query.Where(h => h.MaNV == maNV);
            }

            var ds = query
                .Select(h => new
                {
                    h.MaHD,
                    h.NgayLap,
                    TenNhanVien = h.NHANVIEN.TenNV,
                    h.TongTien
                })
                .OrderByDescending(h => h.NgayLap)
                .ToList();

            dgvChiTietDoanhThu.DataSource = ds;

            // === TÍNH TOÁN ===
            decimal tongDoanhThu = ds.Sum(h => h.TongTien ?? 0);
            int soHoaDon = ds.Count;
            double soNgay = (denNgay - tuNgay).TotalDays;
            double donHangMoiNgay = soNgay > 0 ? soHoaDon / soNgay : 0;

            // === HIỂN THỊ ===
            lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            lblSoHoaDon.Text = soHoaDon.ToString();
            lblTrungBinhDon.Text = donHangMoiNgay.ToString("0.##") + " đơn/ngày";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;
            cbbLoaiThongKe.SelectedIndex = 0;
            cbbNhanVien.SelectedIndex = -1;
            dgvChiTietDoanhThu.DataSource = null;

            lblTongDoanhThu.Text = "0 VNĐ";
            lblSoHoaDon.Text = "0";
            lblTrungBinhDon.Text = "0 đơn/ngày";
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            Form parentForm = this.ParentForm;

            if (parentForm is frmChucNang mainForm)
            {
                // Quay lại form frmHeThong trong frmChucNang
                frmHeThong frmHT = new frmHeThong();
                mainForm.LoadChildForm(frmHT);
            }
            else
            {
                // Trường hợp không có form cha (chạy độc lập)
                this.Close();
            }

        }

        private void lblTrungBinhDon_Click(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
