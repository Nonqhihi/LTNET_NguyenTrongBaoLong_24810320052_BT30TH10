namespace BT5._1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpBanAn = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cboMonAn = new ComboBox();
            nudSoLuong = new NumericUpDown();
            lblStatus = new Label();
            btnThemMon = new Button();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            cboDanhMuc = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            SuspendLayout();
            // 
            // flpBanAn
            // 
            flpBanAn.AutoScroll = true;
            flpBanAn.BorderStyle = BorderStyle.FixedSingle;
            flpBanAn.FlowDirection = FlowDirection.TopDown;
            flpBanAn.Location = new Point(12, 12);
            flpBanAn.Name = "flpBanAn";
            flpBanAn.Size = new Size(200, 217);
            flpBanAn.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(308, 24);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 1;
            label1.Text = "Danh mục:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 74);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Món ăn:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(308, 125);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Số lượng:";
            // 
            // cboMonAn
            // 
            cboMonAn.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonAn.FormattingEnabled = true;
            cboMonAn.Location = new Point(430, 74);
            cboMonAn.Name = "cboMonAn";
            cboMonAn.Size = new Size(121, 23);
            cboMonAn.TabIndex = 5;
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(430, 123);
            nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(121, 23);
            nudSoLuong.TabIndex = 6;
            nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 15F);
            lblStatus.Location = new Point(430, 214);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 28);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Sẵn sàng";
            // 
            // btnThemMon
            // 
            btnThemMon.Location = new Point(430, 166);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(75, 23);
            btnThemMon.TabIndex = 8;
            btnThemMon.Text = "Thêm món";
            btnThemMon.UseVisualStyleBackColor = true;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 20F);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(308, 247);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(221, 37);
            lblTongTien.TabIndex = 9;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(430, 303);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(75, 23);
            btnThanhToan.TabIndex = 10;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // cboDanhMuc
            // 
            cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanhMuc.FormattingEnabled = true;
            cboDanhMuc.Location = new Point(430, 24);
            cboDanhMuc.Name = "cboDanhMuc";
            cboDanhMuc.Size = new Size(121, 23);
            cboDanhMuc.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboDanhMuc);
            Controls.Add(btnThanhToan);
            Controls.Add(lblTongTien);
            Controls.Add(btnThemMon);
            Controls.Add(lblStatus);
            Controls.Add(nudSoLuong);
            Controls.Add(cboMonAn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flpBanAn);
            Name = "Form1";
            Text = "POS Cafe System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpBanAn;
        private Button btnBan1;
        private Button btnBan2;
        private Button btnBan3;
        private Button btnBan4;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboMonAn;
        private NumericUpDown nudSoLuong;
        private Label lblStatus;
        private Button btnThemMon;
        private Label lblTongTien;
        private Button btnThanhToan;
        private Label lblDanhMuc;
        private Label lblSoLuong;
        private ComboBox comboBox3;
        private ComboBox cboDanhMuc;
    }
}
