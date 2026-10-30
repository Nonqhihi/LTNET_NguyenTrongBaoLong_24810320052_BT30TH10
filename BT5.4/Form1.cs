using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BT5._4
{
    public partial class Form1 : Form
    {
         private string connStr = "Server=localhost;Database=HotelDB;Uid=root;Pwd=long1910;";
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            btnNhanPhong.Click += btnNhanPhong_Click;
            btnDichVu.Click += btnDichVu_Click;
            btnThanhToan.Click += btnThanhToan_Click;
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            if (cboPhong.SelectedValue == null || string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng và nhập đủ CCCD!");
                return;
            }

            string soPhong = cboPhong.SelectedValue.ToString();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmdCheckKH = new MySqlCommand("SELECT MaKH FROM KhachHang WHERE CCCD = @CCCD", conn);
                cmdCheckKH.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                object objMaKH = cmdCheckKH.ExecuteScalar();
                int maKH;

                if (objMaKH != null)
                {
                    maKH = Convert.ToInt32(objMaKH);
                }
                else
                {
                    MySqlCommand cmdInsertKH = new MySqlCommand("INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES (@HoTen, @CCCD, @SDT); SELECT LAST_INSERT_ID();", conn);
                    cmdInsertKH.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmdInsertKH.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
                    cmdInsertKH.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    maKH = Convert.ToInt32(cmdInsertKH.ExecuteScalar());
                }

                MySqlCommand cmdPhieu = new MySqlCommand("INSERT INTO PhieuDatPhong (SoPhong, MaKH) VALUES (@SoPhong, @MaKH)", conn);
                cmdPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                cmdPhieu.Parameters.AddWithValue("@MaKH", maKH);
                cmdPhieu.ExecuteNonQuery();

                MySqlCommand cmdPhong = new MySqlCommand("UPDATE Phong SET TrangThai = 'Đang ở' WHERE SoPhong = @SoPhong", conn);
                cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                cmdPhong.ExecuteNonQuery();

                lblStatus.Text = $"Trạng thái: Nhận phòng {soPhong} thành công!";
                LoadComboBoxData();
            }
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            string soPhong = Microsoft.VisualBasic.Interaction.InputBox("Nhập số phòng cần gọi dịch vụ:", "Gọi dịch vụ", "");
            if (string.IsNullOrWhiteSpace(soPhong)) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmdPhieu = new MySqlCommand("SELECT MaPhieu FROM PhieuDatPhong WHERE SoPhong = @SoPhong AND NgayTraPhong IS NULL", conn);
                cmdPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                object maPhieu = cmdPhieu.ExecuteScalar();

                if (maPhieu == null)
                {
                    MessageBox.Show("Phòng chưa có người ở!");
                    return;
                }

                MySqlCommand cmdDV = new MySqlCommand("INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong) VALUES (@MaPhieu, @MaDV, @SoLuong)", conn);
                cmdDV.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmdDV.Parameters.AddWithValue("@MaDV", cboDichVu.SelectedValue);
                cmdDV.Parameters.AddWithValue("@SoLuong", nudSoLuong.Value);
                cmdDV.ExecuteNonQuery();

                lblStatus.Text = $"Trạng thái: Thêm dịch vụ cho phòng {soPhong} thành công!";
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string soPhong = Microsoft.VisualBasic.Interaction.InputBox("Nhập số phòng cần thanh toán:", "Thanh toán", "");
            if (string.IsNullOrWhiteSpace(soPhong)) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmdInfo = new MySqlCommand(@"
                    SELECT p.MaPhieu, p.NgayNhanPhong, ph.GiaTheoGio 
                    FROM PhieuDatPhong p 
                    JOIN Phong ph ON p.SoPhong = ph.SoPhong 
                    WHERE p.SoPhong = @SoPhong AND p.NgayTraPhong IS NULL", conn);
                cmdInfo.Parameters.AddWithValue("@SoPhong", soPhong);

                int maPhieu = 0;
                decimal giaGio = 0;
                DateTime ngayNhan = DateTime.Now;

                using (MySqlDataReader rd = cmdInfo.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        maPhieu = Convert.ToInt32(rd["MaPhieu"]);
                        giaGio = Convert.ToDecimal(rd["GiaTheoGio"]);
                        ngayNhan = Convert.ToDateTime(rd["NgayNhanPhong"]);
                    }
                }

                if (maPhieu == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu chưa thanh toán cho phòng này!");
                    return;
                }

                double soGio = Math.Ceiling((DateTime.Now - ngayNhan).TotalHours);
                if (soGio < 1) soGio = 1;
                decimal tienPhong = (decimal)soGio * giaGio;

                MySqlCommand cmdDichVu = new MySqlCommand(@"
                    SELECT IFNULL(SUM(sd.SoLuong * dv.DonGia), 0) 
                    FROM SuDungDichVu sd JOIN DichVu dv ON sd.MaDV = dv.MaDV 
                    WHERE sd.MaPhieu = @MaPhieu", conn);
                cmdDichVu.Parameters.AddWithValue("@MaPhieu", maPhieu);
                decimal tienDichVu = Convert.ToDecimal(cmdDichVu.ExecuteScalar());

                decimal tongTien = tienPhong + tienDichVu;

                MySqlCommand cmdUpdPhieu = new MySqlCommand("UPDATE PhieuDatPhong SET NgayTraPhong = CURRENT_TIMESTAMP, TongTienThanhToan = @Tong WHERE MaPhieu = @MaPhieu", conn);
                cmdUpdPhieu.Parameters.AddWithValue("@Tong", tongTien);
                cmdUpdPhieu.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmdUpdPhieu.ExecuteNonQuery();

                MySqlCommand cmdUpdPhong = new MySqlCommand("UPDATE Phong SET TrangThai = 'Trống' WHERE SoPhong = @SoPhong", conn);
                cmdUpdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                cmdUpdPhong.ExecuteNonQuery();

                lblTongTien.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
                lblStatus.Text = $"Trạng thái: Trả phòng {soPhong} hoàn tất.";
                LoadComboBoxData();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }
        private void LoadComboBoxData()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlDataAdapter daPhong = new MySqlDataAdapter("SELECT SoPhong FROM Phong WHERE TrangThai = 'Trống'", conn);
                DataTable dtPhong = new DataTable();
                daPhong.Fill(dtPhong);
                cboPhong.DataSource = dtPhong;
                cboPhong.DisplayMember = "SoPhong";
                cboPhong.ValueMember = "SoPhong";

                MySqlDataAdapter daLoai = new MySqlDataAdapter("SELECT DISTINCT LoaiPhong FROM Phong", conn);
                DataTable dtLoai = new DataTable();
                daLoai.Fill(dtLoai);
                cboLoaiPhong.DataSource = dtLoai;
                cboLoaiPhong.DisplayMember = "LoaiPhong";
                cboLoaiPhong.ValueMember = "LoaiPhong";

                MySqlDataAdapter daDV = new MySqlDataAdapter("SELECT MaDV, TenDV FROM DichVu", conn);
                DataTable dtDV = new DataTable();
                daDV.Fill(dtDV);
                cboDichVu.DataSource = dtDV;
                cboDichVu.DisplayMember = "TenDV";
                cboDichVu.ValueMember = "MaDV";
            }
        }
    }
}
