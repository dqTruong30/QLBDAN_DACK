namespace DoAnQLBanHang_GUI
{
    partial class frmThemNV
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.cbQuyen = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_xuatexcel = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblInfoHoTen = new System.Windows.Forms.Label();
            this.lblInfoCCCD = new System.Windows.Forms.Label();
            this.lblInfoDiaChi = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(174, 31);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(216, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(657, 31);
            this.cbTrangThai.Margin = new System.Windows.Forms.Padding(4);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(179, 24);
            this.cbTrangThai.TabIndex = 1;
            // 
            // cbQuyen
            // 
            this.cbQuyen.FormattingEnabled = true;
            this.cbQuyen.Location = new System.Drawing.Point(406, 31);
            this.cbQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(236, 24);
            this.cbQuyen.TabIndex = 2;
            this.cbQuyen.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.Green;
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTim.Location = new System.Drawing.Point(848, 16);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 39);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Search";
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "🔎 Tìm Kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(654, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "🔒 Trạng Thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "📂 Lọc Theo Quyền";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Location = new System.Drawing.Point(17, 75);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(931, 257);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "MANV";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Họ và Tên";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tài Khoản";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quyền";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Trạng Thái";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Hành Động";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // btn_xuatexcel
            // 
            this.btn_xuatexcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_xuatexcel.FlatAppearance.BorderSize = 0;
            this.btn_xuatexcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xuatexcel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_xuatexcel.Location = new System.Drawing.Point(575, 470);
            this.btn_xuatexcel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xuatexcel.Name = "btn_xuatexcel";
            this.btn_xuatexcel.Size = new System.Drawing.Size(180, 34);
            this.btn_xuatexcel.TabIndex = 8;
            this.btn_xuatexcel.Text = " 🖨️ Xuất Excel";
            this.btn_xuatexcel.UseVisualStyleBackColor = false;
            this.btn_xuatexcel.Click += new System.EventHandler(this.btn_xuatexcel_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Green;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(387, 470);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "+   Thêm nhân viên";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(771, 470);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 34);
            this.button4.TabIndex = 10;
            this.button4.Text = "🔄 Làm Mới";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lblInfoHoTen
            // 
            this.lblInfoHoTen.AutoSize = true;
            this.lblInfoHoTen.Location = new System.Drawing.Point(8, 30);
            this.lblInfoHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoHoTen.Name = "lblInfoHoTen";
            this.lblInfoHoTen.Size = new System.Drawing.Size(73, 16);
            this.lblInfoHoTen.TabIndex = 11;
            this.lblInfoHoTen.Text = "Họ và Tên:";
            // 
            // lblInfoCCCD
            // 
            this.lblInfoCCCD.AutoSize = true;
            this.lblInfoCCCD.Location = new System.Drawing.Point(8, 98);
            this.lblInfoCCCD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoCCCD.Name = "lblInfoCCCD";
            this.lblInfoCCCD.Size = new System.Drawing.Size(47, 16);
            this.lblInfoCCCD.TabIndex = 12;
            this.lblInfoCCCD.Text = "CCCD:";
            // 
            // lblInfoDiaChi
            // 
            this.lblInfoDiaChi.AutoSize = true;
            this.lblInfoDiaChi.Location = new System.Drawing.Point(8, 65);
            this.lblInfoDiaChi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoDiaChi.Name = "lblInfoDiaChi";
            this.lblInfoDiaChi.Size = new System.Drawing.Size(53, 16);
            this.lblInfoDiaChi.TabIndex = 13;
            this.lblInfoDiaChi.Text = "Địa chỉ: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblInfoDiaChi);
            this.groupBox1.Controls.Add(this.lblInfoCCCD);
            this.groupBox1.Controls.Add(this.lblInfoHoTen);
            this.groupBox1.Location = new System.Drawing.Point(13, 340);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(931, 122);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_back.Location = new System.Drawing.Point(17, 16);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(109, 37);
            this.btn_back.TabIndex = 15;
            this.btn_back.Text = "<-   Trở về";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // frmThemNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btn_xuatexcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.cbQuyen);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.txtTimKiem);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThemNV";
            this.Text = "frmThemNV";
            this.Load += new System.EventHandler(this.frmThemNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_xuatexcel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblInfoHoTen;
        private System.Windows.Forms.Label lblInfoCCCD;
        private System.Windows.Forms.Label lblInfoDiaChi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btn_back;
    }
}