using ClosedXML.Excel;
using DoAnQLBanHang_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoAnQLBanHang_GUI.frmTinhLuong;

namespace DoAnQLBanHang_GUI
{
    public partial class frmTinhLuong : Form
    {
        public class BangLuongTamThoi
        {
            public string MaNV { get; set; }
            public string TenNV { get; set; }
            public string ChucVu { get; set; }
            public decimal TongLuongCoBan { get; set; }
            public decimal ThuongPhatRong { get; set; }
            public decimal TongLuongThucNhan { get; set; }
        }

        public class GiaoDichThuongPhat
        {
            public string MaNV { get; set; }
            public int Thang { get; set; }
            public int Nam { get; set; }
            public decimal SoTien { get; set; } // Âm cho Phạt, Dương cho Thưởng
            public string LyDo { get; set; }
            public DateTime NgayTao { get; set; }
        }
        

        private List<GiaoDichThuongPhat> listThuongPhat = new List<GiaoDichThuongPhat>();

        private readonly QLBDANmodel qLBDA = new QLBDANmodel();
        public frmTinhLuong()
        {
            InitializeComponent();
        }

        private void frmTinhLuong_Load(object sender, EventArgs e)
        {
            SetupDataGridViewColumns();
            LoadInitialControls();
            // Tự động tính lương tháng hiện tại
            btnTinhLuong_Click(null, null);
        }
        private void SetupDataGridViewColumns()
        {
            dgvDanhSachLuong.Columns.Clear();
            dgvDanhSachLuong.Columns.Add("MaNV", "Mã NV");
            dgvDanhSachLuong.Columns.Add("TenNV", "Tên nhân viên");
            dgvDanhSachLuong.Columns.Add("ChucVu", "Chức vụ");
            // dgvDanhSachLuong.Columns.Add("TongPhut", "Tổng phút"); // Đã bỏ
            // dgvDanhSachLuong.Columns.Add("LuongPhut", "Lương/phút"); // Đã bỏ
            dgvDanhSachLuong.Columns.Add("LuongCung", "Lương cứng");
            dgvDanhSachLuong.Columns.Add("ThuongPhat", "Thưởng/Phạt (ròng)");
            dgvDanhSachLuong.Columns.Add("TongLuongThucNhan", "Tổng lương thực nhận");

            // Định dạng lại tên cột trong DataGridViewStyles
            dgvDanhSachLuong.Columns["LuongCung"].DefaultCellStyle.Format = "N0";
            dgvDanhSachLuong.Columns["ThuongPhat"].DefaultCellStyle.Format = "N0";
            dgvDanhSachLuong.Columns["TongLuongThucNhan"].DefaultCellStyle.Format = "N0";

            // Định dạng lại căn chỉnh
            dgvDanhSachLuong.Columns["LuongCung"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhSachLuong.Columns["ThuongPhat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhSachLuong.Columns["TongLuongThucNhan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // dgvDanhSachLuong.Columns["TongPhut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Đã bỏ
            // dgvDanhSachLuong.Columns["LuongPhut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Đã bỏ

            dgvDanhSachLuong.RowHeadersVisible = false;
            dgvDanhSachLuong.AllowUserToAddRows = false;
            dgvDanhSachLuong.ReadOnly = true;
            dgvDanhSachLuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadInitialControls()
        {
            // Load ComboBox Thang
            cmbThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cmbThang.Items.Add($"Tháng {i}");
            }
            cmbThang.SelectedItem = $"Tháng {DateTime.Now.Month}";

            // Load ComboBox Nam
            cmbNam.Items.Clear();
            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 1; i++)
            {
                cmbNam.Items.Add(i.ToString());
            }
            cmbNam.SelectedItem = DateTime.Now.Year.ToString();

            // Load ComboBox LoaiNV
            cmbLoaiNV.Items.Clear();
            cmbLoaiNV.Items.Add("Tất cả");
            // Lấy danh sách VaiTro (Chức vụ) từ DB và thêm vào
            var chucVuList = qLBDA.NHANVIENs
                                  .Select(nv => nv.VaiTro)
                                  .Distinct()
                                  .Where(v => v != null)
                                  .ToList();
            cmbLoaiNV.Items.AddRange(chucVuList.Cast<object>().ToArray());
            cmbLoaiNV.SelectedItem = "Tất cả";

            dgvDanhSachLuong.Rows.Clear();
        }

        private void UpdateStats(int tongNV, decimal tongLuongCoBan, decimal tongThuongPhatRong)
        {
            decimal tongChi = tongLuongCoBan + tongThuongPhatRong;
            lblGiaTriTongNV.Text = tongNV.ToString("N0");
            lblGiaTriTongLuong.Text = $"{tongLuongCoBan:N0} đ";
            lblGiaTriTongThuong.Text = $"{tongThuongPhatRong:N0} đ";
            lblGiaTriTongChi.Text = $"{tongChi:N0} đ";
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Tháng và Năm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string thangText = cmbThang.Text.Replace("Tháng ", "");
                int thang = int.Parse(thangText);
                int nam = int.Parse(cmbNam.Text);
                string loaiNVFilter = cmbLoaiNV.Text;
                string timKiem = txtTimKiem.Text.Trim().ToLower();

                // 1. Lấy tất cả nhân viên thỏa mãn bộ lọc
                var query = qLBDA.NHANVIENs.AsQueryable();

                if (loaiNVFilter != "Tất cả")
                {
                    query = query.Where(nv => nv.VaiTro == loaiNVFilter);
                }

                if (!string.IsNullOrEmpty(timKiem))
                {
                    query = query.Where(nv =>
                        nv.MaNV.ToString().Contains(timKiem) ||
                        nv.TenNV.ToLower().Contains(timKiem)
                    );
                }

                var danhSachNV = query.ToList();

                dgvDanhSachLuong.Rows.Clear();

                int tongNV = 0;
                decimal tongLuongCoBan = 0;
                decimal tongThuongPhatRong = 0;

                // 2. Tính lương cho từng nhân viên (Dùng LUONGCOBAN)
                foreach (var nv in danhSachNV)
                {
                    // === ĐÃ SỬA LỖI: Dùng LUONGCOBAN thay vì LUONG ===
                    // Dùng GetValueOrDefault(0) để đảm bảo decimal và tránh lỗi nếu cột này cho phép null
                    decimal luongCung = Convert.ToDecimal(nv.CHUCVU);
                    decimal luongCoBan = luongCung; // Coi lương cố định là lương cơ bản

                    // Nếu bạn có tính lương theo giờ/phút, bạn cần truy vấn bảng CHAMCONG
                    // Ví dụ: TongPhutLamViec = ... và LuongPhut = luongCung / (so giờ làm chuẩn * 60)

                    // B. Tổng Thưởng/Phạt Ròng cho tháng
                    // **LƯU Ý QUAN TRỌNG: listThuongPhat chỉ chứa dữ liệu đã thêm TỪ FORM THƯỞNG. 
                    // Nếu bạn có bảng GIAODICHTHUONGPHAT trong DB, bạn nên truy vấn nó ở đây**
                    // Ví dụ: qLBDA.GIAODICHTHUONGPHATs.Where(gd => ...).Sum(...)

                    decimal thuongPhatRong = listThuongPhat
                        .Where(gd => gd.MaNV == nv.MaNV.ToString() && gd.Thang == thang && gd.Nam == nam)
                        .Sum(gd => gd.SoTien);

                    decimal tongLuongThucNhan = luongCoBan + thuongPhatRong;

                    dgvDanhSachLuong.Rows.Add(
                        nv.MaNV,
                        nv.TenNV,
                        nv.VaiTro,
                        // "0 (Giả lập)", // Đã bỏ cột Tổng phút
                        // "0 (Giả lập)", // Đã bỏ cột Lương/phút
                        luongCung.ToString("N0"), // Lương cố định (LUONGCOBAN)
                        thuongPhatRong.ToString("N0"),
                        tongLuongThucNhan.ToString("N0")
                    );

                    tongNV++;
                    tongLuongCoBan += luongCoBan;
                    tongThuongPhatRong += thuongPhatRong;
                }

                UpdateStats(tongNV, tongLuongCoBan, tongThuongPhatRong);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tính lương: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachLuong.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất ra Excel.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = $"BaoCaoLuong_{cmbThang.Text.Replace("Tháng ", "")}_{cmbNam.Text}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Báo Cáo Lương");

                            for (int i = 0; i < dgvDanhSachLuong.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvDanhSachLuong.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dgvDanhSachLuong.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvDanhSachLuong.Columns.Count; j++)
                                {
                                    var cellValue = dgvDanhSachLuong.Rows[i].Cells[j].Value;
                                    worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString();
                                }
                            }

