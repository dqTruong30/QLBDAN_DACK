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
    public partial class frmThem : Form
    {

        private readonly QLBDANmodel qLBDA = new QLBDANmodel();
        private bool isEditMode = false;
        private int maNV = 0;
        public frmThem()
        {
            InitializeComponent();
            this.isEditMode = false;
        }
        public frmThem(int maNhanVienDeSua) // Nhận maNV từ form cha
        {
            InitializeComponent();
            this.maNV = maNhanVienDeSua; // Gán maNV được truyền vào
            this.isEditMode = true; // Đặt là true cho chế độ SỬA
        }

        private void frmThem_Load(object sender, EventArgs e)
        {
            FillComboBoxQuyen();
            if (isEditMode)
            {
                this.Text = "Sửa Thông Tin Nhân Viên";
                // txtMaNV.Enabled = false; // Nên khóa ô Mã NV khi sửa

                var nv = qLBDA.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                if (nv != null)
                {
                    txtMaNV.Text = nv.MaNV.ToString();
                    txtHoTen.Text = nv.TenNV;
                    cbQuyen.Text = nv.VaiTro;
                    dtNgaySinh.Value = nv.NgaySinh ?? DateTime.Now; // Xử lý nếu NgaySinh có thể null
                    txtCCCD.Text = nv.CCCD;
                    txtSDT.Text = nv.SDT;
                    txtTaiKhoan.Text = nv.TenDangNhap;
                    txtMatKhau.Text = nv.MatKhau;
                }
            }
            else
            {
                this.Text = "Thêm Thông Tin Nhân Viên";
                // Có thể để trống ô MaNV nếu nó là tự động tăng (IDENTITY)
                // Hoặc bạn phải xử lý logic nhập MaNV (và kiểm tra trùng)
                txtMaNV.Enabled = false; // Tạm thời khóa, vì logic thêm mới của bạn không gán MaNV
                                         // Nếu MaNV là tự tăng, bạn nên xóa TextBox MaNV đi.
                                         // Nếu MaNV là tự nhập, bạn phải sửa code ở btnThem_Click
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // ===== SỬA ĐỔI 3: Kiểm tra ComboBox trước khi lưu =====
                if (cbQuyen.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn quyền cho nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbQuyen.Focus();
                    return;
                }

                string vaiTro = cbQuyen.SelectedItem.ToString();

                if (isEditMode)
                {
                    // Cập nhật nhân viên
                    var nv = qLBDA.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
                    if (nv != null)
                    {
                        nv.TenNV = txtHoTen.Text.Trim();
                        nv.VaiTro = vaiTro; // Dùng biến đã kiểm tra
                        nv.NgaySinh = dtNgaySinh.Value;
                        nv.CCCD = txtCCCD.Text.Trim();
                        nv.SDT = txtSDT.Text.Trim();
                        nv.TenDangNhap = txtTaiKhoan.Text.Trim();
                        nv.MatKhau = txtMatKhau.Text.Trim();

                        qLBDA.SaveChanges();
                        MessageBox.Show("✅ Cập nhật nhân viên thành công!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Thêm nhân viên mới
                    NHANVIEN nv = new NHANVIEN
                    {
                        TenNV = txtHoTen.Text.Trim(),
                        VaiTro = vaiTro, // Dùng biến đã kiểm tra
                        NgaySinh = dtNgaySinh.Value,
                        CCCD = txtCCCD.Text.Trim(),
                        SDT = txtSDT.Text.Trim(),
                        TenDangNhap = txtTaiKhoan.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        VoHieuHoa = false
                    };

                    qLBDA.NHANVIENs.Add(nv);
                    qLBDA.SaveChanges();
                    MessageBox.Show("✅ Thêm nhân viên thành công!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi lưu nhân viên: " + ex.Message);
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FillComboBoxQuyen()
        {
            cbQuyen.Items.Clear();
            cbQuyen.Items.Add("Admin");
            cbQuyen.Items.Add("Quản lý");
            cbQuyen.Items.Add("Nhân viên");
            // Bạn có thể đặt giá trị mặc định nếu muốn
            // cbQuyen.SelectedIndex = 2; // Mặc định là "Nhân viên"
        }
    }
}
