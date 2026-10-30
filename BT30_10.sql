CREATE DATABASE CafePOSDB;

USE CafePOSDB;
CREATE TABLE BanAn (
    MaBan INT AUTO_INCREMENT PRIMARY KEY, 
    TenBan VARCHAR(50), 
    TrangThai VARCHAR(20) DEFAULT 'Trống'
);

CREATE TABLE DanhMuc (
    MaDanhMuc INT AUTO_INCREMENT PRIMARY KEY, 
    TenDanhMuc VARCHAR(100)
);

CREATE TABLE MonAn (
    MaMon INT AUTO_INCREMENT PRIMARY KEY, 
    TenMon VARCHAR(100), 
    MaDanhMuc INT, 
    DonGia DECIMAL(18,2),
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
);

CREATE TABLE HoaDon (
    MaHoaDon INT AUTO_INCREMENT PRIMARY KEY, 
    MaBan INT, 
    GioVao DATETIME DEFAULT CURRENT_TIMESTAMP, 
    GioRa DATETIME, 
    TongTien DECIMAL(18,2), 
    TrangThai BOOLEAN DEFAULT 0,
    FOREIGN KEY (MaBan) REFERENCES BanAn(MaBan)
);

CREATE TABLE ChiTietHoaDon (
    MaHoaDon INT, 
    MaMon INT, 
    SoLuong INT, 
    DonGia DECIMAL(18,2),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaMon) REFERENCES MonAn(MaMon)
);


INSERT INTO BanAn(TenBan) VALUES ('Bàn 01'), ('Bàn 02'), ('Bàn 03'), ('Bàn 04');

INSERT INTO DanhMuc(TenDanhMuc) VALUES ('Cà phê'), ('Trà & Trà Sữa'), ('Nước Ép & Sinh Tố'), ('Đồ Ăn Nhẹ');

INSERT INTO MonAn(TenMon, MaDanhMuc, DonGia) VALUES 
('Cafe Đen', 1, 20000), ('Cafe Sữa', 1, 25000), ('Bạc Xỉu', 1, 30000),
('Trà Đào Cam Sả', 2, 35000), ('Trà Sữa Truyền Thống', 2, 30000),
('Nước Ép Dưa Hấu', 3, 40000), ('Sinh Tố Bơ', 3, 45000),
('Hướng Dương', 4, 15000), ('Khô Gà Lá Chanh', 4, 25000);

CREATE DATABASE HotelDB;
GO
USE HotelDB;
GO

CREATE TABLE Phong (
    SoPhong VARCHAR(10) PRIMARY KEY,
    LoaiPhong VARCHAR(50),
    GiaTheoGio DECIMAL(18,2),
    TrangThai VARCHAR(30) DEFAULT 'Trống'
);


CREATE TABLE KhachHang (
    MaKH INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE NOT NULL,
    SoDienThoai VARCHAR(15)
);

CREATE TABLE DichVu (
    MaDV INT AUTO_INCREMENT PRIMARY KEY,
    TenDV VARCHAR(100),
    DonGia DECIMAL(18,2)
);

CREATE TABLE PhieuDatPhong (
    MaPhieu INT AUTO_INCREMENT PRIMARY KEY,
    SoPhong VARCHAR(10),
    MaKH INT,
    NgayNhanPhong DATETIME DEFAULT CURRENT_TIMESTAMP,
    NgayTraPhong DATETIME NULL,
    TongTienThanhToan DECIMAL(18,2) NULL,
    FOREIGN KEY (SoPhong) REFERENCES Phong(SoPhong),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);

CREATE TABLE SuDungDichVu (
    MaPhieu INT,
    MaDV INT,
    SoLuong INT,
    ThoiGian DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (MaPhieu, MaDV),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuDatPhong(MaPhieu),
    FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);


INSERT INTO Phong (SoPhong, LoaiPhong, GiaTheoGio, TrangThai) VALUES 
('P101', 'Đơn', 50000, 'Trống'), ('P102', 'Đôi', 80000, 'Trống'), ('P201', 'VIP', 150000, 'Trống');

INSERT INTO DichVu (TenDV, DonGia) VALUES 
('Nước suối', 10000), ('Giặt là', 30000), ('Mì tôm trứng', 25000);


select * from DichVu