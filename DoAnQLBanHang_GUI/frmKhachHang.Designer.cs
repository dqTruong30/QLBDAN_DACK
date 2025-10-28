namespace DoAnQLBanHang_GUI
{
    partial class frmKhachHang
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
            this.btn_delete = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btn_search_info_khachhang = new System.Windows.Forms.Button();
            this.tb_search_telephone = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_diachi = new System.Windows.Forms.TextBox();
            this.tb_sodienthoai = new System.Windows.Forms.TextBox();
            this.tb_tenkhachhang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.btn_search_info_khachhang);
            this.groupBox1.Controls.Add(this.tb_search_telephone);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(353, 525);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm Khách Hàng";
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Red;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_delete.Location = new System.Drawing.Point(6, 453);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(177, 33);
            this.btn_delete.TabIndex = 3;
            this.btn_delete.Text = "Xóa Khách Hàng";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(7, 94);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(340, 347);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btn_search_info_khachhang
            // 
            this.btn_search_info_khachhang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_search_info_khachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search_info_khachhang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_search_info_khachhang.Location = new System.Drawing.Point(217, 32);
            this.btn_search_info_khachhang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search_info_khachhang.Name = "btn_search_info_khachhang";
            this.btn_search_info_khachhang.Size = new System.Drawing.Size(89, 42);
            this.btn_search_info_khachhang.TabIndex = 1;
            this.btn_search_info_khachhang.Text = "Search";
            this.btn_search_info_khachhang.UseVisualStyleBackColor = false;
            this.btn_search_info_khachhang.Click += new System.EventHandler(this.btn_search_info_khachhang_Click);
            // 
            // tb_search_telephone
            // 
            this.tb_search_telephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search_telephone.Location = new System.Drawing.Point(7, 42);
            this.tb_search_telephone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_search_telephone.Name = "tb_search_telephone";
            this.tb_search_telephone.Size = new System.Drawing.Size(192, 27);
            this.tb_search_telephone.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_diachi);
            this.groupBox2.Controls.Add(this.tb_sodienthoai);
            this.groupBox2.Controls.Add(this.tb_tenkhachhang);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(364, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(570, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // tb_diachi
            // 
            this.tb_diachi.Location = new System.Drawing.Point(205, 110);
            this.tb_diachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.ReadOnly = true;
            this.tb_diachi.Size = new System.Drawing.Size(359, 27);
            this.tb_diachi.TabIndex = 5;
            // 
            // tb_sodienthoai
            // 
            this.tb_sodienthoai.Location = new System.Drawing.Point(205, 75);
            this.tb_sodienthoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_sodienthoai.Name = "tb_sodienthoai";
            this.tb_sodienthoai.ReadOnly = true;
            this.tb_sodienthoai.Size = new System.Drawing.Size(359, 27);
            this.tb_sodienthoai.TabIndex = 4;
            // 
            // tb_tenkhachhang
            // 
            this.tb_tenkhachhang.Location = new System.Drawing.Point(205, 37);
            this.tb_tenkhachhang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_tenkhachhang.Name = "tb_tenkhachhang";
            this.tb_tenkhachhang.ReadOnly = true;
            this.tb_tenkhachhang.Size = new System.Drawing.Size(359, 27);
            this.tb_tenkhachhang.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng";
            // 
            // listView2
            // 
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(368, 194);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(566, 303);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 542);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmKhachHang";
            this.Text = "Khách Hàng";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_search_info_khachhang;
        private System.Windows.Forms.TextBox tb_search_telephone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_diachi;
        private System.Windows.Forms.TextBox tb_sodienthoai;
        private System.Windows.Forms.TextBox tb_tenkhachhang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btn_delete;
    }
}