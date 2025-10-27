namespace DoAnQLBanHang_GUI
{
    partial class frmBanHang
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
            this.btn_food = new System.Windows.Forms.Button();
            this.btn_drink = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_diachi = new System.Windows.Forms.TextBox();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.button_add_listview = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btn_inhoadon = new System.Windows.Forms.Button();
            this.btn_deleteListview = new System.Windows.Forms.Button();
            this.dgvMon = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_food
            // 
            this.btn_food.Location = new System.Drawing.Point(-1, 25);
            this.btn_food.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_food.Name = "btn_food";
            this.btn_food.Size = new System.Drawing.Size(90, 29);
            this.btn_food.TabIndex = 0;
            this.btn_food.Text = "Đồ ăn";
            this.btn_food.UseVisualStyleBackColor = true;
            this.btn_food.Click += new System.EventHandler(this.btn_food_Click_1);
            // 
            // btn_drink
            // 
            this.btn_drink.Location = new System.Drawing.Point(104, 25);
            this.btn_drink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_drink.Name = "btn_drink";
            this.btn_drink.Size = new System.Drawing.Size(90, 29);
            this.btn_drink.TabIndex = 1;
            this.btn_drink.Text = "Đồ uống";
            this.btn_drink.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_diachi);
            this.groupBox1.Controls.Add(this.tb_sdt);
            this.groupBox1.Controls.Add(this.tb_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lable1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(646, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(306, 154);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // tb_diachi
            // 
            this.tb_diachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_diachi.Location = new System.Drawing.Point(137, 104);
            this.tb_diachi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.Size = new System.Drawing.Size(147, 21);
            this.tb_diachi.TabIndex = 5;
            // 
            // tb_sdt
            // 
            this.tb_sdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_sdt.Location = new System.Drawing.Point(137, 72);
            this.tb_sdt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(147, 21);
            this.tb_sdt.TabIndex = 4;
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name.Location = new System.Drawing.Point(137, 41);
            this.tb_name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(147, 21);
            this.tb_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Địa Chỉ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Điện Thoại";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(15, 43);
            this.lable1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(113, 15);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Tên Khách Hàng";
            // 
            // button_add_listview
            // 
            this.button_add_listview.Location = new System.Drawing.Point(9, 254);
            this.button_add_listview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_add_listview.Name = "button_add_listview";
            this.button_add_listview.Size = new System.Drawing.Size(122, 19);
            this.button_add_listview.TabIndex = 5;
            this.button_add_listview.Text = "Thêm vào danh sách";
            this.button_add_listview.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 275);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(934, 154);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btn_inhoadon
            // 
            this.btn_inhoadon.Location = new System.Drawing.Point(646, 444);
            this.btn_inhoadon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_inhoadon.Name = "btn_inhoadon";
            this.btn_inhoadon.Size = new System.Drawing.Size(71, 19);
            this.btn_inhoadon.TabIndex = 7;
            this.btn_inhoadon.Text = "In Hóa Đơn";
            this.btn_inhoadon.UseVisualStyleBackColor = true;
            // 
            // btn_deleteListview
            // 
            this.btn_deleteListview.Location = new System.Drawing.Point(9, 444);
            this.btn_deleteListview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_deleteListview.Name = "btn_deleteListview";
            this.btn_deleteListview.Size = new System.Drawing.Size(94, 19);
            this.btn_deleteListview.TabIndex = 8;
            this.btn_deleteListview.Text = "Xóa Món";
            this.btn_deleteListview.UseVisualStyleBackColor = true;
            this.btn_deleteListview.Click += new System.EventHandler(this.btn_deleteListview_Click_1);
            // 
            // dgvMon
            // 
            this.dgvMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMon.Location = new System.Drawing.Point(9, 58);
            this.dgvMon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMon.Name = "dgvMon";
            this.dgvMon.RowHeadersWidth = 51;
            this.dgvMon.RowTemplate.Height = 24;
            this.dgvMon.Size = new System.Drawing.Size(626, 184);
            this.dgvMon.TabIndex = 2;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 472);
            this.Controls.Add(this.btn_deleteListview);
            this.Controls.Add(this.btn_inhoadon);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_add_listview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvMon);
            this.Controls.Add(this.btn_drink);
            this.Controls.Add(this.btn_food);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmBanHang";
            this.Text = "Bán Hàng";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_food;
        private System.Windows.Forms.Button btn_drink;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_diachi;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Button button_add_listview;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btn_inhoadon;
        private System.Windows.Forms.Button btn_deleteListview;
        private System.Windows.Forms.DataGridView dgvMon;
    }
}