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
    public partial class frmHoaDon : Form
    {
        private readonly QLBDANmodel db = new QLBDANmodel();

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
             LoadHoaDon();
        }
        private void LoadHoaDon()
        {
            var list = db.HOADONs
                .Select(hd => new
                {
                    hd.MaHD,
                    hd.NgayLap,
                    SDT = hd.KHACHHANG.SDT,
                    TenKH = hd.KHACHHANG.TenKH,
                    TrangThai = hd.TrangThai
                })
                .OrderByDescending(x => x.NgayLap)
                .ToList();

            // thêm STT
            var listWithSTT = list.Select((x, i) => new
            {
                STT = i + 1,
                x.MaHD,
                x.NgayLap,
                x.SDT,
                x.TenKH,
                x.TrangThai
            }).ToList();

            dgvHoaDon.DataSource = listWithSTT;

            // cấu hình chung
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.ReadOnly = true;
            dgvChiTietHoaDon.DataSource = null;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1);
            string sdt = txtSDT.Text.Trim();

            var query = db.HOADONs.AsQueryable();

            query = query.Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap < denNgay);

            if (!string.IsNullOrEmpty(sdt))
                query = query.Where(hd => hd.KHACHHANG.SDT.Contains(sdt));

            var list = query
                .Select(hd => new
                {
                    hd.MaHD,
                    hd.NgayLap,
                    SDT = hd.KHACHHANG.SDT,
                    TenKH = hd.KHACHHANG.TenKH,
                    TrangThai = hd.TrangThai
                })
                .OrderByDescending(x => x.NgayLap)
                .ToList();

            var listWithSTT = list.Select((x, i) => new
            {
                STT = i + 1,
                x.MaHD,
                x.NgayLap,
                x.SDT,
                x.TenKH,
                x.TrangThai
            }).ToList();

            dgvHoaDon.DataSource = listWithSTT;
            dgvChiTietHoaDon.DataSource = null;
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maHD = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

            var chiTiet = db.CHITIETHOADONs
                .Where(ct => ct.MaHD.ToString() == maHD)
                .Select(ct => new
                {
                    TenSanPham = ct.MONAN.TenMon,
                    SoLuong = ct.SoLuong,
                    Gia = ct.DonGia,
                    ThanhTien = ct.SoLuong * ct.DonGia
                })
                .ToList();

            dgvChiTietHoaDon.DataSource = chiTiet;
        }
    }
}
