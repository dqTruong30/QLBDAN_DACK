using DoAnQLBanHang_BUS;
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
    public partial class frmKhoHang : Form
    {
        private readonly KhoService khoService = new KhoService();
        public frmKhoHang()
        {
            InitializeComponent();
        }


        private void LoadDuLieuKhoHang()
        {
            try
            {
                // 1. Lấy dữ liệu từ Service (BLL)
                var listTonKho = khoService.GetAllTonKho();

                // 2. Chọn lọc và định dạng dữ liệu để hiển thị (Anonymous Type)
                var dataToShow = listTonKho.Select(k => new
                {
                    MaNL = k.MaNL,
                    TenNguyenLieu = k.NGUYENLIEU.TenNL,
                    DonViTinh = k.NGUYENLIEU.DonViTinh,
                    SoLuongTon = k.SoLuong,
                    // Định dạng và kiểm tra HanSuDung (có thể NULL)
                    HanSuDung = k.HanSuDung.HasValue ? k.HanSuDung.Value.ToString("dd/MM/yyyy") : "N/A",
                    NhaCungCap = k.NGUYENLIEU.NHACUNGCAP.TenNCC
                }).ToList();

                // 3. Gán vào DataGridView
                dgvKhoHang.DataSource = dataToShow;

                // 4. Tùy chỉnh tiêu đề cột 
                dgvKhoHang.Columns["MaNL"].HeaderText = "Mã NL";
                dgvKhoHang.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
                // ... (tương tự cho các cột khác nếu cần)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Kho hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKhoHang_Load(object sender, EventArgs e)
        {
            LoadDuLieuKhoHang();
        }
    }
}
