namespace DoAnQLBanHang_GUI
{
    partial class frmTinhLuong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTroVe = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnThemThuong = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.grpThongKe = new System.Windows.Forms.GroupBox();
            this.lblGiaTriTongChi = new System.Windows.Forms.Label();
            this.lblGiaTriTongThuong = new System.Windows.Forms.Label();
            this.lblGiaTriTongLuong = new System.Windows.Forms.Label();
            this.lblGiaTriTongNV = new System.Windows.Forms.Label();
            this.lblTongChi = new System.Windows.Forms.Label();
            this.lblTongThuong = new System.Windows.Forms.Label();
            this.lblTongLuong = new System.Windows.Forms.Label();
            this.lblTongNV = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblThangNam = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLoaiNV = new System.Windows.Forms.Label();
            this.cmbLoaiNV = new System.Windows.Forms.ComboBox();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvDanhSachLuong = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            this.grpThongKe.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTroVe
            // 
            this.btnTroVe.Location = new System.Drawing.Point(12, 2);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(126, 39);
            this.btnTroVe.TabIndex = 2;
            this.btnTroVe.Text = "Trở Về";
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnThemThuong);
            this.pnlHeader.Controls.Add(this.btnXuatExcel);
            this.pnlHeader.Controls.Add(this.btnTinhLuong);
            this.pnlHeader.Location = new System.Drawing.Point(2, 47);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1179, 100);
            this.pnlHeader.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tính lương theo giờ làm việc và thưởng cho nhân viên, lương cứng cho quản lý ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Lương Nhân Viên";
            // 
            // btnThemThuong
            // 
            this.btnThemThuong.Location = new System.Drawing.Point(1019, 48);
            this.btnThemThuong.Name = "btnThemThuong";
            this.btnThemThuong.Size = new System.Drawing.Size(126, 39);
            this.btnThemThuong.TabIndex = 1;
            this.btnThemThuong.Text = "Thêm Thưởng";
            this.btnThemThuong.UseVisualStyleBackColor = true;
            this.btnThemThuong.Click += new System.EventHandler(this.btnThemThuong_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(845, 48);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(126, 39);
            this.btnXuatExcel.TabIndex = 1;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Location = new System.Drawing.Point(660, 48);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(126, 39);
            this.btnTinhLuong.TabIndex = 1;
            this.btnTinhLuong.Text = "Tính Lương";
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // pnlBoLoc
            // 
            this.pnlBoLoc.BackColor = System.Drawing.Color.White;
            this.pnlBoLoc.Controls.Add(this.label2);
            this.pnlBoLoc.Controls.Add(this.grpThongKe);
            this.pnlBoLoc.Controls.Add(this.lblThangNam);
            this.pnlBoLoc.Controls.Add(this.cmbThang);
            this.pnlBoLoc.Controls.Add(this.lblTimKiem);
            this.pnlBoLoc.Controls.Add(this.cmbNam);
            this.pnlBoLoc.Controls.Add(this.txtTimKiem);
            this.pnlBoLoc.Controls.Add(this.lblLoaiNV);
            this.pnlBoLoc.Controls.Add(this.cmbLoaiNV);
            this.pnlBoLoc.Location = new System.Drawing.Point(2, 153);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(391, 390);
            this.pnlBoLoc.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bộ Lọc";
            // 
            // grpThongKe
            // 
            this.grpThongKe.Controls.Add(this.lblGiaTriTongChi);
            this.grpThongKe.Controls.Add(this.lblGiaTriTongThuong);
            this.grpThongKe.Controls.Add(this.lblGiaTriTongLuong);
            this.grpThongKe.Controls.Add(this.lblGiaTriTongNV);
            this.grpThongKe.Controls.Add(this.lblTongChi);
            this.grpThongKe.Controls.Add(this.lblTongThuong);
            this.grpThongKe.Controls.Add(this.lblTongLuong);
            this.grpThongKe.Controls.Add(this.lblTongNV);
            this.grpThongKe.Controls.Add(this.label4);
            this.grpThongKe.Location = new System.Drawing.Point(13, 220);
            this.grpThongKe.Name = "grpThongKe";
            this.grpThongKe.Size = new System.Drawing.Size(349, 164);
            this.grpThongKe.TabIndex = 3;
            this.grpThongKe.TabStop = false;
            // 
            // lblGiaTriTongChi
            // 
            this.lblGiaTriTongChi.AutoSize = true;
            this.lblGiaTriTongChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTriTongChi.Location = new System.Drawing.Point(208, 135);
            this.lblGiaTriTongChi.Name = "lblGiaTriTongChi";
            this.lblGiaTriTongChi.Size = new System.Drawing.Size(26, 20);
            this.lblGiaTriTongChi.TabIndex = 2;
            this.lblGiaTriTongChi.Text = "0đ";
            // 
            // lblGiaTriTongThuong
            // 
            this.lblGiaTriTongThuong.AutoSize = true;
            this.lblGiaTriTongThuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTriTongThuong.Location = new System.Drawing.Point(208, 102);
            this.lblGiaTriTongThuong.Name = "lblGiaTriTongThuong";
            this.lblGiaTriTongThuong.Size = new System.Drawing.Size(26, 20);
            this.lblGiaTriTongThuong.TabIndex = 2;
            this.lblGiaTriTongThuong.Text = "0đ";
            // 
            // lblGiaTriTongLuong
            // 
            this.lblGiaTriTongLuong.AutoSize = true;
            this.lblGiaTriTongLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTriTongLuong.Location = new System.Drawing.Point(208, 65);
            this.lblGiaTriTongLuong.Name = "lblGiaTriTongLuong";
            this.lblGiaTriTongLuong.Size = new System.Drawing.Size(26, 20);
            this.lblGiaTriTongLuong.TabIndex = 2;
            this.lblGiaTriTongLuong.Text = "0đ";
            // 
            // lblGiaTriTongNV
            // 
            this.lblGiaTriTongNV.AutoSize = true;
            this.lblGiaTriTongNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaTriTongNV.Location = new System.Drawing.Point(208, 32);
            this.lblGiaTriTongNV.Name = "lblGiaTriTongNV";
            this.lblGiaTriTongNV.Size = new System.Drawing.Size(26, 20);
            this.lblGiaTriTongNV.TabIndex = 2;
            this.lblGiaTriTongNV.Text = "0đ";
            // 
            // lblTongChi
            // 
            this.lblTongChi.AutoSize = true;
            this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongChi.Location = new System.Drawing.Point(15, 135);
            this.lblTongChi.Name = "lblTongChi";
            this.lblTongChi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTongChi.Size = new System.Drawing.Size(69, 20);
            this.lblTongChi.TabIndex = 1;
            this.lblTongChi.Text = "Tổng chi:";
            // 
            // lblTongThuong
            // 
            this.lblTongThuong.AutoSize = true;
            this.lblTongThuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongThuong.Location = new System.Drawing.Point(15, 102);
            this.lblTongThuong.Name = "lblTongThuong";
            this.lblTongThuong.Size = new System.Drawing.Size(98, 20);
            this.lblTongThuong.TabIndex = 1;
            this.lblTongThuong.Text = "Tổng thưởng:";
            // 
            // lblTongLuong
            // 
            this.lblTongLuong.AutoSize = true;
            this.lblTongLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLuong.Location = new System.Drawing.Point(15, 65);
            this.lblTongLuong.Name = "lblTongLuong";
            this.lblTongLuong.Size = new System.Drawing.Size(89, 20);
            this.lblTongLuong.TabIndex = 1;
            this.lblTongLuong.Text = "Tổng lương:";
            // 
            // lblTongNV
            // 
            this.lblTongNV.AutoSize = true;
            this.lblTongNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNV.Location = new System.Drawing.Point(15, 32);
            this.lblTongNV.Name = "lblTongNV";
            this.lblTongNV.Size = new System.Drawing.Size(113, 20);
            this.lblTongNV.TabIndex = 1;
            this.lblTongNV.Text = "Tổng nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thống Kê";
            // 
            // lblThangNam
            // 
            this.lblThangNam.AutoSize = true;
            this.lblThangNam.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThangNam.Location = new System.Drawing.Point(5, 23);
            this.lblThangNam.Name = "lblThangNam";
            this.lblThangNam.Size = new System.Drawing.Size(106, 23);
            this.lblThangNam.TabIndex = 0;
            this.lblThangNam.Text = "Tháng/Năm";
            // 
            // cmbThang
            // 
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(9, 49);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(143, 24);
            this.cmbThang.TabIndex = 2;
            this.cmbThang.SelectedIndexChanged += new System.EventHandler(this.cmbThang_SelectedIndexChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(10, 149);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(87, 23);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm Kiếm";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(170, 49);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(141, 24);
            this.cmbNam.TabIndex = 2;
            this.cmbNam.SelectedIndexChanged += new System.EventHandler(this.cmbNam_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(9, 175);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(306, 22);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblLoaiNV
            // 
            this.lblLoaiNV.AutoSize = true;
            this.lblLoaiNV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiNV.Location = new System.Drawing.Point(3, 86);
            this.lblLoaiNV.Name = "lblLoaiNV";
            this.lblLoaiNV.Size = new System.Drawing.Size(130, 23);
            this.lblLoaiNV.TabIndex = 0;
            this.lblLoaiNV.Text = "Loại Nhân Viên";
            // 
            // cmbLoaiNV
            // 
            this.cmbLoaiNV.FormattingEnabled = true;
            this.cmbLoaiNV.Location = new System.Drawing.Point(9, 112);
            this.cmbLoaiNV.Name = "cmbLoaiNV";
            this.cmbLoaiNV.Size = new System.Drawing.Size(302, 24);
            this.cmbLoaiNV.TabIndex = 2;
            this.cmbLoaiNV.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiNV_SelectedIndexChanged);
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.BackColor = System.Drawing.Color.White;
            this.grpDanhSach.Controls.Add(this.dgvDanhSachLuong);
            this.grpDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(399, 153);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(782, 390);
            this.grpDanhSach.TabIndex = 7;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh Sách Lương";
            // 
            // dgvDanhSachLuong
            // 
            this.dgvDanhSachLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachLuong.Location = new System.Drawing.Point(15, 29);
            this.dgvDanhSachLuong.Name = "dgvDanhSachLuong";
            this.dgvDanhSachLuong.RowHeadersWidth = 51;
            this.dgvDanhSachLuong.RowTemplate.Height = 24;
            this.dgvDanhSachLuong.Size = new System.Drawing.Size(756, 355);
            this.dgvDanhSachLuong.TabIndex = 3;
            // 
            // frmTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 546);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.pnlBoLoc);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnTroVe);
            this.Name = "frmTinhLuong";
            this.Text = "frmTinhLuong";
            this.Load += new System.EventHandler(this.frmTinhLuong_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.grpThongKe.ResumeLayout(false);
            this.grpThongKe.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnThemThuong;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpThongKe;
        private System.Windows.Forms.Label lblGiaTriTongChi;
        private System.Windows.Forms.Label lblGiaTriTongThuong;
        private System.Windows.Forms.Label lblGiaTriTongLuong;
        private System.Windows.Forms.Label lblGiaTriTongNV;
        private System.Windows.Forms.Label lblTongChi;
        private System.Windows.Forms.Label lblTongThuong;
        private System.Windows.Forms.Label lblTongLuong;
        private System.Windows.Forms.Label lblTongNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblThangNam;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLoaiNV;
        private System.Windows.Forms.ComboBox cmbLoaiNV;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvDanhSachLuong;
    }
}