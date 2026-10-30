using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BT5._1
{
    public partial class Form1 : Form
    {
        private string connStr = "Server=localhost;Database=CafePOSDB;Uid=root;Pwd=long1910;";
        private int banDangChon = -1;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            cboDanhMuc.SelectedIndexChanged += CboDanhMuc_SelectedIndexChanged;
            btnThemMon.Click += BtnThemMon_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSoDoBan();
            LoadDanhMuc();
        }
        private void LoadSoDoBan()
        {
            flpBanAn.Controls.Clear();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MaBan, TenBan, TrangThai FROM BanAn", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int maBan = reader.GetInt32("MaBan");
                        string tenBan = reader.GetString("TenBan");
                        string trangThai = reader.GetString("TrangThai");

                        Button btn = new Button
                        {
                            Text = $"{tenBan}\n{trangThai}",
                            Width = 90,
                            Height = 90,
                            Tag = maBan,
                            BackColor = trangThai == "Trống" ? Color.LightGreen : Color.LightCoral,
                            FlatStyle = FlatStyle.Flat
                        };

                        btn.Click += BtnBan_Click;
                        flpBanAn.Controls.Add(btn);
                    }
                }
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            banDangChon = Convert.ToInt32(btn.Tag);
            if (lblStatus != null) lblStatus.Text = $"Đang phục vụ: {btn.Text.Split('\n')[0]}";
            CapNhatTongTien();
        }

        private void LoadDanhMuc()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM DanhMuc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboDanhMuc.DataSource = dt;
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
            }
        }
        private void CboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedValue != null && int.TryParse(cboDanhMuc.SelectedValue.ToString(), out int maDM))
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM MonAn WHERE MaDanhMuc = @MaDM", conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaDM", maDM);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboMonAn.DataSource = dt;
                    cboMonAn.DisplayMember = "TenMon";
                    cboMonAn.ValueMember = "MaMon";
                }
            }
        }

        private void BtnThemMon_Click(object sender, EventArgs e)
        {
            if (banDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMonAn.SelectedValue == null) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                int maHoaDon = LayHoacTaoHoaDonMoi(conn, banDangChon);
                int maMon = Convert.ToInt32(cboMonAn.SelectedValue);
                int soLuong = (int)nudSoLuong.Value;

                string sqlInsert = @"
                    INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) 
                    SELECT @MaHD, @MaMon, @SL, DonGia FROM MonAn WHERE MaMon = @MaMon";

                MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn);
                cmdInsert.Parameters.AddWithValue("@MaHD", maHoaDon);
                cmdInsert.Parameters.AddWithValue("@MaMon", maMon);
                cmdInsert.Parameters.AddWithValue("@SL", soLuong);
                cmdInsert.ExecuteNonQuery();

                MySqlCommand cmdUpdateBan = new MySqlCommand("UPDATE BanAn SET TrangThai = 'Có khách' WHERE MaBan = @MaBan", conn);
                cmdUpdateBan.Parameters.AddWithValue("@MaBan", banDangChon);
                cmdUpdateBan.ExecuteNonQuery();

                if (lblStatus != null) lblStatus.Text = $"Đã lưu {soLuong} x {cboMonAn.Text} vào DB!";
            }

            LoadSoDoBan();
            CapNhatTongTien();
        }

        private int LayHoacTaoHoaDonMoi(MySqlConnection conn, int maBan)
        {
            MySqlCommand cmdLayHD = new MySqlCommand("SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0", conn);
            cmdLayHD.Parameters.AddWithValue("@MaBan", maBan);
            object kq = cmdLayHD.ExecuteScalar();

            if (kq != null) return Convert.ToInt32(kq);

            MySqlCommand cmdTaoHD = new MySqlCommand("INSERT INTO HoaDon (MaBan, GioVao, TrangThai) VALUES (@MaBan, NOW(), 0); SELECT LAST_INSERT_ID();", conn);
            cmdTaoHD.Parameters.AddWithValue("@MaBan", maBan);
            return Convert.ToInt32(cmdTaoHD.ExecuteScalar());
        }

        private void CapNhatTongTien()
        {
            if (banDangChon == -1) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT SUM(ct.SoLuong * ct.DonGia) 
                    FROM ChiTietHoaDon ct 
                    JOIN HoaDon hd ON ct.MaHoaDon = hd.MaHoaDon 
                    WHERE hd.MaBan = @MaBan AND hd.TrangThai = 0";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaBan", banDangChon);
                object tongTien = cmd.ExecuteScalar();

                if (tongTien != DBNull.Value && tongTien != null)
                {
                    if (lblTongTien != null) lblTongTien.Text = $"Tổng tiền: {Convert.ToDecimal(tongTien):N0} VNĐ";
                }
                else
                {
                    if (lblTongTien != null) lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                }
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (banDangChon == -1) return;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlHD = @"
                        UPDATE HoaDon 
                        SET TrangThai = 1, GioRa = NOW(), 
                            TongTien = (SELECT SUM(SoLuong * DonGia) FROM ChiTietHoaDon WHERE MaHoaDon = HoaDon.MaHoaDon) 
                        WHERE MaBan = @MaBan AND TrangThai = 0";
                    MySqlCommand cmdHD = new MySqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@MaBan", banDangChon);
                    int rows = cmdHD.ExecuteNonQuery();

                    if (rows == 0) throw new Exception("Bàn này chưa có hóa đơn để thanh toán!");

                    string sqlBan = "UPDATE BanAn SET TrangThai = 'Trống' WHERE MaBan = @MaBan";
                    MySqlCommand cmdBan = new MySqlCommand(sqlBan, conn, trans);
                    cmdBan.Parameters.AddWithValue("@MaBan", banDangChon);
                    cmdBan.ExecuteNonQuery();

                    trans.Commit();

                    if (lblStatus != null) lblStatus.Text = "Thanh toán thành công!";
                    if (lblTongTien != null) lblTongTien.Text = "Tổng tiền: 0 VNĐ";
                    banDangChon = -1;
                    LoadSoDoBan();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

