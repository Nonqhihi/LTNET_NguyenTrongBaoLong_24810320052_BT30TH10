namespace BT5._4
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblTongTien = new Label();
            lblStatus = new Label();
            cboPhong = new ComboBox();
            cboLoaiPhong = new ComboBox();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtCCCD = new TextBox();
            cboDichVu = new ComboBox();
            btnNhanPhong = new Button();
            btnDichVu = new Button();
            btnThanhToan = new Button();
            nudSoLuong = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 13);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "Chọn phòng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 48);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Lọc loại:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 115);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 2;
            label3.Text = "Họ tên KH:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(358, 115);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "CCCD:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 150);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 4;
            label5.Text = "Số điện thoại:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 218);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 5;
            label6.Text = "Chọn dịch vụ:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 250);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 6;
            label7.Text = "Số lượng: ";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 20F);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(25, 317);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(221, 37);
            lblTongTien.TabIndex = 7;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.Location = new Point(25, 365);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(141, 19);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Trạng thái: Sẵn sàng...";
            // 
            // cboPhong
            // 
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.FormattingEnabled = true;
            cboPhong.Items.AddRange(new object[] { "1" });
            cboPhong.Location = new Point(133, 5);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(121, 23);
            cboPhong.TabIndex = 9;
            // 
            // cboLoaiPhong
            // 
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiPhong.FormattingEnabled = true;
            cboLoaiPhong.Items.AddRange(new object[] { "2" });
            cboLoaiPhong.Location = new Point(133, 45);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(121, 23);
            cboLoaiPhong.TabIndex = 10;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(133, 107);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(121, 23);
            txtHoTen.TabIndex = 11;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(133, 147);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(121, 23);
            txtSDT.TabIndex = 12;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(432, 112);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(121, 23);
            txtCCCD.TabIndex = 13;
            // 
            // cboDichVu
            // 
            cboDichVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDichVu.FormattingEnabled = true;
            cboDichVu.Items.AddRange(new object[] { "3" });
            cboDichVu.Location = new Point(133, 215);
            cboDichVu.Name = "cboDichVu";
            cboDichVu.Size = new Size(121, 23);
            cboDichVu.TabIndex = 14;
            // 
            // btnNhanPhong
            // 
            btnNhanPhong.Location = new Point(432, 159);
            btnNhanPhong.Name = "btnNhanPhong";
            btnNhanPhong.Size = new Size(121, 25);
            btnNhanPhong.TabIndex = 15;
            btnNhanPhong.Text = "Nhận Phòng";
            btnNhanPhong.UseVisualStyleBackColor = true;
            btnNhanPhong.Click += btnNhanPhong_Click;
            // 
            // btnDichVu
            // 
            btnDichVu.Location = new Point(431, 242);
            btnDichVu.Name = "btnDichVu";
            btnDichVu.Size = new Size(122, 23);
            btnDichVu.TabIndex = 16;
            btnDichVu.Text = "Xác nhận";
            btnDichVu.UseVisualStyleBackColor = true;
            btnDichVu.Click += btnDichVu_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(431, 331);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(122, 23);
            btnThanhToan.TabIndex = 17;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // nudSoLuong
            // 
            nudSoLuong.Location = new Point(133, 250);
            nudSoLuong.Name = "nudSoLuong";
            nudSoLuong.Size = new Size(120, 23);
            nudSoLuong.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nudSoLuong);
            Controls.Add(btnThanhToan);
            Controls.Add(btnDichVu);
            Controls.Add(btnNhanPhong);
            Controls.Add(cboDichVu);
            Controls.Add(txtCCCD);
            Controls.Add(txtSDT);
            Controls.Add(txtHoTen);
            Controls.Add(cboLoaiPhong);
            Controls.Add(cboPhong);
            Controls.Add(lblStatus);
            Controls.Add(lblTongTien);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Quản lý Check-in / Check-out Khách sạn";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblTongTien;
        private Label lblStatus;
        private ComboBox cboPhong;
        private ComboBox cboLoaiPhong;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtCCCD;
        private ComboBox cboDichVu;
        private Button btnNhanPhong;
        private Button btnDichVu;
        private Button btnThanhToan;
        private NumericUpDown nudSoLuong;
    }
}
