namespace HeThongQuanLyNgheNhac.DoanhThu
{
    partial class QLGoiDangKy
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGVGoiDK = new System.Windows.Forms.DataGridView();
            this.txt_tenGoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_gia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_moTa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_thoigian = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.them = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.txt_idGoi = new System.Windows.Forms.TextBox();
            this.lb_idGoi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGoiDK)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVGoiDK
            // 
            this.DGVGoiDK.AllowUserToOrderColumns = true;
            this.DGVGoiDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGoiDK.Location = new System.Drawing.Point(790, 229);
            this.DGVGoiDK.Name = "DGVGoiDK";
            this.DGVGoiDK.RowHeadersWidth = 82;
            this.DGVGoiDK.RowTemplate.Height = 33;
            this.DGVGoiDK.Size = new System.Drawing.Size(1081, 397);
            this.DGVGoiDK.TabIndex = 0;
            this.DGVGoiDK.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGoiDK_CellClick);
            this.DGVGoiDK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.DGVGoiDK.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGoiDK_RowEnter);
            // 
            // txt_tenGoi
            // 
            this.txt_tenGoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenGoi.Location = new System.Drawing.Point(173, 305);
            this.txt_tenGoi.Name = "txt_tenGoi";
            this.txt_tenGoi.Size = new System.Drawing.Size(555, 50);
            this.txt_tenGoi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên gói";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 45);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giá";
            // 
            // txt_gia
            // 
            this.txt_gia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_gia.Location = new System.Drawing.Point(173, 483);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.Size = new System.Drawing.Size(555, 50);
            this.txt_gia.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 572);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 45);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mô tả";
            // 
            // txt_moTa
            // 
            this.txt_moTa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_moTa.Location = new System.Drawing.Point(173, 572);
            this.txt_moTa.Name = "txt_moTa";
            this.txt_moTa.Size = new System.Drawing.Size(555, 50);
            this.txt_moTa.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 45);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thời gian";
            // 
            // dateTimePicker_thoigian
            // 
            this.dateTimePicker_thoigian.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_thoigian.Location = new System.Drawing.Point(173, 394);
            this.dateTimePicker_thoigian.Name = "dateTimePicker_thoigian";
            this.dateTimePicker_thoigian.Size = new System.Drawing.Size(555, 50);
            this.dateTimePicker_thoigian.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(782, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 45);
            this.label5.TabIndex = 11;
            this.label5.Text = "Danh sách Gói đăng ký";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(551, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(772, 86);
            this.label6.TabIndex = 12;
            this.label6.Text = "QUẢN LÝ GÓI ĐĂNG KÝ ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // them
            // 
            this.them.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.them.Location = new System.Drawing.Point(790, 690);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(132, 53);
            this.them.TabIndex = 13;
            this.them.Text = "THÊM";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // sua
            // 
            this.sua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sua.Location = new System.Drawing.Point(1049, 690);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(132, 53);
            this.sua.TabIndex = 14;
            this.sua.Text = "SỬA";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // xoa
            // 
            this.xoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoa.Location = new System.Drawing.Point(1308, 690);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(132, 53);
            this.xoa.TabIndex = 15;
            this.xoa.Text = "XOÁ";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.Location = new System.Drawing.Point(1567, 690);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(293, 53);
            this.clear.TabIndex = 16;
            this.clear.Text = "CLEAR ALL DATA";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1658, 174);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(213, 50);
            this.btn_search.TabIndex = 17;
            this.btn_search.Text = "TÌM KIẾM";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.Location = new System.Drawing.Point(1230, 173);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(422, 50);
            this.txt_search.TabIndex = 18;
            // 
            // txt_idGoi
            // 
            this.txt_idGoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idGoi.Location = new System.Drawing.Point(173, 229);
            this.txt_idGoi.Name = "txt_idGoi";
            this.txt_idGoi.Size = new System.Drawing.Size(555, 50);
            this.txt_idGoi.TabIndex = 19;
            // 
            // lb_idGoi
            // 
            this.lb_idGoi.AutoSize = true;
            this.lb_idGoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_idGoi.Location = new System.Drawing.Point(15, 229);
            this.lb_idGoi.Name = "lb_idGoi";
            this.lb_idGoi.Size = new System.Drawing.Size(109, 45);
            this.lb_idGoi.TabIndex = 20;
            this.lb_idGoi.Text = "ID Gói";
            // 
            // QLGoiDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.txt_idGoi);
            this.Controls.Add(this.lb_idGoi);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.them);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_thoigian);
            this.Controls.Add(this.txt_moTa);
            this.Controls.Add(this.txt_gia);
            this.Controls.Add(this.txt_tenGoi);
            this.Controls.Add(this.DGVGoiDK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QLGoiDangKy";
            this.Size = new System.Drawing.Size(1874, 900);
            this.Load += new System.EventHandler(this.QLGoiDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGoiDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVGoiDK;
        private System.Windows.Forms.TextBox txt_tenGoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_gia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_moTa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_thoigian;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.TextBox txt_idGoi;
        private System.Windows.Forms.Label lb_idGoi;
    }
}