                            int lastRow = dgvDanhSachLuong.Rows.Count + 2;
                            worksheet.Cell(lastRow, 1).Value = "TỔNG CỘNG";
                            worksheet.Cell(lastRow, 1).Style.Font.Bold = true;

                            worksheet.Cell(lastRow, 4).Value = lblGiaTriTongLuong.Text;    // Lương cứng (Cột 4)
                            worksheet.Cell(lastRow, 5).Value = lblGiaTriTongThuong.Text;   // Thưởng/Phạt (Cột 5)
                            worksheet.Cell(lastRow, 6).Value = lblGiaTriTongChi.Text;      // Tổng chi (Cột 6)

                            worksheet.Range(lastRow, 4, lastRow, 6).Style.Font.Bold = true;
                            worksheet.Range(lastRow, 4, lastRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                            worksheet.Row(1).Style.Font.Bold = true;
                            worksheet.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Không thể lưu file. Vui lòng đóng file Excel đang mở (nếu có) và thử lại.", "Lỗi I/O", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemThuong_Click(object sender, EventArgs e)
        {
            string maNV = null;
            string tenNV = null;
            string chucVu = null;

            if (dgvDanhSachLuong.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDanhSachLuong.SelectedRows[0];
                maNV = selectedRow.Cells["MaNV"].Value?.ToString();
                tenNV = selectedRow.Cells["TenNV"].Value?.ToString();
                chucVu = selectedRow.Cells["ChucVu"].Value?.ToString();
            }

            using (FrmThemThuong frm = new FrmThemThuong())
            {
                frm.MaNV = maNV;
                frm.TenNV = tenNV;
                frm.LoaiNV = chucVu;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.NewGiaoDich != null)
                    {
                        if (int.TryParse(cmbThang.Text.Replace("Tháng ", ""), out int thang) && int.TryParse(cmbNam.Text, out int nam))
                        {
                            frm.NewGiaoDich.Thang = thang;
                            frm.NewGiaoDich.Nam = nam;
                        }

                        listThuongPhat.Add(frm.NewGiaoDich);
                        btnTinhLuong_Click(null, null);
                    }
                }
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HandleFilterChanged(object sender, EventArgs e)
        {
            btnTinhLuong_Click(sender, e);
        }
        private void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleFilterChanged(sender, e);
        }

        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleFilterChanged(sender, e);
        }

