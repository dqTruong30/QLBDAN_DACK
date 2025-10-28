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
    public partial class frmSanPham : Form
    {
        private readonly QLBDANmodel qLBDA = new QLBDANmodel();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {

            try
            {
                List<LOAIMON> listLoai = qLBDA.LOAIMONs.ToList();
                List<MONAN> listMon = qLBDA.MONANs.ToList();

                // Đổ dữ liệu vào combobox và datagridview
                FillComboBox(listLoai);
                BindGrid(listMon);
                cbTimLoai.SelectedIndexChanged += (s, ev) => LocMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void FillComboBox(List<LOAIMON> listLoai)
        {
            cbloaiMon.DataSource = listLoai;
            cbloaiMon.DisplayMember = "TenLoai";
            cbloaiMon.ValueMember = "MaLoai";
            cbTimLoai.DataSource = listLoai.ToList(); // copy danh sách để tránh lỗi Binding
            cbTimLoai.DisplayMember = "TenLoai";
            cbTimLoai.ValueMember = "MaLoai";
            cbTimLoai.SelectedIndex = -1; // mặc định chưa chọn
        }
        private void BindGrid(List<MONAN> listMon)
        {
            dgvMonAn.Rows.Clear();
            int stt = 1;
            foreach (var item in listMon)
            {
                int index = dgvMonAn.Rows.Add();
                dgvMonAn.Rows[index].Cells[0].Value = stt++;
                dgvMonAn.Rows[index].Cells[1].Value = item.MaMon;
                dgvMonAn.Rows[index].Cells[2].Value = item.TenMon;
                dgvMonAn.Rows[index].Cells[3].Value = item.LOAIMON.TenLoai;
                dgvMonAn.Rows[index].Cells[4].Value = item.DonGia;
                dgvMonAn.Rows[index].Cells[5].Value = item.MoTa;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(button1.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin món ăn!", "Cảnh báo");
                    return;
                }

                // Tạo đối tượng món ăn mới
                MONAN mon = new MONAN
                {
                    TenMon = txtTenMon.Text.Trim(),
                    MaLoai = (int)cbloaiMon.SelectedValue,
                    DonGia = decimal.Parse(txtGiaBan.Text.Trim()),
                    MoTa = txtMoTa.Text.Trim(),
                    TrangThai = true
                };

                qLBDA.MONANs.Add(mon);
                qLBDA.SaveChanges();

                MessageBox.Show("Thêm món ăn thành công!", "Thông báo");
                BindGrid(qLBDA.MONANs.ToList());
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm món: " + ex.Message, "Lỗi");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn món cần sửa!", "Cảnh báo");
                    return;
                }

                int maMon = int.Parse(txtMaMon.Text);
                var mon = qLBDA.MONANs.FirstOrDefault(x => x.MaMon == maMon);

                if (mon != null)
                {
                    mon.TenMon = txtTenMon.Text.Trim();
                    mon.MaLoai = (int)cbloaiMon.SelectedValue;
                    mon.DonGia = decimal.Parse(txtGiaBan.Text.Trim());
                    mon.MoTa = txtMoTa.Text.Trim();

                    qLBDA.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    BindGrid(qLBDA.MONANs.ToList());
                    ClearInput();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món ăn cần sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa món: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaMon.Text))
                {
                    MessageBox.Show("Vui lòng chọn món cần xóa!", "Cảnh báo");
                    return;
                }

                int maMon = int.Parse(txtMaMon.Text);
                var mon = qLBDA.MONANs.FirstOrDefault(x => x.MaMon == maMon);

                if (mon != null)
                {
                    var result = MessageBox.Show($"Bạn có chắc muốn xóa món '{mon.TenMon}' không?",
                                                 "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        qLBDA.MONANs.Remove(mon);
                        qLBDA.SaveChanges();

                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        BindGrid(qLBDA.MONANs.ToList());
                        ClearInput();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món cần xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa món: " + ex.Message);
            }
        }

        private void dgvMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];

                txtMaMon.Text = row.Cells[1].Value?.ToString();      // Mã món
                txtTenMon.Text = row.Cells[2].Value?.ToString();     // Tên món
                cbloaiMon.Text = row.Cells[3].Value?.ToString();     // Tên loại
                txtGiaBan.Text = row.Cells[4].Value?.ToString();     // Giá bán
                txtMoTa.Text = row.Cells[5].Value?.ToString();       // Mô tả

                txtMaMon.Enabled = false; // khóa mã món khi chọn
            }
        }
        private void ClearInput()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtGiaBan.Clear();
            txtMoTa.Clear();
            cbloaiMon.SelectedIndex = 0;
            txtMaMon.Enabled = true; // bật lại khi thêm mới
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int? maLoai = cbTimLoai.SelectedIndex >= 0 ? (int?)cbTimLoai.SelectedValue : null;

                var ds = qLBDA.MONANs.AsQueryable();

                //if (!string.IsNullOrWhiteSpace(tenMon))
                    //ds = ds.Where(m => m.TenMon.ToLower().Contains(tenMon));

                if (maLoai.HasValue)
                    ds = ds.Where(m => m.MaLoai == maLoai.Value);

                var ketQua = ds.ToList();

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy món nào phù hợp!", "Kết quả tìm kiếm");
                }

                BindGrid(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        private void LocMonAn()
        {
            try
            {
                //string tenMon = txtTimTen.Text.Trim().ToLower();
                int? maLoai = cbTimLoai.SelectedIndex >= 0 ? (int?)cbTimLoai.SelectedValue : null;

                var ds = qLBDA.MONANs.AsQueryable();

                //if (!string.IsNullOrEmpty(tenMon))
                    //ds = ds.Where(m => m.TenMon.ToLower().Contains(tenMon));

                if (maLoai.HasValue)
                    ds = ds.Where(m => m.MaLoai == maLoai.Value);

                BindGrid(ds.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc dữ liệu: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

