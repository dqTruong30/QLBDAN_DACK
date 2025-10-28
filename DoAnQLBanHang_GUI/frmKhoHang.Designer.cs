namespace DoAnQLBanHang_GUI
{
    partial class frmKhoHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.txtTenNguyenLieu = new System.Windows.Forms.TextBox();
            this.txtSoLuongTon = new System.Windows.Forms.TextBox();
            this.cbbNhaCungCap = new System.Windows.Forms.ComboBox();
            this.txtMaNguyenLieu = new System.Windows.Forms.TextBox();
            this.btnThemSanPhamVaoKho = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaNguyenLieu = new System.Windows.Forms.Button();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.txtLocTheoMaTenSP = new System.Windows.Forms.TextBox();
            this.dgvKhoHang = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpHanSuDung);
            this.groupBox1.Controls.Add(this.btnThemSanPhamVaoKho);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDonViTinh);
            this.groupBox1.Controls.Add(this.txtTenNguyenLieu);
            this.groupBox1.Controls.Add(this.txtSoLuongTon);
            this.groupBox1.Controls.Add(this.cbbNhaCungCap);
            this.groupBox1.Controls.Add(this.txtMaNguyenLieu);
            this.groupBox1.Location = new System.Drawing.Point(26, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 162);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // dtpHanSuDung
            // 
            this.dtpHanSuDung.Location = new System.Drawing.Point(386, 60);
            this.dtpHanSuDung.Name = "dtpHanSuDung";
            this.dtpHanSuDung.Size = new System.Drawing.Size(181, 22);
            this.dtpHanSuDung.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số lượng nhập";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhà Cung Cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hạn Sử Dụng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên Nguyên Liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giá Nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã Nguyên Liệu";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(691, 63);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(213, 22);
            this.txtDonViTinh.TabIndex = 1;
            // 
            // txtTenNguyenLieu
            // 
            this.txtTenNguyenLieu.Location = new System.Drawing.Point(386, 20);
            this.txtTenNguyenLieu.Name = "txtTenNguyenLieu";
            this.txtTenNguyenLieu.Size = new System.Drawing.Size(181, 22);
            this.txtTenNguyenLieu.TabIndex = 1;
            // 
            // txtSoLuongTon
            // 
            this.txtSoLuongTon.Location = new System.Drawing.Point(116, 62);
            this.txtSoLuongTon.Name = "txtSoLuongTon";
            this.txtSoLuongTon.Size = new System.Drawing.Size(134, 22);
            this.txtSoLuongTon.TabIndex = 1;
            // 
            // cbbNhaCungCap
            // 
            this.cbbNhaCungCap.FormattingEnabled = true;
            this.cbbNhaCungCap.Location = new System.Drawing.Point(691, 20);
            this.cbbNhaCungCap.Name = "cbbNhaCungCap";
            this.cbbNhaCungCap.Size = new System.Drawing.Size(213, 24);
            this.cbbNhaCungCap.TabIndex = 2;
            // 
            // txtMaNguyenLieu
            // 
            this.txtMaNguyenLieu.Location = new System.Drawing.Point(116, 20);
            this.txtMaNguyenLieu.Name = "txtMaNguyenLieu";
            this.txtMaNguyenLieu.Size = new System.Drawing.Size(134, 22);
            this.txtMaNguyenLieu.TabIndex = 1;
            // 
            // btnThemSanPhamVaoKho
            // 
            this.btnThemSanPhamVaoKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemSanPhamVaoKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSanPhamVaoKho.ForeColor = System.Drawing.SystemColors.Control;
            this.btnThemSanPhamVaoKho.Location = new System.Drawing.Point(642, 101);
            this.btnThemSanPhamVaoKho.Name = "btnThemSanPhamVaoKho";
            this.btnThemSanPhamVaoKho.Size = new System.Drawing.Size(259, 35);
            this.btnThemSanPhamVaoKho.TabIndex = 14;
            this.btnThemSanPhamVaoKho.Text = "Thêm Thực Phẩm Vào Kho";
            this.btnThemSanPhamVaoKho.UseVisualStyleBackColor = false;
            this.btnThemSanPhamVaoKho.Click += new System.EventHandler(this.btnThemSanPhamVaoKho_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Teal;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLamMoi.Location = new System.Drawing.Point(843, 479);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(109, 31);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaNguyenLieu
            // 
            this.btnXoaNguyenLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaNguyenLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNguyenLieu.ForeColor = System.Drawing.SystemColors.Control;
            this.btnXoaNguyenLieu.Location = new System.Drawing.Point(634, 479);
            this.btnXoaNguyenLieu.Name = "btnXoaNguyenLieu";
            this.btnXoaNguyenLieu.Size = new System.Drawing.Size(193, 31);
            this.btnXoaNguyenLieu.TabIndex = 11;
            this.btnXoaNguyenLieu.Text = "Xoá Nguyên Liệu";
            this.btnXoaNguyenLieu.UseVisualStyleBackColor = false;
            this.btnXoaNguyenLieu.Click += new System.EventHandler(this.btnXoaNguyenLieu_Click);
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.Location = new System.Drawing.Point(412, 10);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(75, 23);
            this.btnBoLoc.TabIndex = 12;
            this.btnBoLoc.Text = "Bỏ Lọc";
            this.btnBoLoc.UseVisualStyleBackColor = true;
            this.btnBoLoc.Click += new System.EventHandler(this.btnBoLoc_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(330, 11);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 13;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txtLocTheoMaTenSP
            // 
            this.txtLocTheoMaTenSP.Location = new System.Drawing.Point(26, 11);
            this.txtLocTheoMaTenSP.Name = "txtLocTheoMaTenSP";
            this.txtLocTheoMaTenSP.Size = new System.Drawing.Size(298, 22);
            this.txtLocTheoMaTenSP.TabIndex = 9;
            // 
            // dgvKhoHang
            // 
            this.dgvKhoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoHang.Location = new System.Drawing.Point(26, 209);
            this.dgvKhoHang.Name = "dgvKhoHang";
            this.dgvKhoHang.RowHeadersWidth = 51;
            this.dgvKhoHang.RowTemplate.Height = 24;
            this.dgvKhoHang.Size = new System.Drawing.Size(926, 264);
            this.dgvKhoHang.TabIndex = 8;
            this.dgvKhoHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoHang_CellContentClick);
            // 
            // frmKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 592);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoaNguyenLieu);
            this.Controls.Add(this.btnBoLoc);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtLocTheoMaTenSP);
            this.Controls.Add(this.dgvKhoHang);
            this.Name = "frmKhoHang";
            this.Text = "frmKhoHang";
            this.Load += new System.EventHandler(this.frmKhoHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpHanSuDung;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.TextBox txtTenNguyenLieu;
        private System.Windows.Forms.TextBox txtSoLuongTon;
        private System.Windows.Forms.ComboBox cbbNhaCungCap;
        private System.Windows.Forms.TextBox txtMaNguyenLieu;
        private System.Windows.Forms.Button btnThemSanPhamVaoKho;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoaNguyenLieu;
        private System.Windows.Forms.Button btnBoLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txtLocTheoMaTenSP;
        private System.Windows.Forms.DataGridView dgvKhoHang;
    }
}