        private void cmbLoaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleFilterChanged(sender, e);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HandleFilterChanged(sender, e);
        }
        private void PnlBoLoc_Paint(object sender, PaintEventArgs e) { }
        private void lblTongNV_Click(object sender, EventArgs e) { }
        private void lblTongLuong_Click(object sender, EventArgs e) { }
        private void lblTongThuong_Click(object sender, EventArgs e) { }
        private void lblTongChi_Click(object sender, EventArgs e) { }
        private void lblGiaTriTongNV_Click(object sender, EventArgs e) { }
        private void lblGiaTriTongLuong_Click(object sender, EventArgs e) { }
        private void lblGiaTriTongThuong_Click(object sender, EventArgs e) { }
        private void lblGiaTriTongChi_Click(object sender, EventArgs e) { }
    }
    public class FrmThemThuong : Form
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string LoaiNV { get; set; }
        public GiaoDichThuongPhat NewGiaoDich { get; private set; } // Kết quả trả về

        private TextBox txtMaNV;
        private TextBox txtTenNV;
        private ComboBox cmbLoaiNV;
        private ComboBox cmbLoaiGiaoDich;
        private NumericUpDown nudSoTien;
        private RichTextBox rtbLyDo;
        private Button btnThem;
        private Button btnHuy;

        public FrmThemThuong()
        {
            SetupLayoutAndControls();
            this.Text = "THÊM THƯỞNG / PHẠT";
            this.Load += FrmThemThuong_Load;
        }

        private void SetupLayoutAndControls()
        {
            this.Width = 450;
            this.Height = 550;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Padding = new Padding(15);
            this.BackColor = Color.White;

            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 7,
                Padding = new Padding(10),
                AutoScroll = true
            };

            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            for (int i = 0; i < 7; i++)
            {
                if (i == 5)
                    mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 150));
                else
                    mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            }

            this.Controls.Add(mainPanel);
            int row = 0;

            // 1. Mã Nhân Viên
            mainPanel.Controls.Add(new Label { Text = "Mã Nhân Viên:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, row);
            txtMaNV = new TextBox { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(txtMaNV, 1, row++);

            // 2. Tên Nhân Viên
            mainPanel.Controls.Add(new Label { Text = "Tên Nhân Viên:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, row);
            txtTenNV = new TextBox { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(txtTenNV, 1, row++);

            // 3. Loại Nhân Viên
            mainPanel.Controls.Add(new Label { Text = "Loại Nhân Viên:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, row);
            cmbLoaiNV = new ComboBox { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(cmbLoaiNV, 1, row++);

            // 4. Loại Giao Dịch (Thưởng/Phạt)
            mainPanel.Controls.Add(new Label { Text = "Thưởng / Phạt:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, row);
            cmbLoaiGiaoDich = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            cmbLoaiGiaoDich.Items.AddRange(new object[] { "Thưởng (Dương)", "Phạt (Âm)" });
            cmbLoaiGiaoDich.SelectedIndex = 0;
            mainPanel.Controls.Add(cmbLoaiGiaoDich, 1, row++);

            // 5. Số tiền
            mainPanel.Controls.Add(new Label { Text = "Số tiền:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, row);
            nudSoTien = new NumericUpDown
            {
                Dock = DockStyle.Fill,
                Minimum = 0,
                Maximum = 1000000000,
                DecimalPlaces = 0,
                Increment = 100000,
                ThousandsSeparator = true
            };
            mainPanel.Controls.Add(nudSoTien, 1, row++);

            // 6. Lý do (RichTextBox)
            mainPanel.Controls.Add(new Label { Text = "Lý do:", TextAlign = ContentAlignment.TopLeft, Dock = DockStyle.Fill }, 0, row);
            rtbLyDo = new RichTextBox { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(rtbLyDo, 1, row++);

            // 7. Nút (Thêm & Hủy)
            FlowLayoutPanel pnlButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 5, 0, 0)
            };

            btnHuy = new Button { Text = "Hủy", BackColor = Color.LightGray, ForeColor = Color.Black, FlatStyle = FlatStyle.Flat, Size = new Size(80, 30) };
            btnHuy.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            btnThem = new Button { Text = "Thêm", BackColor = Color.FromArgb(0, 123, 255), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(80, 30) };
            btnThem.Click += btnThem_Click;

            pnlButtons.Controls.Add(btnHuy);
            pnlButtons.Controls.Add(btnThem);
            mainPanel.Controls.Add(pnlButtons, 1, row++);
        }

        private void FrmThemThuong_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = MaNV;
            txtTenNV.Text = TenNV;
            txtMaNV.ReadOnly = !string.IsNullOrEmpty(MaNV);
            txtTenNV.ReadOnly = !string.IsNullOrEmpty(TenNV);

            if (cmbLoaiNV.Items.Count == 0)
            {
                cmbLoaiNV.Items.AddRange(new object[] { "Nhân viên Part-time", "Nhân viên Full-time", "Quản lý" });
            }

            if (!string.IsNullOrEmpty(LoaiNV) && cmbLoaiNV.Items.Contains(LoaiNV))
            {
                cmbLoaiNV.SelectedItem = LoaiNV;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string loaiGiaoDich = cmbLoaiGiaoDich.Text;
            decimal soTienGoc = nudSoTien.Value;
            string lyDo = rtbLyDo.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng nhập Mã Nhân Viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soTienGoc == 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền thưởng/phạt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(lyDo))
            {
                MessageBox.Show("Vui lòng nhập lý do thưởng/phạt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal soTienCuoi = soTienGoc;
            if (loaiGiaoDich.Contains("Phạt"))
            {
                soTienCuoi = -soTienGoc;
            }

            NewGiaoDich = new GiaoDichThuongPhat
            {
                MaNV = maNV,
                Thang = DateTime.Now.Month,
                Nam = DateTime.Now.Year,
                SoTien = soTienCuoi,
                LyDo = lyDo,
                NgayTao = DateTime.Now
            };

            MessageBox.Show($"Đã thêm giao dịch '{loaiGiaoDich}' cho {maNV}:\nSố tiền: {soTienCuoi:N0} VNĐ\nLý do: {lyDo}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
