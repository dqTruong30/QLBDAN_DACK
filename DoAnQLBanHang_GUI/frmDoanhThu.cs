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

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            
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
            lblTrungBinhDon.Text = "0 VNĐ/đơn";
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

            // Thống kê tổng
            decimal tongDoanhThu = ds.Sum(h => h.TongTien ?? 0);
            int soHoaDon = ds.Count;
            decimal trungBinh = soHoaDon > 0 ? tongDoanhThu / soHoaDon : 0;

            lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
            lblSoHoaDon.Text = soHoaDon.ToString();
            lblTrungBinhDon.Text = trungBinh.ToString("N0") + " VNĐ/đơn";
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
        }
        private void loadNhanVien()
        {
            var dsNV = db.NHANVIENs.Select(nv => new { nv.MaNV, nv.TenNV }).ToList();
            cbbNhanVien.DataSource = dsNV;
            cbbNhanVien.DisplayMember = "TenNV";
            cbbNhanVien.ValueMember = "MaNV";
            cbbNhanVien.SelectedIndex = -1;
        }
    }
}
