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
using System.IO; // Thêm dòng này

namespace DoAnQLBanHang_GUI
{
    public partial class frmThemNV : Form
    {
        private readonly QLBDANmodel qLBDA = new QLBDANmodel();
        private Rectangle btnSua, btnMK, btnKhoa;
        public frmThemNV()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";

            // 2. Đặt lại 2 ComboBox về "Tất cả" (index = 0)
            cbQuyen.SelectedIndex = 0;
            cbTrangThai.SelectedIndex = 0;

            // 3. Tải lại dữ liệu với các bộ lọc đã được làm mới
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmThem frmThem = new frmThem();

            // 2. Dùng ShowDialog() và kiểm tra kết quả trả về
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                // 3. Nếu form "frmThem" trả về OK (tức là đã Thêm thành công),
                //    thì tải lại dữ liệu trên DataGridView
                LoadData();
            }
        }
        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["HanhDong"].Index)
                return;

            e.PaintBackground(e.CellBounds, true);

            int buttonWidth = (e.CellBounds.Width - 20) / 3;
            int buttonHeight = e.CellBounds.Height - 8;

            btnSua = new Rectangle(e.CellBounds.Left + 5, e.CellBounds.Top + 4, buttonWidth, buttonHeight);
            btnMK = new Rectangle(btnSua.Right + 5, e.CellBounds.Top + 4, buttonWidth, buttonHeight);
            btnKhoa = new Rectangle(btnMK.Right + 5, e.CellBounds.Top + 4, buttonWidth, buttonHeight);

            using (Brush bSua = new SolidBrush(Color.LightGreen))
                e.Graphics.FillRectangle(bSua, btnSua);
            e.Graphics.DrawString("Sửa", dataGridView1.Font, Brushes.Black, btnSua,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            using (Brush bMK = new SolidBrush(Color.Orange))
                e.Graphics.FillRectangle(bMK, btnMK);
            e.Graphics.DrawString("MK", dataGridView1.Font, Brushes.White, btnMK,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            using (Brush bKhoa = new SolidBrush(Color.Red))
                e.Graphics.FillRectangle(bKhoa, btnKhoa);
            e.Graphics.DrawString("Khóa", dataGridView1.Font, Brushes.White, btnKhoa,
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            e.Handled = true;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Nếu click vào header hoặc hàng mới (hàng rỗng) thì thoát
            if (e.RowIndex < 0)
                return;

            // 2. Lấy dòng hiện tại
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // 3. Kiểm tra xem có click vào cột "Hành Động" không
            if (e.ColumnIndex == dataGridView1.Columns["HanhDong"].Index)
            {
                // ===== ĐÂY LÀ CODE CŨ CỦA BẠN ĐỂ XỬ LÝ NÚT SỬA/MK/KHÓA =====
                Point clickPoint = dataGridView1.PointToClient(Cursor.Position);
                Rectangle cellBounds = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int relX = clickPoint.X - cellBounds.Left;
                int relY = clickPoint.Y - cellBounds.Top;

                int buttonWidth = (cellBounds.Width - 20) / 3;
                int buttonHeight = cellBounds.Height - 8;

                Rectangle rSua = new Rectangle(5, 4, buttonWidth, buttonHeight);
                Rectangle rMK = new Rectangle(rSua.Right + 5, 4, buttonWidth, buttonHeight);
                Rectangle rKhoa = new Rectangle(rMK.Right + 5, 4, buttonWidth, buttonHeight);

                if (!int.TryParse(row.Cells["MaNV"].Value?.ToString(), out int maNV))
                    return;
                string tenNV = row.Cells["TenNV"].Value?.ToString();

                if (rSua.Contains(relX, relY))
                {
                    // (Code Sửa của bạn)
                    frmThem them = new frmThem(maNV);
                    if (them.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
                else if (rMK.Contains(relX, relY))
                {
                    // (Code MK của bạn)
                    MessageBox.Show("Chức năng đổi mật khẩu");
                }
                else if (rKhoa.Contains(relX, relY))
                {
                    // (Code Khóa của bạn)
                    var nv = qLBDA.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                    if (nv != null)
                    {
                        bool trangThaiCu = nv.VoHieuHoa ?? false;
                        nv.VoHieuHoa = !trangThaiCu;
                        qLBDA.SaveChanges();
                        LoadData();
                        MessageBox.Show($"Đã {(trangThaiCu ? "mở khóa" : "khóa")} tài khoản: {tenNV}");
                    }
                }
                // ===== KẾT THÚC CODE XỬ LÝ NÚT =====
            }
            else
            {
                // ===== 4. CODE MỚI: KHI CLICK VÀO CÁC CỘT KHÁC =====
                // Lấy dữ liệu từ các ô trong dòng (row) đã lấy ở trên
                string hoTen = row.Cells["TenNV"].Value?.ToString();
                string diaChi = row.Cells["DiaChi"].Value?.ToString(); // Lấy từ cột ẩn
                string cccd = row.Cells["CCCD"].Value?.ToString();     // Lấy từ cột ẩn

                // Gán vào các Label bạn đã tạo ở Bước 1
                lblInfoHoTen.Text = hoTen;
                lblInfoDiaChi.Text = diaChi;
                lblInfoCCCD.Text = cccd;
            }
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex == dataGridView1.Columns["HanhDong"].Index)
                    return;

                if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["MaNV"].Value?.ToString(), out int maNV))
                    return;

                var nv = qLBDA.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                if (nv == null) return;

                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                string newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                switch (columnName)
                {
                    case "TenNV":
                        nv.TenNV = newValue;
                        break;
                    case "TenDangNhap":
                        nv.TenDangNhap = newValue;
                        break;
                    case "VaiTro":
                        nv.VaiTro = newValue;
                        break;
                }

                qLBDA.SaveChanges();
                MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi cập nhật: " + ex.Message);
            }
        }
        private void FillComboBoxQuyen()
        {
            cbQuyen.Items.Clear();
            cbQuyen.Items.Add("Tất cả");
            cbQuyen.Items.Add("Admin");
            cbQuyen.Items.Add("Quản lý");
            cbQuyen.Items.Add("Nhân viên");
            cbQuyen.SelectedIndex = 0; // <--- Sửa thành 0 (Tất cả)
        }


        private void frmThemNV_Load(object sender, EventArgs e)
        {
            try
            {
                FillComboBoxQuyen();
                FillComboBoxTrangThai(); // <--- GỌI HÀM MỚI
                KhoiTaoGrid();
                LoadData();

                // Gán sự kiện cho các control lọc
                btnTim.Click += new EventHandler(button1_Click);
                cbQuyen.SelectedIndexChanged += new EventHandler(FilterControls_Changed);
                cbTrangThai.SelectedIndexChanged += new EventHandler(FilterControls_Changed);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FillComboBoxTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Tất cả");
            cbTrangThai.Items.Add("Hoạt động");
            cbTrangThai.Items.Add("Đã khóa");
            cbTrangThai.SelectedIndex = 0; // Mặc định là "Tất cả"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FilterControls_Changed(object sender, EventArgs e)
        {
            LoadData(); // Gọi lại LoadData khi chọn ComboBox
        }

        private void LoadData()
        {
            // 1. Lấy giá trị từ các control lọc
            string timKiem = txtTimKiem.Text.Trim().ToLower();
            string quyen = cbQuyen.Text;
            string trangThai = cbTrangThai.Text;

            // 2. Bắt đầu truy vấn
            var query = qLBDA.NHANVIENs.AsQueryable();

            // 3. Áp dụng bộ lọc "Tìm Kiếm"
            if (!string.IsNullOrEmpty(timKiem))
            {
                query = query.Where(x =>
                    x.TenNV.ToLower().Contains(timKiem) ||
                    x.TenDangNhap.ToLower().Contains(timKiem)
                );
            }

            // 4. Áp dụng bộ lọc "Quyền"
            if (quyen != "Tất cả")
            {
                query = query.Where(x => x.VaiTro == quyen);
            }

            // 5. Áp dụng bộ lọc "Trạng Thái"
            if (trangThai != "Tất cả")
            {
                bool laDaKhoa = (trangThai == "Đã khóa");
                query = query.Where(x => x.VoHieuHoa == laDaKhoa);
            }

            // 6. Thực thi truy vấn và gán kết quả
            var dsNV = query
                .Select(x => new
                {
                    x.MaNV,
                    x.TenNV,
                    x.TenDangNhap,
                    x.VaiTro,
                    TrangThai = x.VoHieuHoa == false ? "Hoạt động" : "Đã khóa",

                    // ===== SỬA LỖI 1: Thêm 2 dấu phẩy bị thiếu =====
                    x.DiaChi,
                    x.CCCD
                })
                .ToList();

            dataGridView1.Rows.Clear();
            foreach (var nv in dsNV)
            {
                // ===== SỬA LỖI 2: Thêm 2 giá trị "DiaChi" và "CCCD" vào hàng =====
                dataGridView1.Rows.Add(
                    nv.MaNV,
                    nv.TenNV,
                    nv.TenDangNhap,
                    nv.VaiTro,
                    nv.TrangThai,
                    // Thêm 2 cột dữ liệu ẩn
                    nv.DiaChi,
                    nv.CCCD
                // Cột "HanhDong" không cần thêm ở đây vì nó được vẽ tự động
                );
            }
        }
        private void KhoiTaoGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            dataGridView1.Columns.Add("MaNV", "Mã NV");
            dataGridView1.Columns.Add("TenNV", "Họ và Tên");
            dataGridView1.Columns.Add("TenDangNhap", "Tài Khoản");
            dataGridView1.Columns.Add("VaiTro", "Quyền");
            dataGridView1.Columns.Add("TrangThai", "Trạng Thái");

            // Thêm 2 cột ẩn
            dataGridView1.Columns.Add("DiaChi", "Địa Chỉ");
            dataGridView1.Columns.Add("CCCD", "CCCD");

            // ===== SỬA LỖI 3: Xóa các dòng thêm cột "HanhDong" bị trùng lặp =====

            // Tạo cột hành động (vẽ nút) - CHỈ 1 LẦN
            DataGridViewTextBoxColumn colAction = new DataGridViewTextBoxColumn();
            colAction.HeaderText = "Hành Động";
            colAction.Name = "HanhDong";
            colAction.Width = 220;
            dataGridView1.Columns.Add(colAction); // Chỉ thêm 1 lần này

            // (Xóa các dòng bị trùng lặp ở đây)

            // Chỉ đọc 1 số cột
            dataGridView1.Columns["MaNV"].ReadOnly = true;
            dataGridView1.Columns["TrangThai"].ReadOnly = true;
            dataGridView1.Columns["HanhDong"].ReadOnly = true;

            // Ẩn 2 cột dữ liệu
            dataGridView1.Columns["DiaChi"].Visible = false;
            dataGridView1.Columns["CCCD"].Visible = false;

            // Gắn event
            dataGridView1.CellPainting += DataGridView1_CellPainting;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        }

    }
}
