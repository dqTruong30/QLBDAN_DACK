namespace DoAnQLBanHang_GUI
{
    partial class frmHeThong
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHeThong));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnThemNhanVien = new System.Windows.Forms.Button();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.btnLuongNhanVien = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.btnThemNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNhanVien.ForeColor = System.Drawing.Color.White;
            this.errorProvider1.SetIconAlignment(this.btnThemNhanVien, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.btnThemNhanVien.Location = new System.Drawing.Point(51, 74);
            this.btnThemNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnThemNhanVien.Size = new System.Drawing.Size(270, 103);
            this.btnThemNhanVien.TabIndex = 8;
            this.btnThemNhanVien.Text = "Thêm nhân viên";
            this.btnThemNhanVien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThemNhanVien.UseVisualStyleBackColor = false;
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoanhThu.ForeColor = System.Drawing.Color.White;
            this.errorProvider1.SetIconAlignment(this.btnDoanhThu, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.btnDoanhThu.Location = new System.Drawing.Point(51, 195);
            this.btnDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnDoanhThu.Size = new System.Drawing.Size(270, 103);
            this.btnDoanhThu.TabIndex = 17;
            this.btnDoanhThu.Text = "Danh Thu";
            this.btnDoanhThu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDoanhThu.UseVisualStyleBackColor = false;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // btnLuongNhanVien
            // 
            this.btnLuongNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.btnLuongNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuongNhanVien.ForeColor = System.Drawing.Color.White;
            this.errorProvider1.SetIconAlignment(this.btnLuongNhanVien, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.btnLuongNhanVien.Location = new System.Drawing.Point(51, 320);
            this.btnLuongNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuongNhanVien.Name = "btnLuongNhanVien";
            this.btnLuongNhanVien.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnLuongNhanVien.Size = new System.Drawing.Size(270, 103);
            this.btnLuongNhanVien.TabIndex = 18;
            this.btnLuongNhanVien.Text = "Lương Nhân Viên";
            this.btnLuongNhanVien.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLuongNhanVien.UseVisualStyleBackColor = false;
            this.btnLuongNhanVien.Click += new System.EventHandler(this.btnLuongNhanVien_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.errorProvider1.SetIconAlignment(this.pictureBox3, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(148, 338);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(87, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.errorProvider1.SetIconAlignment(this.pictureBox2, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(157, 213);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(32)))), ((int)(((byte)(20)))));
            this.errorProvider1.SetIconAlignment(this.pictureBox1, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(151, 92);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(363, 45);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(598, 414);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // frmHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1347, 508);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLuongNhanVien);
            this.Controls.Add(this.btnDoanhThu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThemNhanVien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHeThong";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 13, 0);
            this.Text = "frmHeThong";
            this.Load += new System.EventHandler(this.frmHeThong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnThemNhanVien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLuongNhanVien;
        private System.Windows.Forms.Button btnDoanhThu;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}