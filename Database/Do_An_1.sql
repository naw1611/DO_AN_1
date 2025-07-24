<<<<<<< HEAD
﻿CREATE DATABASE QLPhongKham;
GO
USE QLPhongKham
GO

-- Bảng nhân viên
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    SoDienThoai CHAR(10) CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    DiaChi NVARCHAR(200),
    NgayVaoLam DATE DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1
);

-- Bảng bác sĩ
CREATE TABLE BacSi (
    MaBS INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100) NOT NULL,
    BangCap NVARCHAR(200),
    SoDienThoai CHAR(10) CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    GioiThieu NVARCHAR(MAX),
    TrangThai BIT DEFAULT 1
);

-- Bảng bệnh nhân
CREATE TABLE BenhNhan (
    MaBN INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh CHAR(1) CHECK (GioiTinh IN ('M','F')) DEFAULT 'M',
    SoDienThoai CHAR(10) CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    DiaChi NVARCHAR(200),
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    TienSuBenh NVARCHAR(MAX),
    NgheNghiep NVARCHAR(100),
    NgayDangKy DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1
);

-- Bảng loại thuốc (định nghĩa trước vì được tham chiếu bởi bảng Thuoc)
CREATE TABLE LoaiThuoc (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(200)
);

-- Bảng danh mục thuốc (định nghĩa trước vì được tham chiếu bởi bảng Thuoc)
CREATE TABLE DanhMucThuoc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    MaLoai INT FOREIGN KEY REFERENCES LoaiThuoc(MaLoai),
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(200)
);

-- Bảng thuốc (đã tích hợp khóa ngoại từ ALTER TABLE)
CREATE TABLE Thuoc (
    MaThuoc INT IDENTITY(1,1) PRIMARY KEY,
    TenThuoc NVARCHAR(100) NOT NULL,
    DonViTinh NVARCHAR(20) NOT NULL,
    DonGiaBan DECIMAL(12,2) NOT NULL CHECK (DonGiaBan > 0),
    SoLuongTon INT NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    HanSuDung DATE NOT NULL,
    NhaSanXuat NVARCHAR(100),
    CachDung NVARCHAR(200),
    MaLoai INT NULL FOREIGN KEY REFERENCES LoaiThuoc(MaLoai),
    MaDanhMuc INT NULL FOREIGN KEY REFERENCES DanhMucThuoc(MaDanhMuc),

    INDEX IX_TenThuoc (TenThuoc)
);

-- Trigger kiểm tra hạn sử dụng thuốc
CREATE TRIGGER trg_KiemTraHanSuDung_Thuoc
ON Thuoc
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE HanSuDung <= CAST(GETDATE() AS DATE))
    BEGIN
        RAISERROR(N'Hạn sử dụng phải lớn hơn ngày hiện tại!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


-- Bảng lịch khám 
CREATE TABLE LichKham (
    MaLichKham INT IDENTITY(1,1) PRIMARY KEY,
    MaBN INT NOT NULL FOREIGN KEY REFERENCES BenhNhan(MaBN),
    MaBS INT NOT NULL FOREIGN KEY REFERENCES BacSi(MaBS),
    NgayKham DATE NOT NULL,
    GioKham TIME NOT NULL,
    ThoiGianDuKien INT DEFAULT 30, -- phút
    LyDo NVARCHAR(500),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đặt lịch'
        CHECK (TrangThai IN (N'Đặt lịch', N'Xác nhận', N'Hoàn tất', N'Hủy', N'Không đến')),
    NgayTao DATETIME DEFAULT GETDATE(),
    GhiChu NVARCHAR(MAX),

    INDEX IX_LichKham_Date (NgayKham),
    INDEX IX_LichKham_Patient (MaBN),
    INDEX IX_LichKham_Doctor (MaBS)
);

-- Bảng hồ sơ khám bệnh
CREATE TABLE HoSoKham (
    MaHoSo INT IDENTITY(1,1) PRIMARY KEY,
    MaLichKham INT NOT NULL FOREIGN KEY REFERENCES LichKham(MaLichKham),
    TrieuChung NVARCHAR(500) NOT NULL,
    ChanDoan NVARCHAR(500),
    LoiDan NVARCHAR(500),
    NgayTaiKham DATE,
    DaThanhToan BIT DEFAULT 0
);

-- Bảng đơn thuốc
CREATE TABLE DonThuoc (
    MaDonThuoc INT IDENTITY(1,1) PRIMARY KEY,
    MaHoSo INT NOT NULL FOREIGN KEY REFERENCES HoSoKham(MaHoSo),
    MaThuoc INT NOT NULL FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    LieuDung NVARCHAR(200) NOT NULL,
    Sang INT DEFAULT 1,
    Trua INT DEFAULT 0,
    Chieu INT DEFAULT 1,
    Toi INT DEFAULT 0,
    SoNgay INT DEFAULT 7 CHECK (SoNgay > 0),
    GhiChu NVARCHAR(200)
);

-- Bảng hóa đơn 
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaLichKham INT NOT NULL FOREIGN KEY REFERENCES LichKham(MaLichKham),
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaBenhNhan INT NOT NULL FOREIGN KEY REFERENCES BenhNhan(MaBN),
    NgayTao DATETIME DEFAULT GETDATE(),
    TienKham DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienThuoc DECIMAL(18,2) NOT NULL DEFAULT 0,
    GiamGia DECIMAL(18,2) DEFAULT 0,
    TongTien AS (TienKham + TienThuoc - GiamGia) PERSISTED,
    HinhThucThanhToan NVARCHAR(50) DEFAULT N'Tiền mặt',
    DaThanhToan BIT DEFAULT 0,
    GhiChu NVARCHAR(MAX),

    INDEX IX_HoaDon_Date (NgayTao),
    INDEX IX_HoaDon_Patient (MaBenhNhan)
);

-- Bảng phiếu nhập thuốc
CREATE TABLE PhieuNhapThuoc (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATETIME DEFAULT GETDATE(),
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    GhiChu NVARCHAR(500),
    TrangThai NVARCHAR(20) DEFAULT N'Đã nhập' CHECK (TrangThai IN (N'Đã nhập', N'Hủy')),
    TongTien DECIMAL(18,2) DEFAULT 0
);

-- Chi tiết phiếu nhập thuốc
CREATE TABLE CT_PhieuNhap (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT NOT NULL FOREIGN KEY REFERENCES PhieuNhapThuoc(MaPhieuNhap),
    MaThuoc INT NOT NULL FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuongNhap INT NOT NULL CHECK (SoLuongNhap > 0),
    DonGiaNhap DECIMAL(18,2) NOT NULL CHECK (DonGiaNhap > 0),
    ThanhTien AS (SoLuongNhap * DonGiaNhap) PERSISTED
);

-- Lịch sử nhập thuốc
CREATE TABLE LichSuNhapThuoc (
    MaLichSu INT IDENTITY(1,1) PRIMARY KEY,
    MaThuoc INT NOT NULL FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuongThayDoi INT NOT NULL,
    LoaiThayDoi NVARCHAR(50) NOT NULL CHECK (LoaiThayDoi IN (N'Nhập kho', N'Hủy nhập')),
    NgayThayDoi DATETIME DEFAULT GETDATE(),
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    GhiChu NVARCHAR(300)
);

-- Bảng vai trò (định nghĩa trước vì được tham chiếu bởi bảng TaiKhoan)
CREATE TABLE VaiTro (
    MaVaiTro INT IDENTITY(1,1) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE,
    MoTa NVARCHAR(200)
);

-- Bảng quyền (định nghĩa trước để tham chiếu trong VaiTro_Quyen)
CREATE TABLE Quyen (
    MaQuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenQuyen NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(300)
);

-- Bảng phân quyền
CREATE TABLE VaiTro_Quyen (
    MaVaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(MaVaiTro),
    MaQuyen INT NOT NULL FOREIGN KEY REFERENCES Quyen(MaQuyen),
    PRIMARY KEY (MaVaiTro, MaQuyen)
);

-- Bảng tài khoản (đã tích hợp khóa ngoại từ ALTER TABLE)
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE CHECK (LEN(TenDangNhap) >= 5),
    MatKhau VARCHAR(100) NOT NULL CHECK (LEN(MatKhau) >= 8),
    VaiTro NVARCHAR(20) NOT NULL CHECK (VaiTro IN (N'Quản trị', N'Bác sĩ', N'Nhân viên', N'Kế toán')),
    MaNhanVien INT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaBacSi INT NULL FOREIGN KEY REFERENCES BacSi(MaBS),
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    LanDangNhapCuoi DATETIME,
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE(),
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(MaVaiTro),

    CONSTRAINT CK_Account_Type CHECK (
        (VaiTro = N'Bác sĩ' AND MaBacSi IS NOT NULL) OR
        (VaiTro = N'Nhân viên' AND MaNhanVien IS NOT NULL) OR
        (VaiTro IN (N'Quản trị', N'Kế toán'))
    ),
    INDEX IX_TaiKhoan_Username (TenDangNhap)
);

-- Bảng nhật ký hệ thống
CREATE TABLE NhatKyHeThong (
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    MaTaiKhoan INT NULL FOREIGN KEY REFERENCES TaiKhoan(MaTaiKhoan),
    HanhDong NVARCHAR(20) NOT NULL CHECK (HanhDong IN (N'Đăng nhập', N'Đăng xuất', N'Thêm', N'Sửa', N'Xóa', N'Truy vấn', N'Tải xuống')),
    NoiDung NVARCHAR(500),
    BangTacDong NVARCHAR(30),
    MaBanGhi INT,
    ThoiGian DATETIME DEFAULT GETDATE(),
    DiaChiIP VARCHAR(15),

    INDEX IX_NhatKy_ThoiGian (ThoiGian),
    INDEX IX_NhatKy_HanhDong (HanhDong)
);

INSERT INTO LoaiThuoc (TenLoai, MoTa) VALUES
(N'Thuốc kháng sinh', N'Thuốc dùng để điều trị nhiễm trùng do vi khuẩn.'),
(N'Thuốc giảm đau', N'Thuốc dùng để giảm đau và hạ sốt.'),
(N'Thuốc chống viêm', N'Thuốc dùng để giảm viêm và sưng.'),
(N'Thuốc tim mạch', N'Thuốc dùng để điều trị các bệnh liên quan đến tim mạch.'),
(N'Thuốc điều trị tiểu đường', N'Thuốc dùng để kiểm soát lượng đường trong máu.');

INSERT INTO DanhMucThuoc (MaLoai, TenDanhMuc, MoTa) VALUES
(1, N'Thuốc kháng sinh phổ rộng', N'Thuốc kháng sinh có tác dụng trên nhiều loại vi khuẩn.'),
(1, N'Thuốc kháng sinh đặc hiệu', N'Thuốc kháng sinh có tác dụng trên một số loại vi khuẩn nhất định.'),
(2, N'Thuốc giảm đau không steroid', N'Thuốc giảm đau không chứa steroid.'),
(2, N'Thuốc giảm đau có steroid', N'Thuốc giảm đau có chứa steroid.'),
(3, N'Thuốc chống viêm không steroid', N'Thuốc chống viêm không chứa steroid.'),
(4, N'Thuốc điều trị huyết áp', N'Thuốc dùng để điều trị huyết áp cao.'),
(5, N'Thuốc điều trị tiểu đường loại 1', N'Thuốc dùng cho bệnh nhân tiểu đường loại 1.'),
(5, N'Thuốc điều trị tiểu đường loại 2', N'Thuốc dùng cho bệnh nhân tiểu đường loại 2.');

INSERT INTO VaiTro (TenVaiTro, MoTa)
VALUES 
(N'Quản trị', N'Quản lý toàn bộ hệ thống, phân quyền và cấu hình'),
(N'Bác sĩ', N'Quản lý bệnh nhân, lập hồ sơ khám, kê đơn thuốc'),
(N'Nhân viên', N'Quản lý bệnh nhân, đặt lịch khám, lập hóa đơn'),
(N'Kế toán', N'Quản lý hóa đơn, thanh toán, báo cáo tài chính');

INSERT INTO Quyen (TenQuyen, MoTa)
VALUES 
(N'Xem bệnh nhân', N'Quyền xem thông tin bệnh nhân'),
(N'Thêm bệnh nhân', N'Quyền thêm bệnh nhân mới vào hệ thống'),
(N'Sửa bệnh nhân', N'Quyền chỉnh sửa thông tin bệnh nhân'),
(N'Xóa bệnh nhân', N'Quyền xóa bệnh nhân khỏi hệ thống'),
(N'Xem lịch khám', N'Quyền xem lịch khám của bệnh nhân'),
(N'Quản lý lịch khám', N'Quyền thêm, sửa, xóa lịch khám bệnh nhân'),
(N'Thêm bác sĩ', N'Quyền thêm thông tin bác sĩ vào hệ thống'),
(N'Sửa bác sĩ', N'Quyền chỉnh sửa thông tin bác sĩ'),
(N'Xóa bác sĩ', N'Quyền xóa thông tin bác sĩ'),
(N'Quản lý thuốc', N'Quyền thêm, sửa, xóa thuốc trong hệ thống'),
(N'Xem thuốc', N'Quyền xem thông tin thuốc trong kho'),
(N'Quản lý hóa đơn', N'Quyền tạo và quản lý hóa đơn bệnh nhân'),
(N'Thêm tài khoản', N'Quyền thêm tài khoản người dùng mới vào hệ thống'),
(N'Sửa tài khoản', N'Quyền chỉnh sửa thông tin tài khoản người dùng'),
(N'Xóa tài khoản', N'Quyền xóa tài khoản người dùng khỏi hệ thống'),
(N'Phân quyền tài khoản', N'Quyền phân quyền cho các tài khoản người dùng'),
(N'Xem báo cáo thống kê', N'Quyền xem các báo cáo thống kê của hệ thống'),
(N'Quản lý bệnh nhân', N'Quyền quản lý bệnh nhân, cập nhật thông tin bệnh nhân');

INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(1, 1),  -- Quản trị viên có quyền "Xem bệnh nhân"
(1, 2),  -- Quản trị viên có quyền "Thêm bệnh nhân"
(1, 3),  -- Quản trị viên có quyền "Sửa bệnh nhân"
(1, 4),  -- Quản trị viên có quyền "Xóa bệnh nhân"
(1, 5),  -- Quản trị viên có quyền "Xem lịch khám"
(1, 6),  -- Quản trị viên có quyền "Quản lý lịch khám"
(1, 7),  -- Quản trị viên có quyền "Thêm bác sĩ"
(1, 8),  -- Quản trị viên có quyền "Sửa bác sĩ"
(1, 9),  -- Quản trị viên có quyền "Xóa bác sĩ"
(1, 10), -- Quản trị viên có quyền "Quản lý thuốc"
(1, 11), -- Quản trị viên có quyền "Xem thuốc"
(1, 12), -- Quản trị viên có quyền "Quản lý hóa đơn"
(1, 13), -- Quản trị viên có quyền "Thêm tài khoản"
(1, 14), -- Quản trị viên có quyền "Sửa tài khoản"
(1, 15), -- Quản trị viên có quyền "Xóa tài khoản"
(1, 16), -- Quản trị viên có quyền "Phân quyền tài khoản"
(1, 17), -- Quản trị viên có quyền "Xem báo cáo thống kê"
(1, 18); -- Quản trị viên có quyền "Quản lý bệnh nhân"

-- Quyền cho Bác sĩ
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(2, 1),  -- Bác sĩ có quyền "Xem bệnh nhân"
(2, 2),  -- Bác sĩ có quyền "Thêm bệnh nhân"
(2, 3),  -- Bác sĩ có quyền "Sửa bệnh nhân"
(2, 5),  -- Bác sĩ có quyền "Xem lịch khám"
(2, 6),  -- Bác sĩ có quyền "Quản lý lịch khám"
(2, 7),  -- Bác sĩ có quyền "Thêm bác sĩ"
(2, 8);  -- Bác sĩ có quyền "Sửa bác sĩ"

-- Quyền cho Nhân viên
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(3, 1),  -- Nhân viên có quyền "Xem bệnh nhân"
(3, 2),  -- Nhân viên có quyền "Thêm bệnh nhân"
(3, 5),  -- Nhân viên có quyền "Xem lịch khám"
(3, 6),  -- Nhân viên có quyền "Quản lý lịch khám"
(3, 12), -- Nhân viên có quyền "Quản lý hóa đơn"
(3, 13), -- Nhân viên có quyền "Thêm tài khoản"
(3, 14); -- Nhân viên có quyền "Sửa tài khoản"

-- Quyền cho Kế toán
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(4, 1),  -- Kế toán có quyền "Xem bệnh nhân"
(4, 12), -- Kế toán có quyền "Quản lý hóa đơn"
(4, 16), -- Kế toán có quyền "Phân quyền tài khoản"
(4, 17); -- Kế toán có quyền "Xem báo cáo thống kê"

-- Bảng Nhân viên (10 records)
INSERT INTO NhanVien (HoTen, ChucVu, Email, SoDienThoai, DiaChi, NgayVaoLam, TrangThai)
VALUES
(N'Nguyễn Văn Anh', N'Lễ tân', 'nguyen.anh@phongkham.com', '0912345678', N'123 Đường Lê Lợi, Quận 1, TP.HCM', '2020-05-15', 1),
(N'Trần Thị Bích', N'Kế toán', 'tran.bich@phongkham.com', '0923456789', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM', '2019-11-20', 1),
(N'Lê Văn Cường', N'Quản lý', 'le.cuong@phongkham.com', '0934567890', N'789 Đường Pasteur, Quận 3, TP.HCM', '2018-03-10', 1),
(N'Phạm Thị Dung', N'Y tá', 'pham.dung@phongkham.com', '0945678901', N'321 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', '2021-02-28', 1),
(N'Hoàng Văn Đức', N'Bảo vệ', 'hoang.duc@phongkham.com', '0956789012', N'654 Đường 3 Tháng 2, Quận 10, TP.HCM', '2020-07-15', 1),
(N'Vũ Thị Hà', N'Lễ tân', 'vu.ha@phongkham.com', '0967890123', N'987 Đường Lý Thái Tổ, Quận 3, TP.HCM', '2022-01-05', 1),
(N'Đặng Văn Minh', N'Kỹ thuật viên', 'dang.minh@phongkham.com', '0978901234', N'147 Đường Lê Văn Sỹ, Quận Phú Nhuận, TP.HCM', '2021-09-12', 1),
(N'Bùi Thị Ngọc', N'Y tá', 'bui.ngoc@phongkham.com', '0989012345', N'258 Đường Lê Quang Định, Quận Gò Vấp, TP.HCM', '2019-06-30', 1),
(N'Ngô Văn Phong', N'Kế toán', 'ngo.phong@phongkham.com', '0990123456', N'369 Đường Nguyễn Văn Trỗi, Quận Tân Bình, TP.HCM', '2020-10-22', 1),
(N'Mai Thị Quyên', N'Quản lý kho', 'mai.quyen@phongkham.com', '0901234567', N'159 Đường Thống Nhất, Quận Tân Bình, TP.HCM', '2021-04-18', 1);

-- Bảng Bác sĩ (10 records)
INSERT INTO BacSi (HoTen, ChuyenKhoa, BangCap, SoDienThoai, Email, GioiThieu, TrangThai)
VALUES
(N'Trần Văn Bách', N'Nội khoa', N'Bác sĩ chuyên khoa II Nội khoa - ĐH Y Dược TP.HCM', '0911222333', 'bach.tv@phongkham.com', N'Chuyên điều trị các bệnh lý nội khoa tổng quát, bệnh cao huyết áp, tiểu đường. Kinh nghiệm 15 năm.', 1),
(N'Lê Thị Minh Châu', N'Nhi khoa', N'Tiến sĩ Nhi khoa - ĐH Y Hà Nội (2015)', '0922333444', 'chau.lt@phongkham.com', N'Chuyên về nhi khoa với 12 năm kinh nghiệm, đặc biệt về miễn dịch và tiêm chủng. Nguyên trưởng khoa Nhi BV Nhi Đồng 1.', 1),
(N'Nguyễn Hữu Đạt', N'Tim mạch', N'Phó giáo sư, Bác sĩ chuyên khoa Tim mạch - BV Chợ Rẫy (2018)', '0933444555', 'dat.nh@phongkham.com', N'Chuyên can thiệp tim mạch, từng đào tạo tại Pháp. Có hơn 500 ca can thiệp thành công.', 1),
(N'Hoàng Thị Kim Liên', N'Sản phụ khoa', N'Bác sĩ chuyên khoa I Sản phụ khoa - ĐH Y Dược Huế (2010)', '0944555666', 'lien.ht@phongkham.com', N'Chuyên thăm khám thai, siêu âm sản khoa, tư vấn sức khỏe sinh sản. Kinh nghiệm 13 năm.', 1),
(N'Phạm Văn Nam', N'Thần kinh', N'Tiến sĩ Thần kinh học - ĐH Y Dược TP.HCM (2017)', '0955666777', 'nam.pv@phongkham.com', N'Chuyên điều trị đột quỵ, Parkinson, động kinh. Từng công tác tại BV Bạch Mai.', 1),
(N'Võ Thị Ngọc Anh', N'Da liễu', N'Bác sĩ chuyên khoa II Da liễu - BV Da liễu TW (2019)', '0966777888', 'anh.vt@phongkham.com', N'Chuyên điều trị mụn, nám, lão hóa da. Được đào tạo thẩm mỹ tại Hàn Quốc.', 1),
(N'Đặng Văn Phúc', N'Tiêu hóa', N'Thạc sĩ Nội soi tiêu hóa - ĐH Y Dược TP.HCM (2016)', '0977888999', 'phuc.dv@phongkham.com', N'Chuyên nội soi chẩn đoán và điều trị các bệnh lý dạ dày, đại tràng. Kinh nghiệm 10 năm.', 1),
(N'Bùi Thị Quỳnh', N'Tai mũi họng', N'Bác sĩ chuyên khoa I Tai Mũi Họng (2014)', '0988999000', 'quynh.bt@phongkham.com', N'Chuyên phẫu thuật nội soi xoang, cắt amidan, điều trị viêm tai giữa. Từng công tác tại BV TMH TW.', 1),
(N'Lương Văn Sơn', N'Xương khớp', N'Bác sĩ chuyên khoa Cơ xương khớp - ĐH Y Phạm Ngọc Thạch (2013)', '0999000111', 'son.lv@phongkham.com', N'Chuyên trị thoái hóa khớp, thoát vị đĩa đệm. Được đào tạo phẫu thuật nội soi tại Singapore.', 1),
(N'Ngô Thị Thu Hà', N'Mắt', N'Tiến sĩ Nhãn khoa - ĐH Y Dược TP.HCM (2018)', '0900111222', 'ha.nt@phongkham.com', N'Chuyên khám và phẫu thuật đục thủy tinh thể, LASIK điều trị cận thị. Kinh nghiệm 9 năm.', 1);

-- Bảng Bệnh nhân (20 records)
INSERT INTO BenhNhan (HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi, Email, TienSuBenh, NgheNghiep, NgayDangKy, TrangThai)
VALUES
(N'Nguyễn Văn A', '1985-01-15', 'M', '0912345678', N'123 Đường Lê Lợi, Quận 1, TP.HCM', 'a.nguyen@domain.com', N'Không có', N'Kỹ sư', GETDATE(), 1),
(N'Trần Thị B', '1990-02-20', 'F', '0923456789', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM', 'b.tran@domain.com', N'Tiểu đường', N'Giáo viên', GETDATE(), 1),
(N'Lê Văn C', '1980-03-10', 'M', '0934567890', N'789 Đường Pasteur, Quận 3, TP.HCM', 'c.le@domain.com', N'Không có', N'Nhân viên văn phòng', GETDATE(), 1),
(N'Phạm Thị D', '1975-04-25', 'F', '0945678901', N'321 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', 'd.pham@domain.com', N'Khó thở', N'Nội trợ', GETDATE(), 1),
(N'Hoàng Văn E', '1995-05-30', 'M', '0956789012', N'654 Đường 3 Tháng 2, Quận 10, TP.HCM', 'e.hoang@domain.com', N'Không có', N'Sinh viên', GETDATE(), 1),
(N'Vũ Thị F', '1988-06-15', 'F', '0967890123', N'987 Đường Lý Thái Tổ, Quận 3, TP.HCM', 'f.vu@domain.com', N'Viêm họng', N'Nhân viên bán hàng', GETDATE(), 1),
(N'Đặng Văn G', '1982-07-20', 'M', '0978901234', N'147 Đường Lê Văn Sỹ, Quận Phú Nhuận, TP.HCM', 'g.dang@domain.com', N'Không có', N'Kỹ thuật viên', GETDATE(), 1),
(N'Bùi Thị H', '1992-08-05', 'F', '0989012345', N'258 Đường Lê Quang Định, Quận Gò Vấp, TP.HCM', 'h.bui@domain.com', N'Khó ngủ', N'Sinh viên', GETDATE(), 1),
(N'Ngô Văn I', '1983-09-10', 'M', '0990123456', N'369 Đường Nguyễn Văn Trỗi, Quận Tân Bình, TP.HCM', 'i.ngo@domain.com', N'Không có', N'Nhân viên IT', GETDATE(), 1),
(N'Mai Thị J', '1991-10-15', 'F', '0901234567', N'159 Đường Thống Nhất, Quận Tân Bình, TP.HCM', 'j.mai@domain.com', N'Đau đầu', N'Nhân viên văn phòng', GETDATE(), 1),
(N'Nguyễn Văn K', '1980-11-20', 'M', '0912345670', N'123 Đường Nguyễn Thị Minh Khai, Quận 1, TP.HCM', 'k.nguyen@domain.com', N'Không có', N'Kỹ sư', GETDATE(), 1),
(N'Trần Thị L', '1985-12-25', 'F', '0923456781', N'456 Đường Trần Hưng Đạo, Quận 5, TP.HCM', 'l.tran@domain.com', N'Viêm khớp', N'Giáo viên', GETDATE(), 1),
(N'Lê Văn M', '1993-01-30', 'M', '0934567892', N'789 Đường Phan Đình Phùng, Quận Phú Nhuận, TP.HCM', 'm.le@domain.com', N'Không có', N'Sinh viên', GETDATE(), 1),
(N'Phạm Thị N', '1987-02-28', 'F', '0945678903', N'321 Đường Nguyễn Thái Bình, Quận 1, TP.HCM', 'n.pham@domain.com', N'Khó thở', N'Nội trợ', GETDATE(), 1),
(N'Hoàng Văn O', '1994-03-15', 'M', '0956789014', N'654 Đường Lê Văn Sỹ, Quận 10, TP.HCM', 'o.hoang@domain.com', N'Không có', N'Nhân viên bán hàng', GETDATE(), 1),
(N'Vũ Thị P', '1989-04-20', 'F', '0967890125', N'987 Đường Nguyễn Huệ, Quận 1, TP.HCM', 'p.vu@domain.com', N'Viêm họng', N'Nhân viên văn phòng', GETDATE(), 1),
(N'Đặng Văn Q', '1981-05-25', 'M', '0978901236', N'147 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', 'q.dang@domain.com', N'Không có', N'Kỹ thuật viên', GETDATE(), 1),
(N'Bùi Thị R', '1996-06-30', 'F', '0989012347', N'258 Đường Lý Thái Tổ, Quận 3, TP.HCM', 'r.bui@domain.com', N'Khó ngủ', N'Sinh viên', GETDATE(), 1);

-- Bảng Lịch khám (20 records)
INSERT INTO LichKham (MaBN, MaBS, NgayKham, GioKham, ThoiGianDuKien, LyDo, TrangThai, NgayTao, GhiChu)
VALUES
(1, 1, '2023-10-20', '08:00', 30, N'Khám sức khỏe tổng quát', N'Đặt lịch', GETDATE(), NULL),
(2, 2, '2023-10-21', '09:00', 30, N'Khám bệnh tiểu đường', N'Đặt lịch', GETDATE(), NULL),
(3, 3, '2023-10-22', '10:00', 30, N'Khám tim mạch', N'Đặt lịch', GETDATE(), NULL),
(4, 4, '2023-10-23', '11:00', 30, N'Khám sản phụ khoa', N'Đặt lịch', GETDATE(), NULL),
(5, 5, '2023-10-24', '14:00', 30, N'Khám thần kinh', N'Đặt lịch', GETDATE(), NULL),
(6, 6, '2023-10-25', '15:00', 30, N'Khám da liễu', N'Đặt lịch', GETDATE(), NULL),
(7, 7, '2023-10-26', '16:00', 30, N'Khám tiêu hóa', N'Đặt lịch', GETDATE(), NULL),
(8, 8, '2023-10-27', '08:30', 30, N'Khám tai mũi họng', N'Đặt lịch', GETDATE(), NULL),
(9, 9, '2023-10-28', '09:30', 30, N'Khám xương khớp', N'Đặt lịch', GETDATE(), NULL),
(10, 10, '2023-10-29', '10:30', 30, N'Khám mắt', N'Đặt lịch', GETDATE(), NULL),
(1, 2, '2023-10-30', '11:30', 30, N'Tái khám bệnh tiểu đường', N'Đặt lịch', GETDATE(), NULL),
(2, 3, '2023-10-31', '14:30', 30, N'Tái khám tim mạch', N'Đặt lịch', GETDATE(), NULL),
(3, 4, '2023-11-01', '15:30', 30, N'Tái khám sản phụ khoa', N'Đặt lịch', GETDATE(), NULL),
(4, 5, '2023-11-02', '16:30', 30, N'Tái khám thần kinh', N'Đặt lịch', GETDATE(), NULL),
(5, 6, '2023-11-03', '08:00', 30, N'Tái khám da liễu', N'Đặt lịch', GETDATE(), NULL),
(6, 7, '2023-11-04', '09:00', 30, N'Tái khám tiêu hóa', N'Đặt lịch', GETDATE(), NULL),
(7, 8, '2023-11-05', '10:00', 30, N'Tái khám tai mũi họng', N'Đặt lịch', GETDATE(), NULL),
(8, 9, '2023-11-06', '11:00', 30, N'Tái khám xương khớp', N'Đặt lịch', GETDATE(), NULL),
(9, 10, '2023-11-07', '14:00', 30, N'Tái khám mắt', N'Đặt lịch', GETDATE(), NULL),
(10, 1, '2023-11-08', '15:00', 30, N'Khám sức khỏe tổng quát', N'Đặt lịch', GETDATE(), NULL);

-- Bảng Hồ sơ khám (20 records)
INSERT INTO HoSoKham (MaLichKham, TrieuChung, ChanDoan, LoiDan, NgayTaiKham, DaThanhToan)
VALUES
-- Các hồ sơ khám đã hoàn thành
(1, N'Mệt mỏi, chán ăn, đau đầu nhẹ', N'Thiếu máu nhẹ', N'Uống thuốc đều, bổ sung sắt, ăn uống đủ chất', '2023-11-20', 1),
(2, N'Khát nước, tiểu nhiều, sụt cân 3kg', N'Tiểu đường type 2', N'Kiểm tra đường huyết hàng ngày, hạn chế đồ ngọt', '2023-11-25', 1),
(3, N'Đau ngực trái, khó thở khi vận động', N'Rối loạn nhịp tim', N'Hạn chế cà phê, theo dõi huyết áp hàng ngày', '2023-11-28', 1),
(4, N'Trễ kinh 2 tuần, buồn nôn', N'Có thai 8 tuần', N'Uống bổ sung sắt, khám thai định kỳ', '2023-12-05', 1),
(5, N'Tê tay chân, đau nửa đầu', N'Thiếu máu não', N'Nghỉ ngơi đủ, hạn chế thức khuya', '2023-12-10', 1),

-- Các hồ sơ khám chuyên khoa
(6, N'Nổi mẩn đỏ, ngứa toàn thân', N'Dị ứng thời tiết', N'Uống thuốc đều, tránh tiếp xúc với phấn hoa', '2023-12-15', 0),
(7, N'Đau bụng âm ỉ vùng thượng vị', N'Viêm dạ dày cấp', N'Ăn uống đúng giờ, hạn chế đồ chua cay', '2023-12-20', 0),
(8, N'Ù tai, nghe kém tai trái', N'Viêm tai giữa', N'Giữ tai khô ráo, tránh nước vào tai', '2023-12-25', 0),
(9, N'Đau khớp gối khi leo cầu thang', N'Thoái hóa khớp gối độ 1', N'Hạn chế vận động mạnh, tập vật lý trị liệu', '2024-01-05', 0),
(10, N'Mờ mắt, nhức mắt khi đọc sách', N'Cận thị 2.5 độ', N'Hạn chế dùng điện thoại trong bóng tối', '2024-01-10', 0),

-- Các hồ sơ khám tổng quát
(11, N'Ho khan, đau họng, sốt nhẹ', N'Viêm họng cấp', N'Uống nhiều nước ấm, súc họng nước muối', '2023-12-01', 1),
(12, N'Đau bụng, tiêu chảy 3 ngày', N'Rối loạn tiêu hóa', N'Ăn cháo loãng, uống oresol bù nước', '2023-12-03', 1),
(13, N'Mất ngủ, căng thẳng kéo dài', N'Rối loạn lo âu', N'Tập thể dục nhẹ, hạn chế cà phê', '2023-12-07', 0),
(14, N'Đau lưng sau khi mang vác nặng', N'Căng cơ lưng', N'Xoa bóp, chườm ấm, hạn chế vận động mạnh', '2023-12-12', 0),
(15, N'Chóng mặt khi thay đổi tư thế', N'Huyết áp thấp tư thế', N'Đứng lên từ từ, uống đủ nước', '2023-12-17', 0),

-- Các hồ sơ khám khác
(16, N'Sổ mũi, hắt hơi, ngứa mũi', N'Viêm mũi dị ứng', N'Tránh tiếp xúc với bụi, lông thú', '2023-12-22', 0),
(17, N'Đau răng hàm dưới bên phải', N'Sâu răng số 6', N'Hẹn lấy tủy sau 3 ngày', '2023-12-27', 0),
(18, N'Da mặt nổi nhiều mụn viêm', N'Viêm nang lông mặt', N'Vệ sinh da mặt đúng cách, không nặn mụn', '2024-01-15', 0),
(19, N'Tê bì tay phải về đêm', N'Hội chứng ống cổ tay', N'Mang nẹp cổ tay khi ngủ', '2024-01-20', 0),
(20, N'Đau vai gáy kéo dài', N'Thoái hóa đốt sống cổ', N'Tập các bài tập cổ, tránh ngồi lâu', '2024-01-25', 0);

-- Thuốc kháng sinh phổ rộng (MaLoai = 1, MaDanhMuc = 1)
INSERT INTO Thuoc (TenThuoc, DonViTinh, DonGiaBan, SoLuongTon, HanSuDung, NhaSanXuat, CachDung, MaLoai, MaDanhMuc) VALUES
(N'Amoxicillin 500mg', N'Viên', 25000.00, 150, '2025-12-31', N'Pharma SV', N'2 viên/ngày sau ăn', 1, 1),
(N'Azithromycin 250mg', N'Viên', 35000.00, 80, '2026-03-15', N'Dược Hậu Giang', N'1 viên/ngày, uống xa bữa ăn', 1, 1),
(N'Cephalexin 500mg', N'Viên', 28000.00, 120, '2025-10-20', N'Opsonin', N'3 lần/ngày, mỗi lần 1 viên', 1, 1),
(N'Doxycycline 100mg', N'Viên', 32000.00, 90, '2026-01-30', N'Stada', N'1 viên/ngày, uống nhiều nước', 1, 1),
(N'Ciprofloxacin 500mg', N'Viên', 30000.00, 70, '2025-11-15', N'Bayer', N'2 lần/ngày cách 12 tiếng', 1, 1),

-- Thuốc kháng sinh đặc hiệu (MaLoai = 1, MaDanhMuc = 2)
(N'Metronidazole 250mg', N'Viên', 18000.00, 100, '2025-09-30', N'Pharbaco', N'3 lần/ngày sau ăn', 1, 2),
(N'Clindamycin 300mg', N'Viên', 42000.00, 60, '2026-02-28', N'Pymepharco', N'4 lần/ngày', 1, 2),
(N'Vancomycin 500mg', N'Lọ', 250000.00, 30, '2025-12-31', N'Pfizer', N'Tiêm tĩnh mạch theo chỉ định', 1, 2),

-- Thuốc giảm đau không steroid (MaLoai = 2, MaDanhMuc = 3)
(N'Paracetamol 500mg', N'Viên', 5000.00, 300, '2025-06-30', N'OPV', N'Uống khi sốt trên 38.5°C', 2, 3),
(N'Ibuprofen 400mg', N'Viên', 12000.00, 200, '2025-08-15', N'Dược Hà Tây', N'3 lần/ngày sau ăn', 2, 3),
(N'Aspirin 81mg', N'Viên', 8000.00, 180, '2026-01-01', N'Bayer', N'1 viên/ngày buổi sáng', 2, 3),
(N'Diclofenac 50mg', N'Viên', 15000.00, 150, '2025-09-30', N'Novartis', N'2 lần/ngày với nhiều nước', 2, 3),

-- Thuốc giảm đau có steroid (MaLoai = 2, MaDanhMuc = 4)
(N'Prednisolon 5mg', N'Viên', 22000.00, 100, '2025-07-31', N'Pymepharco', N'Theo chỉ định bác sĩ', 2, 4),
(N'Dexamethasone 4mg', N'Viên', 18000.00, 80, '2026-03-30', N'Stada', N'Uống buổi sáng sau ăn', 2, 4),

-- Thuốc chống viêm không steroid (MaLoai = 3, MaDanhMuc = 5)
(N'Meloxicam 15mg', N'Viên', 35000.00, 120, '2025-11-30', N'Boehringer', N'1 viên/ngày với nhiều nước', 3, 5),
(N'Celecoxib 200mg', N'Viên', 40000.00, 90, '2026-02-15', N'Pharmedic', N'2 lần/ngày sau ăn', 3, 5),
(N'Etoricoxib 90mg', N'Viên', 45000.00, 70, '2025-10-20', N'EUROPHARMA', N'1 viên/ngày không quá 8 ngày', 3, 5),

-- Thuốc tim mạch - huyết áp (MaLoai = 4, MaDanhMuc = 6)
(N'Amlodipine 5mg', N'Viên', 25000.00, 150, '2026-05-31', N'Pharmedic', N'Uống 1 lần/ngày', 4, 6),
(N'Bisoprolol 5mg', N'Viên', 30000.00, 120, '2026-04-15', N'Domesco', N'Không ngưng đột ngột', 4, 6),
(N'Losartan 50mg', N'Viên', 35000.00, 100, '2025-12-31', N'Pfizer', N'Uống đúng giờ mỗi ngày', 4, 6),
(N'Valsartan 80mg', N'Viên', 40000.00, 80, '2025-11-30', N'Novartis', N'1 viên/ngày buổi sáng', 4, 6),
(N'Furosemid 40mg', N'Viên', 18000.00, 90, '2025-09-30', N'Opsonin', N'Uống buổi sáng sau ăn', 4, 6),

-- Thuốc tiểu đường loại 1 (MaLoai = 5, MaDanhMuc = 7)
(N'Insulin Mixtard 30/70', N'Bút', 320000.00, 50, '2025-12-31', N'Novo Nordisk', N'Tiêm dưới da 2 lần/ngày', 5, 7),
(N'Lantus SoloStar', N'Bút', 380000.00, 40, '2026-03-31', N'Sanofi', N'Tiêm 1 lần/ngày trước ngủ', 5, 7),

-- Thuốc tiểu đường loại 2 (MaLoai = 5, MaDanhMuc = 8)
(N'Metformin 500mg', N'Viên', 15000.00, 200, '2025-10-31', N'Pharbaco', N'2 viên/ngày sau bữa ăn', 5, 8),
(N'Glibenclamid 5mg', N'Viên', 25000.00, 150, '2025-09-30', N'Pymepharco', N'1 viên trước bữa sáng', 5, 8),
(N'Sitagliptin 100mg', N'Viên', 45000.00, 100, '2026-01-15', N'MSD', N'1 viên/ngày bất kể bữa ăn', 5, 8),
(N'Empagliflozin 10mg', N'Viên', 50000.00, 80, '2026-02-28', N'Boehringer', N'Uống buổi sáng', 5, 8),

-- Các thuốc khác
(N'Morphin sulfat 10mg', N'Ống', 85000.00, 30, '2025-08-31', N'Domesco', N'Chỉ dùng khi có chỉ định', 2, 4),
(N'Oxycodon 5mg', N'Viên', 60000.00, 40, '2025-07-15', N'Mundipharma', N'Giảm đau mức độ nặng', 2, 4),
(N'Simvastatin 20mg', N'Viên', 28000.00, 120, '2026-04-30', N'Pymepharco', N'Uống buổi tối trước ngủ', 4, 6),
(N'Atorvastatin 10mg', N'Viên', 35000.00, 100, '2025-12-31', N'Dược Hậu Giang', N'Uống bất kỳ thời điểm nào', 4, 6),
(N'Clopidogrel 75mg', N'Viên', 42000.00, 90, '2026-03-15', N'Sanofi', N'1 viên/ngày kèm ăn', 4, 6),
(N'Warfarin 5mg', N'Viên', 38000.00, 60, '2025-09-30', N'Stada', N'Uống đúng giờ mỗi ngày', 4, 6),
(N'Captopril 25mg', N'Viên', 20000.00, 80, '2025-10-31', N'DHG Pharma', N'3 lần/ngày trước bữa ăn', 4, 6),
(N'Spironolacton 25mg', N'Viên', 18000.00, 70, '2026-01-15', N'Pymepharco', N'Dùng kèm với thuốc lợi tiểu khác', 4, 6),
(N'Digoxin 0.25mg', N'Viên', 30000.00, 50, '2025-08-31', N'OPV', N'Theo dõi nồng độ máu', 4, 6),
(N'Salbutamol 100mcg', N'Bình xịt', 65000.00, 40, '2026-05-31', N'GSK', N'Xịt khi lên cơn khó thở', 3, 5),
(N'Budesonid 200mcg', N'Bình xịt', 85000.00, 30, '2026-04-30', N'AstraZeneca', N'Xịt phòng ngừa viêm phế quản', 3, 5),
(N'Sertraline 50mg', N'Viên', 55000.00, 60, '2025-12-31', N'Pfizer', N'1 viên/ngày buổi sáng', 3, 5);

-- Bảng Đơn thuốc (30 records)
INSERT INTO DonThuoc (MaHoSo, MaThuoc, SoLuong, LieuDung, Sang, Trua, Chieu, Toi, SoNgay, GhiChu)
VALUES
-- Đơn thuốc cho hồ sơ từ 1-10 (các bệnh thông thường)
(1, 1, 10, N'Uống sau ăn', 1, 0, 1, 0, 5, N'Uống đủ liều'),
(2, 5, 20, N'Uống sau ăn sáng, tối', 1, 0, 1, 0, 10, N'Theo dõi đường huyết'),
(3, 12, 14, N'Uống buổi sáng', 1, 0, 0, 0, 14, N'Kiểm tra huyết áp hàng ngày'),
(4, 20, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Bổ sung vitamin'),
(5, 7, 15, N'Uống sau ăn', 1, 0, 1, 0, 7, N'Dùng khi đau đầu'),

(6, 25, 1, N'Bôi ngày 2 lần', 1, 0, 1, 0, 7, N'Bôi mỏng lớp'),
(7, 6, 21, N'Uống 3 lần/ngày', 1, 1, 1, 0, 7, N'Dùng sau ăn no'),
(8, 30, 10, N'Nhỏ tai ngày 3 lần', 1, 1, 1, 0, 5, N'Vệ sinh tai sạch'),
(9, 24, 14, N'Uống sáng chiều', 1, 0, 1, 0, 14, N'Uống nhiều nước'),
(10, 15, 14, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Kết hợp tập mắt'),

-- Đơn thuốc cho hồ sơ từ 11-20 (các bệnh cấp tính)
(11, 2, 14, N'Uống 2 lần/ngày', 1, 0, 1, 0, 7, N'Uống nhiều nước'),
(12, 33, 10, N'Pha uống ngày 3 gói', 1, 1, 1, 0, 3, N'Uống sau mỗi lần đi ngoài'),
(13, 19, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Nghỉ ngơi đầy đủ'),
(14, 8, 10, N'Uống khi đau', 0, 0, 0, 1, 5, N'Không quá 4 viên/ngày'),
(15, 13, 28, N'Uống buổi sáng', 1, 0, 0, 0, 28, N'Theo dõi huyết áp'),

(16, 31, 14, N'Xịt mũi ngày 2 lần', 1, 0, 1, 0, 7, N'Vệ sinh mũi trước khi xịt'),
(17, 3, 10, N'Uống sau ăn trưa', 0, 1, 0, 0, 5, N'Không dùng khi đói'),
(18, 26, 1, N'Bôi ngày 2 lần', 1, 0, 1, 0, 7, N'Rửa mặt sạch trước khi bôi'),
(19, 22, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Kết hợp vật lý trị liệu'),
(20, 16, 14, N'Uống sau ăn tối', 0, 0, 0, 1, 14, N'Theo dõi đường huyết'),

-- Đơn thuốc cho các hồ sơ khác
(1, 9, 14, N'Uống sáng tối', 1, 0, 1, 0, 7, N'Không uống rượu bia'),
(2, 21, 60, N'Uống 3 lần/ngày', 1, 1, 1, 1, 20, N'Bổ sung canxi'),
(3, 18, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Tăng cường dinh dưỡng'),
(4, 29, 1, N'Xịt mũi ngày 1 lần', 1, 0, 0, 0, 30, N'Lắc kỹ trước khi dùng'),
(5, 10, 14, N'Uống trước ăn sáng', 1, 0, 0, 0, 14, N'Không nhai viên thuốc'),

(6, 4, 14, N'Uống sáng tối', 1, 0, 1, 0, 7, N'Tránh ánh nắng trực tiếp'),
(7, 32, 30, N'Ngày 2 gói', 1, 0, 1, 0, 15, N'Uống nhiều nước'),
(8, 35, 1, N'Pha 1 gói/200ml nước', 1, 1, 1, 0, 5, N'Uống từng ngụm nhỏ'),
(9, 23, 42, N'Uống 3 lần/ngày', 1, 1, 1, 0, 14, N'Sau khi ăn no'),
(10, 17, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Theo dõi đường huyết');

-- Bảng Hóa đơn (20 records)
INSERT INTO HoaDon (MaLichKham, MaNV, MaBenhNhan, NgayTao, TienKham, TienThuoc, GiamGia, HinhThucThanhToan, DaThanhToan, GhiChu)
VALUES
(1, 1, 1, GETDATE(), 100000, 50000, 10000, N'Tiền mặt', 0, N'Khám tổng quát'),
(1, 1, 2,  GETDATE(), 150000, 70000, 5000, N'Tiền mặt', 1, N'Khám chuyên khoa'),
(2, 2, 1,  GETDATE(), 120000, 60000, 0, N'Tiền mặt', 0, N'Khám sức khỏe'),
(2, 2, 3,  GETDATE(), 130000, 80000, 15000, N'Tiền mặt', 1, N'Khám bệnh'),
(3, 3, 2,  GETDATE(), 110000, 55000, 2000, N'Tiền mặt', 0, N'Khám định kỳ'),
(3, 3, 4,  GETDATE(), 140000, 90000, 10000, N'Tiền mặt', 1, N'Khám tim mạch'),
(4, 1, 1,  GETDATE(), 160000, 75000, 5000, N'Tiền mặt', 0, N'Khám mắt'),
(4, 1, 5,  GETDATE(), 170000, 85000, 0, N'Tiền mặt', 1, N'Khám phụ khoa'),
(5, 2, 3,  GETDATE(), 180000, 95000, 20000, N'Tiền mặt', 0, N'Khám nội khoa'),
(5, 2, 6,  GETDATE(), 190000, 100000, 15000, N'Tiền mặt', 1, N'Khám ngoại khoa'),
(6, 3, 4,  GETDATE(), 200000, 110000, 10000, N'Tiền mặt', 0, N'Khám da liễu'),
(6, 3, 7,  GETDATE(), 210000, 120000, 5000, N'Tiền mặt', 1, N'Khám tâm lý'),
(7, 1, 5,  GETDATE(), 220000, 130000, 0, N'Tiền mặt', 0, N'Khám dinh dưỡng'),
(7, 1, 8,  GETDATE(), 230000, 140000, 10000, N'Tiền mặt', 1, N'Khám thể thao'),
(8, 2, 6,  GETDATE(), 240000, 150000, 15000, N'Tiền mặt', 0, N'Khám thần kinh'),
(8, 2, 9,  GETDATE(), 250000, 160000, 20000, N'Tiền mặt', 1, N'Khám hô hấp'),
(9, 3, 7,  GETDATE(), 260000, 170000, 5000, N'Tiền mặt', 0, N'Khám tiết niệu'),
(9, 3, 10,  GETDATE(), 270000, 180000, 0, N'Tiền mặt', 1, N'Khám sản phụ'),
(10, 1, 8,  GETDATE(), 280000, 190000, 10000, N'Tiền mặt', 0, N'Khám tổng quát'),
(10, 1, 11,  GETDATE(), 290000, 200000, 15000, N'Tiền mặt', 1, N'Khám chuyên khoa');

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, MaNhanVien, MaBacSi, Email, LanDangNhapCuoi, TrangThai, NgayTao, MaVaiTro) VALUES
(N'admin','Admin@123', N'Quản trị', NULL, NULL, N'admin@example.com', NULL, 1, GETDATE(), 1),
(N'doctor1', 'Doctor@123', N'Bác sĩ', NULL, 1, N'doctor1@example.com', NULL, 1, GETDATE(), 2),
(N'doctor2',  'Doctor@456', N'Bác sĩ', NULL, 2, N'doctor2@example.com', NULL, 1, GETDATE(), 2),
(N'staff1',  'Staff@123', N'Nhân viên', 1, NULL, N'staff1@example.com', NULL, 1, GETDATE(), 3),
(N'staff2',  'Staff@456', N'Nhân viên', 2, NULL, N'staff2@example.com', NULL, 1, GETDATE(), 3),
(N'accountant1',  'Accountant@123', N'Kế toán', NULL, NULL, N'accountant1@example.com', NULL, 1, GETDATE(), 4),
(N'admin2',  'Admin2@123', N'Quản trị', NULL, NULL, N'admin2@example.com', NULL, 1, GETDATE(), 1),
(N'doctor3',  'Doctor@789', N'Bác sĩ', NULL, 3, N'doctor3@example.com', NULL, 1, GETDATE(), 2),
(N'staff3',  'Staff@789', N'Nhân viên', 3, NULL, N'staff3@example.com', NULL, 1, GETDATE(), 3),
(N'accountant2', 'Accountant@456', N'Kế toán', NULL, NULL, N'accountant2@example.com', NULL, 1, GETDATE(), 4);

-- Bảng Nhật ký hệ thống (20 records)
INSERT INTO NhatKyHeThong (MaTaiKhoan, HanhDong, NoiDung, BangTacDong, MaBanGhi, ThoiGian, DiaChiIP)
VALUES
-- Nhật ký cho tài khoản quản trị viên
(1, N'Đăng nhập', N'Quản trị viên đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.1'),
(1, N'Truy vấn', N'Quản trị viên truy vấn danh sách bệnh nhân', N'BenhNhan', NULL, GETDATE(), '192.168.1.1'),
(1, N'Thêm', N'Quản trị viên thêm bác sĩ mới', N'BacSi', 1, GETDATE(), '192.168.1.1'),
(1, N'Sửa', N'Quản trị viên sửa thông tin nhân viên', N'NhanVien', 1, GETDATE(), '192.168.1.1'),
(1, N'Xóa', N'Quản trị viên xóa tài khoản nhân viên', N'TaiKhoan', 2, GETDATE(), '192.168.1.1'),

-- Nhật ký cho tài khoản kế toán
(2, N'Đăng nhập', N'Kế toán đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.2'),
(2, N'Truy vấn', N'Kế toán truy vấn hóa đơn', N'HoaDon', NULL, GETDATE(), '192.168.1.2'),
(2, N'Tải xuống', N'Kế toán tải xuống báo cáo tài chính', N'Báo cáo', NULL, GETDATE(), '192.168.1.2'),

-- Nhật ký cho tài khoản bác sĩ
(3, N'Đăng nhập', N'Bác sĩ đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.3'),
(3, N'Truy vấn', N'Bác sĩ truy vấn hồ sơ khám', N'HoSoKham', NULL, GETDATE(), '192.168.1.3'),
(3, N'Sửa', N'Bác sĩ sửa thông tin chẩn đoán', N'HoSoKham', 1, GETDATE(), '192.168.1.3'),

-- Nhật ký cho tài khoản nhân viên
(4, N'Đăng nhập', N'Nhân viên đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.4'),
(4, N'Truy vấn', N'Nhân viên truy vấn lịch khám', N'LichKham', NULL, GETDATE(), '192.168.1.4'),
(4, N'Thêm', N'Nhân viên thêm bệnh nhân mới', N'BenhNhan', 1, GETDATE(), '192.168.1.4'),

-- Nhật ký cho tài khoản khác
(5, N'Đăng nhập', N'Nhân viên đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.5'),
(5, N'Truy vấn', N'Nhân viên truy vấn danh sách thuốc', N'Thuoc', NULL, GETDATE(), '192.168.1.5'),
(5, N'Sửa', N'Nhân viên sửa thông tin thuốc', N'Thuoc', 1, GETDATE(), '192.168.1.5'),

-- Nhật ký cho tài khoản bác sĩ khác
(6, N'Đăng nhập', N'Bác sĩ đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.6'),
(6, N'Truy vấn', N'Bác sĩ truy vấn đơn thuốc', N'DonThuoc', NULL, GETDATE(), '192.168.1.6'),
(6, N'Tải xuống', N'Bác sĩ tải xuống báo cáo bệnh nhân', N'Báo cáo', NULL, GETDATE(), '192.168.1.6'),

-- Nhật ký cho tài khoản quản trị viên khác
(1, N'Đăng xuất', N'Quản trị viên đăng xuất khỏi hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.1'),
(2, N'Đăng xuất', N'Kế toán đăng xuất khỏi hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.2');

INSERT INTO PhieuNhapThuoc (MaNV, GhiChu, TrangThai, TongTien) VALUES
(1, N'Nhập thuốc định kỳ tháng 1', N'Đã nhập', 500000.00),
(2, N'Nhập thuốc khẩn cấp', N'Đã nhập', 300000.00),
(1, N'Nhập thuốc cho bệnh viện', N'Đã nhập', 700000.00),
(3, N'Nhập thuốc cho phòng khám', N'Đã nhập', 450000.00),
(2, N'Nhập thuốc bổ sung', N'Đã nhập', 600000.00);

INSERT INTO CT_PhieuNhap (MaPhieuNhap, MaThuoc, SoLuongNhap, DonGiaNhap) VALUES
(1, 1, 50, 25000.00), -- Amoxicillin
(1, 2, 30, 5000.00),  -- Paracetamol
(1, 3, 20, 12000.00), -- Ibuprofen
(2, 4, 10, 300000.00), -- Insulin
(2, 5, 15, 20000.00),  -- Atorvastatin
(3, 6, 25, 15000.00),  -- Omeprazole
(3, 7, 40, 25000.00),  -- Losartan
(4, 8, 60, 15000.00),  -- Metformin
(4, 9, 20, 18000.00),  -- Meloxicam
(5, 10, 10, 22000.00);  -- Prednisolon

INSERT INTO LichSuNhapThuoc (MaThuoc, SoLuongThayDoi, LoaiThayDoi, MaNV, GhiChu) VALUES
(1, 50, N'Nhập kho', 1, N'Nhập lần đầu'),
(2, 30, N'Nhập kho', 1, N'Nhập lần đầu'),
(3, 20, N'Nhập kho', 1, N'Nhập lần đầu'),
(4, 10, N'Nhập kho', 2, N'Nhập khẩn cấp'),
(5, 15, N'Nhập kho', 2, N'Nhập khẩn cấp'),
(6, 25, N'Nhập kho', 3, N'Nhập cho bệnh viện'),
(7, 40, N'Nhập kho', 3, N'Nhập cho phòng khám'),
(8, 60, N'Nhập kho', 3, N'Nhập bổ sung'),
(9, 20, N'Nhập kho', 1, N'Nhập bổ sung'),
(10, 10, N'Hủy nhập', 2, N'Hủy do lỗi nhập');

CREATE TABLE PhieuXuatThuoc (
    MaPhieuXuat INT IDENTITY(1,1) PRIMARY KEY,
    NgayXuat DATETIME NOT NULL DEFAULT GETDATE(),
    MaNV INT NOT NULL,  -- Nhân viên phụ trách xuất thuốc
    GhiChu NVARCHAR(255),

    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE CT_PhieuXuatThuoc (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuXuat INT NOT NULL,
    MaThuoc INT NOT NULL,
    SoLuongXuat INT NOT NULL CHECK (SoLuongXuat > 0),
    DonGiaXuat DECIMAL(18,2) NOT NULL CHECK (DonGiaXuat >= 0),
    ThanhTien AS (SoLuongXuat * DonGiaXuat) PERSISTED,

    FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuatThuoc(MaPhieuXuat),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc)
);

INSERT INTO PhieuXuatThuoc (NgayXuat, MaNV, GhiChu) VALUES
('2025-07-10', 1, N'Xuất thuốc theo đơn'),
('2025-07-11', 2, N'Xuất nội bộ'),
('2025-07-12', 3, N'Xuất cho phòng cấp cứu'),
('2025-07-12', 1, N'Xuất theo đơn BN Lê Văn A'),
('2025-07-13', 4, N'Xuất thuốc bổ sung'),
('2025-07-13', 2, N'Xuất hủy thuốc hết hạn'),
('2025-07-14', 5, N'Xuất theo đơn BN Nguyễn Thị B'),
('2025-07-15', 1, N'Xuất test tồn kho'),
('2025-07-16', 2, N'Xuất điều chỉnh kho'),
('2025-07-17', 3, N'Xuất cho bác sĩ trưởng khoa');

-- Seed dữ liệu cho bảng CT_PhieuXuatThuoc
INSERT INTO CT_PhieuXuatThuoc (MaPhieuXuat, MaThuoc, SoLuongXuat, DonGiaXuat)
VALUES 
(1, 1, 5, 12000),
(1, 2, 3, 18000),
(2, 3, 10, 5000),
(2, 4, 2, 25000),
(3, 5, 1, 100000),
(3, 1, 6, 11000),
(4, 6, 4, 22000),
(5, 7, 8, 7000),
(5, 2, 5, 19000),
(4, 8, 3, 15000);


=======
﻿CREATE DATABASE QLPhongKham;
GO
USE QLPhongKham
GO

-- Bảng nhân viên
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    SoDienThoai CHAR(10) CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    DiaChi NVARCHAR(200),
    NgayVaoLam DATE DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1
);

-- Bảng bác sĩ
CREATE TABLE BacSi (
    MaBS INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    ChuyenKhoa NVARCHAR(100) NOT NULL,
    BangCap NVARCHAR(200),
    SoDienThoai CHAR(10) CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    GioiThieu NVARCHAR(MAX),
    TrangThai BIT DEFAULT 1
);

-- Bảng bệnh nhân
CREATE TABLE BenhNhan (
    MaBN INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh CHAR(1) CHECK (GioiTinh IN ('M','F')) DEFAULT 'M',
    SoDienThoai CHAR(10) CHECK (SoDienThoai LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
    DiaChi NVARCHAR(200),
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    TienSuBenh NVARCHAR(MAX),
    NgheNghiep NVARCHAR(100),
    NgayDangKy DATETIME DEFAULT GETDATE(),
    TrangThai BIT DEFAULT 1
);

-- Bảng loại thuốc (định nghĩa trước vì được tham chiếu bởi bảng Thuoc)
CREATE TABLE LoaiThuoc (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(200)
);

-- Bảng danh mục thuốc (định nghĩa trước vì được tham chiếu bởi bảng Thuoc)
CREATE TABLE DanhMucThuoc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    MaLoai INT FOREIGN KEY REFERENCES LoaiThuoc(MaLoai),
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(200)
);

-- Bảng thuốc (đã tích hợp khóa ngoại từ ALTER TABLE)
CREATE TABLE Thuoc (
    MaThuoc INT IDENTITY(1,1) PRIMARY KEY,
    TenThuoc NVARCHAR(100) NOT NULL,
    DonViTinh NVARCHAR(20) NOT NULL,
    DonGiaBan DECIMAL(12,2) NOT NULL CHECK (DonGiaBan > 0),
    SoLuongTon INT NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    HanSuDung DATE NOT NULL,
    NhaSanXuat NVARCHAR(100),
    CachDung NVARCHAR(200),
    MaLoai INT NULL FOREIGN KEY REFERENCES LoaiThuoc(MaLoai),
    MaDanhMuc INT NULL FOREIGN KEY REFERENCES DanhMucThuoc(MaDanhMuc),

    INDEX IX_TenThuoc (TenThuoc)
);

-- Trigger kiểm tra hạn sử dụng thuốc
CREATE TRIGGER trg_KiemTraHanSuDung_Thuoc
ON Thuoc
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE HanSuDung <= CAST(GETDATE() AS DATE))
    BEGIN
        RAISERROR(N'Hạn sử dụng phải lớn hơn ngày hiện tại!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


-- Bảng lịch khám 
CREATE TABLE LichKham (
    MaLichKham INT IDENTITY(1,1) PRIMARY KEY,
    MaBN INT NOT NULL FOREIGN KEY REFERENCES BenhNhan(MaBN),
    MaBS INT NOT NULL FOREIGN KEY REFERENCES BacSi(MaBS),
    NgayKham DATE NOT NULL,
    GioKham TIME NOT NULL,
    ThoiGianDuKien INT DEFAULT 30, -- phút
    LyDo NVARCHAR(500),
    TrangThai NVARCHAR(20) NOT NULL DEFAULT N'Đặt lịch'
        CHECK (TrangThai IN (N'Đặt lịch', N'Xác nhận', N'Hoàn tất', N'Hủy', N'Không đến')),
    NgayTao DATETIME DEFAULT GETDATE(),
    GhiChu NVARCHAR(MAX),

    INDEX IX_LichKham_Date (NgayKham),
    INDEX IX_LichKham_Patient (MaBN),
    INDEX IX_LichKham_Doctor (MaBS)
);

-- Bảng hồ sơ khám bệnh
CREATE TABLE HoSoKham (
    MaHoSo INT IDENTITY(1,1) PRIMARY KEY,
    MaLichKham INT NOT NULL FOREIGN KEY REFERENCES LichKham(MaLichKham),
    TrieuChung NVARCHAR(500) NOT NULL,
    ChanDoan NVARCHAR(500),
    LoiDan NVARCHAR(500),
    NgayTaiKham DATE,
    DaThanhToan BIT DEFAULT 0
);

-- Bảng đơn thuốc
CREATE TABLE DonThuoc (
    MaDonThuoc INT IDENTITY(1,1) PRIMARY KEY,
    MaHoSo INT NOT NULL FOREIGN KEY REFERENCES HoSoKham(MaHoSo),
    MaThuoc INT NOT NULL FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    LieuDung NVARCHAR(200) NOT NULL,
    Sang INT DEFAULT 1,
    Trua INT DEFAULT 0,
    Chieu INT DEFAULT 1,
    Toi INT DEFAULT 0,
    SoNgay INT DEFAULT 7 CHECK (SoNgay > 0),
    GhiChu NVARCHAR(200)
);

-- Bảng hóa đơn 
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaLichKham INT NOT NULL FOREIGN KEY REFERENCES LichKham(MaLichKham),
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaBenhNhan INT NOT NULL FOREIGN KEY REFERENCES BenhNhan(MaBN),
    NgayTao DATETIME DEFAULT GETDATE(),
    TienKham DECIMAL(18,2) NOT NULL DEFAULT 0,
    TienThuoc DECIMAL(18,2) NOT NULL DEFAULT 0,
    GiamGia DECIMAL(18,2) DEFAULT 0,
    TongTien AS (TienKham + TienThuoc - GiamGia) PERSISTED,
    HinhThucThanhToan NVARCHAR(50) DEFAULT N'Tiền mặt',
    DaThanhToan BIT DEFAULT 0,
    GhiChu NVARCHAR(MAX),

    INDEX IX_HoaDon_Date (NgayTao),
    INDEX IX_HoaDon_Patient (MaBenhNhan)
);

-- Bảng phiếu nhập thuốc
CREATE TABLE PhieuNhapThuoc (
    MaPhieuNhap INT IDENTITY(1,1) PRIMARY KEY,
    NgayNhap DATETIME DEFAULT GETDATE(),
    MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    GhiChu NVARCHAR(500),
    TrangThai NVARCHAR(20) DEFAULT N'Đã nhập' CHECK (TrangThai IN (N'Đã nhập', N'Hủy')),
    TongTien DECIMAL(18,2) DEFAULT 0
);

-- Chi tiết phiếu nhập thuốc
CREATE TABLE CT_PhieuNhap (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap INT NOT NULL FOREIGN KEY REFERENCES PhieuNhapThuoc(MaPhieuNhap),
    MaThuoc INT NOT NULL FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuongNhap INT NOT NULL CHECK (SoLuongNhap > 0),
    DonGiaNhap DECIMAL(18,2) NOT NULL CHECK (DonGiaNhap > 0),
    ThanhTien AS (SoLuongNhap * DonGiaNhap) PERSISTED
);

-- Lịch sử nhập thuốc
CREATE TABLE LichSuNhapThuoc (
    MaLichSu INT IDENTITY(1,1) PRIMARY KEY,
    MaThuoc INT NOT NULL FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuongThayDoi INT NOT NULL,
    LoaiThayDoi NVARCHAR(50) NOT NULL CHECK (LoaiThayDoi IN (N'Nhập kho', N'Hủy nhập')),
    NgayThayDoi DATETIME DEFAULT GETDATE(),
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    GhiChu NVARCHAR(300)
);

-- Bảng vai trò (định nghĩa trước vì được tham chiếu bởi bảng TaiKhoan)
CREATE TABLE VaiTro (
    MaVaiTro INT IDENTITY(1,1) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE,
    MoTa NVARCHAR(200)
);

-- Bảng quyền (định nghĩa trước để tham chiếu trong VaiTro_Quyen)
CREATE TABLE Quyen (
    MaQuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenQuyen NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(300)
);

-- Bảng phân quyền
CREATE TABLE VaiTro_Quyen (
    MaVaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(MaVaiTro),
    MaQuyen INT NOT NULL FOREIGN KEY REFERENCES Quyen(MaQuyen),
    PRIMARY KEY (MaVaiTro, MaQuyen)
);

-- Bảng tài khoản (đã tích hợp khóa ngoại từ ALTER TABLE)
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE CHECK (LEN(TenDangNhap) >= 5),
    MatKhau VARCHAR(100) NOT NULL CHECK (LEN(MatKhau) >= 8),
    VaiTro NVARCHAR(20) NOT NULL CHECK (VaiTro IN (N'Quản trị', N'Bác sĩ', N'Nhân viên', N'Kế toán')),
    MaNhanVien INT NULL FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaBacSi INT NULL FOREIGN KEY REFERENCES BacSi(MaBS),
    Email VARCHAR(100) CHECK (Email LIKE '%@%.%'),
    LanDangNhapCuoi DATETIME,
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE(),
    MaVaiTro INT FOREIGN KEY REFERENCES VaiTro(MaVaiTro),

    CONSTRAINT CK_Account_Type CHECK (
        (VaiTro = N'Bác sĩ' AND MaBacSi IS NOT NULL) OR
        (VaiTro = N'Nhân viên' AND MaNhanVien IS NOT NULL) OR
        (VaiTro IN (N'Quản trị', N'Kế toán'))
    ),
    INDEX IX_TaiKhoan_Username (TenDangNhap)
);

-- Bảng nhật ký hệ thống
CREATE TABLE NhatKyHeThong (
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    MaTaiKhoan INT NULL FOREIGN KEY REFERENCES TaiKhoan(MaTaiKhoan),
    HanhDong NVARCHAR(20) NOT NULL CHECK (HanhDong IN (N'Đăng nhập', N'Đăng xuất', N'Thêm', N'Sửa', N'Xóa', N'Truy vấn', N'Tải xuống')),
    NoiDung NVARCHAR(500),
    BangTacDong NVARCHAR(30),
    MaBanGhi INT,
    ThoiGian DATETIME DEFAULT GETDATE(),
    DiaChiIP VARCHAR(15),

    INDEX IX_NhatKy_ThoiGian (ThoiGian),
    INDEX IX_NhatKy_HanhDong (HanhDong)
);

INSERT INTO LoaiThuoc (TenLoai, MoTa) VALUES
(N'Thuốc kháng sinh', N'Thuốc dùng để điều trị nhiễm trùng do vi khuẩn.'),
(N'Thuốc giảm đau', N'Thuốc dùng để giảm đau và hạ sốt.'),
(N'Thuốc chống viêm', N'Thuốc dùng để giảm viêm và sưng.'),
(N'Thuốc tim mạch', N'Thuốc dùng để điều trị các bệnh liên quan đến tim mạch.'),
(N'Thuốc điều trị tiểu đường', N'Thuốc dùng để kiểm soát lượng đường trong máu.');

INSERT INTO DanhMucThuoc (MaLoai, TenDanhMuc, MoTa) VALUES
(1, N'Thuốc kháng sinh phổ rộng', N'Thuốc kháng sinh có tác dụng trên nhiều loại vi khuẩn.'),
(1, N'Thuốc kháng sinh đặc hiệu', N'Thuốc kháng sinh có tác dụng trên một số loại vi khuẩn nhất định.'),
(2, N'Thuốc giảm đau không steroid', N'Thuốc giảm đau không chứa steroid.'),
(2, N'Thuốc giảm đau có steroid', N'Thuốc giảm đau có chứa steroid.'),
(3, N'Thuốc chống viêm không steroid', N'Thuốc chống viêm không chứa steroid.'),
(4, N'Thuốc điều trị huyết áp', N'Thuốc dùng để điều trị huyết áp cao.'),
(5, N'Thuốc điều trị tiểu đường loại 1', N'Thuốc dùng cho bệnh nhân tiểu đường loại 1.'),
(5, N'Thuốc điều trị tiểu đường loại 2', N'Thuốc dùng cho bệnh nhân tiểu đường loại 2.');

INSERT INTO VaiTro (TenVaiTro, MoTa)
VALUES 
(N'Quản trị', N'Quản lý toàn bộ hệ thống, phân quyền và cấu hình'),
(N'Bác sĩ', N'Quản lý bệnh nhân, lập hồ sơ khám, kê đơn thuốc'),
(N'Nhân viên', N'Quản lý bệnh nhân, đặt lịch khám, lập hóa đơn'),
(N'Kế toán', N'Quản lý hóa đơn, thanh toán, báo cáo tài chính');

INSERT INTO Quyen (TenQuyen, MoTa)
VALUES 
(N'Xem bệnh nhân', N'Quyền xem thông tin bệnh nhân'),
(N'Thêm bệnh nhân', N'Quyền thêm bệnh nhân mới vào hệ thống'),
(N'Sửa bệnh nhân', N'Quyền chỉnh sửa thông tin bệnh nhân'),
(N'Xóa bệnh nhân', N'Quyền xóa bệnh nhân khỏi hệ thống'),
(N'Xem lịch khám', N'Quyền xem lịch khám của bệnh nhân'),
(N'Quản lý lịch khám', N'Quyền thêm, sửa, xóa lịch khám bệnh nhân'),
(N'Thêm bác sĩ', N'Quyền thêm thông tin bác sĩ vào hệ thống'),
(N'Sửa bác sĩ', N'Quyền chỉnh sửa thông tin bác sĩ'),
(N'Xóa bác sĩ', N'Quyền xóa thông tin bác sĩ'),
(N'Quản lý thuốc', N'Quyền thêm, sửa, xóa thuốc trong hệ thống'),
(N'Xem thuốc', N'Quyền xem thông tin thuốc trong kho'),
(N'Quản lý hóa đơn', N'Quyền tạo và quản lý hóa đơn bệnh nhân'),
(N'Thêm tài khoản', N'Quyền thêm tài khoản người dùng mới vào hệ thống'),
(N'Sửa tài khoản', N'Quyền chỉnh sửa thông tin tài khoản người dùng'),
(N'Xóa tài khoản', N'Quyền xóa tài khoản người dùng khỏi hệ thống'),
(N'Phân quyền tài khoản', N'Quyền phân quyền cho các tài khoản người dùng'),
(N'Xem báo cáo thống kê', N'Quyền xem các báo cáo thống kê của hệ thống'),
(N'Quản lý bệnh nhân', N'Quyền quản lý bệnh nhân, cập nhật thông tin bệnh nhân');

INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(1, 1),  -- Quản trị viên có quyền "Xem bệnh nhân"
(1, 2),  -- Quản trị viên có quyền "Thêm bệnh nhân"
(1, 3),  -- Quản trị viên có quyền "Sửa bệnh nhân"
(1, 4),  -- Quản trị viên có quyền "Xóa bệnh nhân"
(1, 5),  -- Quản trị viên có quyền "Xem lịch khám"
(1, 6),  -- Quản trị viên có quyền "Quản lý lịch khám"
(1, 7),  -- Quản trị viên có quyền "Thêm bác sĩ"
(1, 8),  -- Quản trị viên có quyền "Sửa bác sĩ"
(1, 9),  -- Quản trị viên có quyền "Xóa bác sĩ"
(1, 10), -- Quản trị viên có quyền "Quản lý thuốc"
(1, 11), -- Quản trị viên có quyền "Xem thuốc"
(1, 12), -- Quản trị viên có quyền "Quản lý hóa đơn"
(1, 13), -- Quản trị viên có quyền "Thêm tài khoản"
(1, 14), -- Quản trị viên có quyền "Sửa tài khoản"
(1, 15), -- Quản trị viên có quyền "Xóa tài khoản"
(1, 16), -- Quản trị viên có quyền "Phân quyền tài khoản"
(1, 17), -- Quản trị viên có quyền "Xem báo cáo thống kê"
(1, 18); -- Quản trị viên có quyền "Quản lý bệnh nhân"

-- Quyền cho Bác sĩ
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(2, 1),  -- Bác sĩ có quyền "Xem bệnh nhân"
(2, 2),  -- Bác sĩ có quyền "Thêm bệnh nhân"
(2, 3),  -- Bác sĩ có quyền "Sửa bệnh nhân"
(2, 5),  -- Bác sĩ có quyền "Xem lịch khám"
(2, 6),  -- Bác sĩ có quyền "Quản lý lịch khám"
(2, 7),  -- Bác sĩ có quyền "Thêm bác sĩ"
(2, 8);  -- Bác sĩ có quyền "Sửa bác sĩ"

-- Quyền cho Nhân viên
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(3, 1),  -- Nhân viên có quyền "Xem bệnh nhân"
(3, 2),  -- Nhân viên có quyền "Thêm bệnh nhân"
(3, 5),  -- Nhân viên có quyền "Xem lịch khám"
(3, 6),  -- Nhân viên có quyền "Quản lý lịch khám"
(3, 12), -- Nhân viên có quyền "Quản lý hóa đơn"
(3, 13), -- Nhân viên có quyền "Thêm tài khoản"
(3, 14); -- Nhân viên có quyền "Sửa tài khoản"

-- Quyền cho Kế toán
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen)
VALUES 
(4, 1),  -- Kế toán có quyền "Xem bệnh nhân"
(4, 12), -- Kế toán có quyền "Quản lý hóa đơn"
(4, 16), -- Kế toán có quyền "Phân quyền tài khoản"
(4, 17); -- Kế toán có quyền "Xem báo cáo thống kê"

-- Bảng Nhân viên (10 records)
INSERT INTO NhanVien (HoTen, ChucVu, Email, SoDienThoai, DiaChi, NgayVaoLam, TrangThai)
VALUES
(N'Nguyễn Văn Anh', N'Lễ tân', 'nguyen.anh@phongkham.com', '0912345678', N'123 Đường Lê Lợi, Quận 1, TP.HCM', '2020-05-15', 1),
(N'Trần Thị Bích', N'Kế toán', 'tran.bich@phongkham.com', '0923456789', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM', '2019-11-20', 1),
(N'Lê Văn Cường', N'Quản lý', 'le.cuong@phongkham.com', '0934567890', N'789 Đường Pasteur, Quận 3, TP.HCM', '2018-03-10', 1),
(N'Phạm Thị Dung', N'Y tá', 'pham.dung@phongkham.com', '0945678901', N'321 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', '2021-02-28', 1),
(N'Hoàng Văn Đức', N'Bảo vệ', 'hoang.duc@phongkham.com', '0956789012', N'654 Đường 3 Tháng 2, Quận 10, TP.HCM', '2020-07-15', 1),
(N'Vũ Thị Hà', N'Lễ tân', 'vu.ha@phongkham.com', '0967890123', N'987 Đường Lý Thái Tổ, Quận 3, TP.HCM', '2022-01-05', 1),
(N'Đặng Văn Minh', N'Kỹ thuật viên', 'dang.minh@phongkham.com', '0978901234', N'147 Đường Lê Văn Sỹ, Quận Phú Nhuận, TP.HCM', '2021-09-12', 1),
(N'Bùi Thị Ngọc', N'Y tá', 'bui.ngoc@phongkham.com', '0989012345', N'258 Đường Lê Quang Định, Quận Gò Vấp, TP.HCM', '2019-06-30', 1),
(N'Ngô Văn Phong', N'Kế toán', 'ngo.phong@phongkham.com', '0990123456', N'369 Đường Nguyễn Văn Trỗi, Quận Tân Bình, TP.HCM', '2020-10-22', 1),
(N'Mai Thị Quyên', N'Quản lý kho', 'mai.quyen@phongkham.com', '0901234567', N'159 Đường Thống Nhất, Quận Tân Bình, TP.HCM', '2021-04-18', 1);

-- Bảng Bác sĩ (10 records)
INSERT INTO BacSi (HoTen, ChuyenKhoa, BangCap, SoDienThoai, Email, GioiThieu, TrangThai)
VALUES
(N'Trần Văn Bách', N'Nội khoa', N'Bác sĩ chuyên khoa II Nội khoa - ĐH Y Dược TP.HCM', '0911222333', 'bach.tv@phongkham.com', N'Chuyên điều trị các bệnh lý nội khoa tổng quát, bệnh cao huyết áp, tiểu đường. Kinh nghiệm 15 năm.', 1),
(N'Lê Thị Minh Châu', N'Nhi khoa', N'Tiến sĩ Nhi khoa - ĐH Y Hà Nội (2015)', '0922333444', 'chau.lt@phongkham.com', N'Chuyên về nhi khoa với 12 năm kinh nghiệm, đặc biệt về miễn dịch và tiêm chủng. Nguyên trưởng khoa Nhi BV Nhi Đồng 1.', 1),
(N'Nguyễn Hữu Đạt', N'Tim mạch', N'Phó giáo sư, Bác sĩ chuyên khoa Tim mạch - BV Chợ Rẫy (2018)', '0933444555', 'dat.nh@phongkham.com', N'Chuyên can thiệp tim mạch, từng đào tạo tại Pháp. Có hơn 500 ca can thiệp thành công.', 1),
(N'Hoàng Thị Kim Liên', N'Sản phụ khoa', N'Bác sĩ chuyên khoa I Sản phụ khoa - ĐH Y Dược Huế (2010)', '0944555666', 'lien.ht@phongkham.com', N'Chuyên thăm khám thai, siêu âm sản khoa, tư vấn sức khỏe sinh sản. Kinh nghiệm 13 năm.', 1),
(N'Phạm Văn Nam', N'Thần kinh', N'Tiến sĩ Thần kinh học - ĐH Y Dược TP.HCM (2017)', '0955666777', 'nam.pv@phongkham.com', N'Chuyên điều trị đột quỵ, Parkinson, động kinh. Từng công tác tại BV Bạch Mai.', 1),
(N'Võ Thị Ngọc Anh', N'Da liễu', N'Bác sĩ chuyên khoa II Da liễu - BV Da liễu TW (2019)', '0966777888', 'anh.vt@phongkham.com', N'Chuyên điều trị mụn, nám, lão hóa da. Được đào tạo thẩm mỹ tại Hàn Quốc.', 1),
(N'Đặng Văn Phúc', N'Tiêu hóa', N'Thạc sĩ Nội soi tiêu hóa - ĐH Y Dược TP.HCM (2016)', '0977888999', 'phuc.dv@phongkham.com', N'Chuyên nội soi chẩn đoán và điều trị các bệnh lý dạ dày, đại tràng. Kinh nghiệm 10 năm.', 1),
(N'Bùi Thị Quỳnh', N'Tai mũi họng', N'Bác sĩ chuyên khoa I Tai Mũi Họng (2014)', '0988999000', 'quynh.bt@phongkham.com', N'Chuyên phẫu thuật nội soi xoang, cắt amidan, điều trị viêm tai giữa. Từng công tác tại BV TMH TW.', 1),
(N'Lương Văn Sơn', N'Xương khớp', N'Bác sĩ chuyên khoa Cơ xương khớp - ĐH Y Phạm Ngọc Thạch (2013)', '0999000111', 'son.lv@phongkham.com', N'Chuyên trị thoái hóa khớp, thoát vị đĩa đệm. Được đào tạo phẫu thuật nội soi tại Singapore.', 1),
(N'Ngô Thị Thu Hà', N'Mắt', N'Tiến sĩ Nhãn khoa - ĐH Y Dược TP.HCM (2018)', '0900111222', 'ha.nt@phongkham.com', N'Chuyên khám và phẫu thuật đục thủy tinh thể, LASIK điều trị cận thị. Kinh nghiệm 9 năm.', 1);

-- Bảng Bệnh nhân (20 records)
INSERT INTO BenhNhan (HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi, Email, TienSuBenh, NgheNghiep, NgayDangKy, TrangThai)
VALUES
(N'Nguyễn Văn A', '1985-01-15', 'M', '0912345678', N'123 Đường Lê Lợi, Quận 1, TP.HCM', 'a.nguyen@domain.com', N'Không có', N'Kỹ sư', GETDATE(), 1),
(N'Trần Thị B', '1990-02-20', 'F', '0923456789', N'456 Đường Nguyễn Huệ, Quận 1, TP.HCM', 'b.tran@domain.com', N'Tiểu đường', N'Giáo viên', GETDATE(), 1),
(N'Lê Văn C', '1980-03-10', 'M', '0934567890', N'789 Đường Pasteur, Quận 3, TP.HCM', 'c.le@domain.com', N'Không có', N'Nhân viên văn phòng', GETDATE(), 1),
(N'Phạm Thị D', '1975-04-25', 'F', '0945678901', N'321 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', 'd.pham@domain.com', N'Khó thở', N'Nội trợ', GETDATE(), 1),
(N'Hoàng Văn E', '1995-05-30', 'M', '0956789012', N'654 Đường 3 Tháng 2, Quận 10, TP.HCM', 'e.hoang@domain.com', N'Không có', N'Sinh viên', GETDATE(), 1),
(N'Vũ Thị F', '1988-06-15', 'F', '0967890123', N'987 Đường Lý Thái Tổ, Quận 3, TP.HCM', 'f.vu@domain.com', N'Viêm họng', N'Nhân viên bán hàng', GETDATE(), 1),
(N'Đặng Văn G', '1982-07-20', 'M', '0978901234', N'147 Đường Lê Văn Sỹ, Quận Phú Nhuận, TP.HCM', 'g.dang@domain.com', N'Không có', N'Kỹ thuật viên', GETDATE(), 1),
(N'Bùi Thị H', '1992-08-05', 'F', '0989012345', N'258 Đường Lê Quang Định, Quận Gò Vấp, TP.HCM', 'h.bui@domain.com', N'Khó ngủ', N'Sinh viên', GETDATE(), 1),
(N'Ngô Văn I', '1983-09-10', 'M', '0990123456', N'369 Đường Nguyễn Văn Trỗi, Quận Tân Bình, TP.HCM', 'i.ngo@domain.com', N'Không có', N'Nhân viên IT', GETDATE(), 1),
(N'Mai Thị J', '1991-10-15', 'F', '0901234567', N'159 Đường Thống Nhất, Quận Tân Bình, TP.HCM', 'j.mai@domain.com', N'Đau đầu', N'Nhân viên văn phòng', GETDATE(), 1),
(N'Nguyễn Văn K', '1980-11-20', 'M', '0912345670', N'123 Đường Nguyễn Thị Minh Khai, Quận 1, TP.HCM', 'k.nguyen@domain.com', N'Không có', N'Kỹ sư', GETDATE(), 1),
(N'Trần Thị L', '1985-12-25', 'F', '0923456781', N'456 Đường Trần Hưng Đạo, Quận 5, TP.HCM', 'l.tran@domain.com', N'Viêm khớp', N'Giáo viên', GETDATE(), 1),
(N'Lê Văn M', '1993-01-30', 'M', '0934567892', N'789 Đường Phan Đình Phùng, Quận Phú Nhuận, TP.HCM', 'm.le@domain.com', N'Không có', N'Sinh viên', GETDATE(), 1),
(N'Phạm Thị N', '1987-02-28', 'F', '0945678903', N'321 Đường Nguyễn Thái Bình, Quận 1, TP.HCM', 'n.pham@domain.com', N'Khó thở', N'Nội trợ', GETDATE(), 1),
(N'Hoàng Văn O', '1994-03-15', 'M', '0956789014', N'654 Đường Lê Văn Sỹ, Quận 10, TP.HCM', 'o.hoang@domain.com', N'Không có', N'Nhân viên bán hàng', GETDATE(), 1),
(N'Vũ Thị P', '1989-04-20', 'F', '0967890125', N'987 Đường Nguyễn Huệ, Quận 1, TP.HCM', 'p.vu@domain.com', N'Viêm họng', N'Nhân viên văn phòng', GETDATE(), 1),
(N'Đặng Văn Q', '1981-05-25', 'M', '0978901236', N'147 Đường Cách Mạng Tháng 8, Quận 10, TP.HCM', 'q.dang@domain.com', N'Không có', N'Kỹ thuật viên', GETDATE(), 1),
(N'Bùi Thị R', '1996-06-30', 'F', '0989012347', N'258 Đường Lý Thái Tổ, Quận 3, TP.HCM', 'r.bui@domain.com', N'Khó ngủ', N'Sinh viên', GETDATE(), 1);

-- Bảng Lịch khám (20 records)
INSERT INTO LichKham (MaBN, MaBS, NgayKham, GioKham, ThoiGianDuKien, LyDo, TrangThai, NgayTao, GhiChu)
VALUES
(1, 1, '2023-10-20', '08:00', 30, N'Khám sức khỏe tổng quát', N'Đặt lịch', GETDATE(), NULL),
(2, 2, '2023-10-21', '09:00', 30, N'Khám bệnh tiểu đường', N'Đặt lịch', GETDATE(), NULL),
(3, 3, '2023-10-22', '10:00', 30, N'Khám tim mạch', N'Đặt lịch', GETDATE(), NULL),
(4, 4, '2023-10-23', '11:00', 30, N'Khám sản phụ khoa', N'Đặt lịch', GETDATE(), NULL),
(5, 5, '2023-10-24', '14:00', 30, N'Khám thần kinh', N'Đặt lịch', GETDATE(), NULL),
(6, 6, '2023-10-25', '15:00', 30, N'Khám da liễu', N'Đặt lịch', GETDATE(), NULL),
(7, 7, '2023-10-26', '16:00', 30, N'Khám tiêu hóa', N'Đặt lịch', GETDATE(), NULL),
(8, 8, '2023-10-27', '08:30', 30, N'Khám tai mũi họng', N'Đặt lịch', GETDATE(), NULL),
(9, 9, '2023-10-28', '09:30', 30, N'Khám xương khớp', N'Đặt lịch', GETDATE(), NULL),
(10, 10, '2023-10-29', '10:30', 30, N'Khám mắt', N'Đặt lịch', GETDATE(), NULL),
(1, 2, '2023-10-30', '11:30', 30, N'Tái khám bệnh tiểu đường', N'Đặt lịch', GETDATE(), NULL),
(2, 3, '2023-10-31', '14:30', 30, N'Tái khám tim mạch', N'Đặt lịch', GETDATE(), NULL),
(3, 4, '2023-11-01', '15:30', 30, N'Tái khám sản phụ khoa', N'Đặt lịch', GETDATE(), NULL),
(4, 5, '2023-11-02', '16:30', 30, N'Tái khám thần kinh', N'Đặt lịch', GETDATE(), NULL),
(5, 6, '2023-11-03', '08:00', 30, N'Tái khám da liễu', N'Đặt lịch', GETDATE(), NULL),
(6, 7, '2023-11-04', '09:00', 30, N'Tái khám tiêu hóa', N'Đặt lịch', GETDATE(), NULL),
(7, 8, '2023-11-05', '10:00', 30, N'Tái khám tai mũi họng', N'Đặt lịch', GETDATE(), NULL),
(8, 9, '2023-11-06', '11:00', 30, N'Tái khám xương khớp', N'Đặt lịch', GETDATE(), NULL),
(9, 10, '2023-11-07', '14:00', 30, N'Tái khám mắt', N'Đặt lịch', GETDATE(), NULL),
(10, 1, '2023-11-08', '15:00', 30, N'Khám sức khỏe tổng quát', N'Đặt lịch', GETDATE(), NULL);

-- Bảng Hồ sơ khám (20 records)
INSERT INTO HoSoKham (MaLichKham, TrieuChung, ChanDoan, LoiDan, NgayTaiKham, DaThanhToan)
VALUES
-- Các hồ sơ khám đã hoàn thành
(1, N'Mệt mỏi, chán ăn, đau đầu nhẹ', N'Thiếu máu nhẹ', N'Uống thuốc đều, bổ sung sắt, ăn uống đủ chất', '2023-11-20', 1),
(2, N'Khát nước, tiểu nhiều, sụt cân 3kg', N'Tiểu đường type 2', N'Kiểm tra đường huyết hàng ngày, hạn chế đồ ngọt', '2023-11-25', 1),
(3, N'Đau ngực trái, khó thở khi vận động', N'Rối loạn nhịp tim', N'Hạn chế cà phê, theo dõi huyết áp hàng ngày', '2023-11-28', 1),
(4, N'Trễ kinh 2 tuần, buồn nôn', N'Có thai 8 tuần', N'Uống bổ sung sắt, khám thai định kỳ', '2023-12-05', 1),
(5, N'Tê tay chân, đau nửa đầu', N'Thiếu máu não', N'Nghỉ ngơi đủ, hạn chế thức khuya', '2023-12-10', 1),

-- Các hồ sơ khám chuyên khoa
(6, N'Nổi mẩn đỏ, ngứa toàn thân', N'Dị ứng thời tiết', N'Uống thuốc đều, tránh tiếp xúc với phấn hoa', '2023-12-15', 0),
(7, N'Đau bụng âm ỉ vùng thượng vị', N'Viêm dạ dày cấp', N'Ăn uống đúng giờ, hạn chế đồ chua cay', '2023-12-20', 0),
(8, N'Ù tai, nghe kém tai trái', N'Viêm tai giữa', N'Giữ tai khô ráo, tránh nước vào tai', '2023-12-25', 0),
(9, N'Đau khớp gối khi leo cầu thang', N'Thoái hóa khớp gối độ 1', N'Hạn chế vận động mạnh, tập vật lý trị liệu', '2024-01-05', 0),
(10, N'Mờ mắt, nhức mắt khi đọc sách', N'Cận thị 2.5 độ', N'Hạn chế dùng điện thoại trong bóng tối', '2024-01-10', 0),

-- Các hồ sơ khám tổng quát
(11, N'Ho khan, đau họng, sốt nhẹ', N'Viêm họng cấp', N'Uống nhiều nước ấm, súc họng nước muối', '2023-12-01', 1),
(12, N'Đau bụng, tiêu chảy 3 ngày', N'Rối loạn tiêu hóa', N'Ăn cháo loãng, uống oresol bù nước', '2023-12-03', 1),
(13, N'Mất ngủ, căng thẳng kéo dài', N'Rối loạn lo âu', N'Tập thể dục nhẹ, hạn chế cà phê', '2023-12-07', 0),
(14, N'Đau lưng sau khi mang vác nặng', N'Căng cơ lưng', N'Xoa bóp, chườm ấm, hạn chế vận động mạnh', '2023-12-12', 0),
(15, N'Chóng mặt khi thay đổi tư thế', N'Huyết áp thấp tư thế', N'Đứng lên từ từ, uống đủ nước', '2023-12-17', 0),

-- Các hồ sơ khám khác
(16, N'Sổ mũi, hắt hơi, ngứa mũi', N'Viêm mũi dị ứng', N'Tránh tiếp xúc với bụi, lông thú', '2023-12-22', 0),
(17, N'Đau răng hàm dưới bên phải', N'Sâu răng số 6', N'Hẹn lấy tủy sau 3 ngày', '2023-12-27', 0),
(18, N'Da mặt nổi nhiều mụn viêm', N'Viêm nang lông mặt', N'Vệ sinh da mặt đúng cách, không nặn mụn', '2024-01-15', 0),
(19, N'Tê bì tay phải về đêm', N'Hội chứng ống cổ tay', N'Mang nẹp cổ tay khi ngủ', '2024-01-20', 0),
(20, N'Đau vai gáy kéo dài', N'Thoái hóa đốt sống cổ', N'Tập các bài tập cổ, tránh ngồi lâu', '2024-01-25', 0);

-- Thuốc kháng sinh phổ rộng (MaLoai = 1, MaDanhMuc = 1)
INSERT INTO Thuoc (TenThuoc, DonViTinh, DonGiaBan, SoLuongTon, HanSuDung, NhaSanXuat, CachDung, MaLoai, MaDanhMuc) VALUES
(N'Amoxicillin 500mg', N'Viên', 25000.00, 150, '2025-12-31', N'Pharma SV', N'2 viên/ngày sau ăn', 1, 1),
(N'Azithromycin 250mg', N'Viên', 35000.00, 80, '2026-03-15', N'Dược Hậu Giang', N'1 viên/ngày, uống xa bữa ăn', 1, 1),
(N'Cephalexin 500mg', N'Viên', 28000.00, 120, '2025-10-20', N'Opsonin', N'3 lần/ngày, mỗi lần 1 viên', 1, 1),
(N'Doxycycline 100mg', N'Viên', 32000.00, 90, '2026-01-30', N'Stada', N'1 viên/ngày, uống nhiều nước', 1, 1),
(N'Ciprofloxacin 500mg', N'Viên', 30000.00, 70, '2025-11-15', N'Bayer', N'2 lần/ngày cách 12 tiếng', 1, 1),

-- Thuốc kháng sinh đặc hiệu (MaLoai = 1, MaDanhMuc = 2)
(N'Metronidazole 250mg', N'Viên', 18000.00, 100, '2025-09-30', N'Pharbaco', N'3 lần/ngày sau ăn', 1, 2),
(N'Clindamycin 300mg', N'Viên', 42000.00, 60, '2026-02-28', N'Pymepharco', N'4 lần/ngày', 1, 2),
(N'Vancomycin 500mg', N'Lọ', 250000.00, 30, '2025-12-31', N'Pfizer', N'Tiêm tĩnh mạch theo chỉ định', 1, 2),

-- Thuốc giảm đau không steroid (MaLoai = 2, MaDanhMuc = 3)
(N'Paracetamol 500mg', N'Viên', 5000.00, 300, '2025-06-30', N'OPV', N'Uống khi sốt trên 38.5°C', 2, 3),
(N'Ibuprofen 400mg', N'Viên', 12000.00, 200, '2025-08-15', N'Dược Hà Tây', N'3 lần/ngày sau ăn', 2, 3),
(N'Aspirin 81mg', N'Viên', 8000.00, 180, '2026-01-01', N'Bayer', N'1 viên/ngày buổi sáng', 2, 3),
(N'Diclofenac 50mg', N'Viên', 15000.00, 150, '2025-09-30', N'Novartis', N'2 lần/ngày với nhiều nước', 2, 3),

-- Thuốc giảm đau có steroid (MaLoai = 2, MaDanhMuc = 4)
(N'Prednisolon 5mg', N'Viên', 22000.00, 100, '2025-07-31', N'Pymepharco', N'Theo chỉ định bác sĩ', 2, 4),
(N'Dexamethasone 4mg', N'Viên', 18000.00, 80, '2026-03-30', N'Stada', N'Uống buổi sáng sau ăn', 2, 4),

-- Thuốc chống viêm không steroid (MaLoai = 3, MaDanhMuc = 5)
(N'Meloxicam 15mg', N'Viên', 35000.00, 120, '2025-11-30', N'Boehringer', N'1 viên/ngày với nhiều nước', 3, 5),
(N'Celecoxib 200mg', N'Viên', 40000.00, 90, '2026-02-15', N'Pharmedic', N'2 lần/ngày sau ăn', 3, 5),
(N'Etoricoxib 90mg', N'Viên', 45000.00, 70, '2025-10-20', N'EUROPHARMA', N'1 viên/ngày không quá 8 ngày', 3, 5),

-- Thuốc tim mạch - huyết áp (MaLoai = 4, MaDanhMuc = 6)
(N'Amlodipine 5mg', N'Viên', 25000.00, 150, '2026-05-31', N'Pharmedic', N'Uống 1 lần/ngày', 4, 6),
(N'Bisoprolol 5mg', N'Viên', 30000.00, 120, '2026-04-15', N'Domesco', N'Không ngưng đột ngột', 4, 6),
(N'Losartan 50mg', N'Viên', 35000.00, 100, '2025-12-31', N'Pfizer', N'Uống đúng giờ mỗi ngày', 4, 6),
(N'Valsartan 80mg', N'Viên', 40000.00, 80, '2025-11-30', N'Novartis', N'1 viên/ngày buổi sáng', 4, 6),
(N'Furosemid 40mg', N'Viên', 18000.00, 90, '2025-09-30', N'Opsonin', N'Uống buổi sáng sau ăn', 4, 6),

-- Thuốc tiểu đường loại 1 (MaLoai = 5, MaDanhMuc = 7)
(N'Insulin Mixtard 30/70', N'Bút', 320000.00, 50, '2025-12-31', N'Novo Nordisk', N'Tiêm dưới da 2 lần/ngày', 5, 7),
(N'Lantus SoloStar', N'Bút', 380000.00, 40, '2026-03-31', N'Sanofi', N'Tiêm 1 lần/ngày trước ngủ', 5, 7),

-- Thuốc tiểu đường loại 2 (MaLoai = 5, MaDanhMuc = 8)
(N'Metformin 500mg', N'Viên', 15000.00, 200, '2025-10-31', N'Pharbaco', N'2 viên/ngày sau bữa ăn', 5, 8),
(N'Glibenclamid 5mg', N'Viên', 25000.00, 150, '2025-09-30', N'Pymepharco', N'1 viên trước bữa sáng', 5, 8),
(N'Sitagliptin 100mg', N'Viên', 45000.00, 100, '2026-01-15', N'MSD', N'1 viên/ngày bất kể bữa ăn', 5, 8),
(N'Empagliflozin 10mg', N'Viên', 50000.00, 80, '2026-02-28', N'Boehringer', N'Uống buổi sáng', 5, 8),

-- Các thuốc khác
(N'Morphin sulfat 10mg', N'Ống', 85000.00, 30, '2025-08-31', N'Domesco', N'Chỉ dùng khi có chỉ định', 2, 4),
(N'Oxycodon 5mg', N'Viên', 60000.00, 40, '2025-07-15', N'Mundipharma', N'Giảm đau mức độ nặng', 2, 4),
(N'Simvastatin 20mg', N'Viên', 28000.00, 120, '2026-04-30', N'Pymepharco', N'Uống buổi tối trước ngủ', 4, 6),
(N'Atorvastatin 10mg', N'Viên', 35000.00, 100, '2025-12-31', N'Dược Hậu Giang', N'Uống bất kỳ thời điểm nào', 4, 6),
(N'Clopidogrel 75mg', N'Viên', 42000.00, 90, '2026-03-15', N'Sanofi', N'1 viên/ngày kèm ăn', 4, 6),
(N'Warfarin 5mg', N'Viên', 38000.00, 60, '2025-09-30', N'Stada', N'Uống đúng giờ mỗi ngày', 4, 6),
(N'Captopril 25mg', N'Viên', 20000.00, 80, '2025-10-31', N'DHG Pharma', N'3 lần/ngày trước bữa ăn', 4, 6),
(N'Spironolacton 25mg', N'Viên', 18000.00, 70, '2026-01-15', N'Pymepharco', N'Dùng kèm với thuốc lợi tiểu khác', 4, 6),
(N'Digoxin 0.25mg', N'Viên', 30000.00, 50, '2025-08-31', N'OPV', N'Theo dõi nồng độ máu', 4, 6),
(N'Salbutamol 100mcg', N'Bình xịt', 65000.00, 40, '2026-05-31', N'GSK', N'Xịt khi lên cơn khó thở', 3, 5),
(N'Budesonid 200mcg', N'Bình xịt', 85000.00, 30, '2026-04-30', N'AstraZeneca', N'Xịt phòng ngừa viêm phế quản', 3, 5),
(N'Sertraline 50mg', N'Viên', 55000.00, 60, '2025-12-31', N'Pfizer', N'1 viên/ngày buổi sáng', 3, 5);

-- Bảng Đơn thuốc (30 records)
INSERT INTO DonThuoc (MaHoSo, MaThuoc, SoLuong, LieuDung, Sang, Trua, Chieu, Toi, SoNgay, GhiChu)
VALUES
-- Đơn thuốc cho hồ sơ từ 1-10 (các bệnh thông thường)
(1, 1, 10, N'Uống sau ăn', 1, 0, 1, 0, 5, N'Uống đủ liều'),
(2, 5, 20, N'Uống sau ăn sáng, tối', 1, 0, 1, 0, 10, N'Theo dõi đường huyết'),
(3, 12, 14, N'Uống buổi sáng', 1, 0, 0, 0, 14, N'Kiểm tra huyết áp hàng ngày'),
(4, 20, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Bổ sung vitamin'),
(5, 7, 15, N'Uống sau ăn', 1, 0, 1, 0, 7, N'Dùng khi đau đầu'),

(6, 25, 1, N'Bôi ngày 2 lần', 1, 0, 1, 0, 7, N'Bôi mỏng lớp'),
(7, 6, 21, N'Uống 3 lần/ngày', 1, 1, 1, 0, 7, N'Dùng sau ăn no'),
(8, 30, 10, N'Nhỏ tai ngày 3 lần', 1, 1, 1, 0, 5, N'Vệ sinh tai sạch'),
(9, 24, 14, N'Uống sáng chiều', 1, 0, 1, 0, 14, N'Uống nhiều nước'),
(10, 15, 14, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Kết hợp tập mắt'),

-- Đơn thuốc cho hồ sơ từ 11-20 (các bệnh cấp tính)
(11, 2, 14, N'Uống 2 lần/ngày', 1, 0, 1, 0, 7, N'Uống nhiều nước'),
(12, 33, 10, N'Pha uống ngày 3 gói', 1, 1, 1, 0, 3, N'Uống sau mỗi lần đi ngoài'),
(13, 19, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Nghỉ ngơi đầy đủ'),
(14, 8, 10, N'Uống khi đau', 0, 0, 0, 1, 5, N'Không quá 4 viên/ngày'),
(15, 13, 28, N'Uống buổi sáng', 1, 0, 0, 0, 28, N'Theo dõi huyết áp'),

(16, 31, 14, N'Xịt mũi ngày 2 lần', 1, 0, 1, 0, 7, N'Vệ sinh mũi trước khi xịt'),
(17, 3, 10, N'Uống sau ăn trưa', 0, 1, 0, 0, 5, N'Không dùng khi đói'),
(18, 26, 1, N'Bôi ngày 2 lần', 1, 0, 1, 0, 7, N'Rửa mặt sạch trước khi bôi'),
(19, 22, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Kết hợp vật lý trị liệu'),
(20, 16, 14, N'Uống sau ăn tối', 0, 0, 0, 1, 14, N'Theo dõi đường huyết'),

-- Đơn thuốc cho các hồ sơ khác
(1, 9, 14, N'Uống sáng tối', 1, 0, 1, 0, 7, N'Không uống rượu bia'),
(2, 21, 60, N'Uống 3 lần/ngày', 1, 1, 1, 1, 20, N'Bổ sung canxi'),
(3, 18, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Tăng cường dinh dưỡng'),
(4, 29, 1, N'Xịt mũi ngày 1 lần', 1, 0, 0, 0, 30, N'Lắc kỹ trước khi dùng'),
(5, 10, 14, N'Uống trước ăn sáng', 1, 0, 0, 0, 14, N'Không nhai viên thuốc'),

(6, 4, 14, N'Uống sáng tối', 1, 0, 1, 0, 7, N'Tránh ánh nắng trực tiếp'),
(7, 32, 30, N'Ngày 2 gói', 1, 0, 1, 0, 15, N'Uống nhiều nước'),
(8, 35, 1, N'Pha 1 gói/200ml nước', 1, 1, 1, 0, 5, N'Uống từng ngụm nhỏ'),
(9, 23, 42, N'Uống 3 lần/ngày', 1, 1, 1, 0, 14, N'Sau khi ăn no'),
(10, 17, 28, N'Uống sáng tối', 1, 0, 1, 0, 14, N'Theo dõi đường huyết');

-- Bảng Hóa đơn (20 records)
INSERT INTO HoaDon (MaLichKham, MaNV, MaBenhNhan, NgayTao, TienKham, TienThuoc, GiamGia, HinhThucThanhToan, DaThanhToan, GhiChu)
VALUES
(1, 1, 1, GETDATE(), 100000, 50000, 10000, N'Tiền mặt', 0, N'Khám tổng quát'),
(1, 1, 2,  GETDATE(), 150000, 70000, 5000, N'Tiền mặt', 1, N'Khám chuyên khoa'),
(2, 2, 1,  GETDATE(), 120000, 60000, 0, N'Tiền mặt', 0, N'Khám sức khỏe'),
(2, 2, 3,  GETDATE(), 130000, 80000, 15000, N'Tiền mặt', 1, N'Khám bệnh'),
(3, 3, 2,  GETDATE(), 110000, 55000, 2000, N'Tiền mặt', 0, N'Khám định kỳ'),
(3, 3, 4,  GETDATE(), 140000, 90000, 10000, N'Tiền mặt', 1, N'Khám tim mạch'),
(4, 1, 1,  GETDATE(), 160000, 75000, 5000, N'Tiền mặt', 0, N'Khám mắt'),
(4, 1, 5,  GETDATE(), 170000, 85000, 0, N'Tiền mặt', 1, N'Khám phụ khoa'),
(5, 2, 3,  GETDATE(), 180000, 95000, 20000, N'Tiền mặt', 0, N'Khám nội khoa'),
(5, 2, 6,  GETDATE(), 190000, 100000, 15000, N'Tiền mặt', 1, N'Khám ngoại khoa'),
(6, 3, 4,  GETDATE(), 200000, 110000, 10000, N'Tiền mặt', 0, N'Khám da liễu'),
(6, 3, 7,  GETDATE(), 210000, 120000, 5000, N'Tiền mặt', 1, N'Khám tâm lý'),
(7, 1, 5,  GETDATE(), 220000, 130000, 0, N'Tiền mặt', 0, N'Khám dinh dưỡng'),
(7, 1, 8,  GETDATE(), 230000, 140000, 10000, N'Tiền mặt', 1, N'Khám thể thao'),
(8, 2, 6,  GETDATE(), 240000, 150000, 15000, N'Tiền mặt', 0, N'Khám thần kinh'),
(8, 2, 9,  GETDATE(), 250000, 160000, 20000, N'Tiền mặt', 1, N'Khám hô hấp'),
(9, 3, 7,  GETDATE(), 260000, 170000, 5000, N'Tiền mặt', 0, N'Khám tiết niệu'),
(9, 3, 10,  GETDATE(), 270000, 180000, 0, N'Tiền mặt', 1, N'Khám sản phụ'),
(10, 1, 8,  GETDATE(), 280000, 190000, 10000, N'Tiền mặt', 0, N'Khám tổng quát'),
(10, 1, 11,  GETDATE(), 290000, 200000, 15000, N'Tiền mặt', 1, N'Khám chuyên khoa');

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro, MaNhanVien, MaBacSi, Email, LanDangNhapCuoi, TrangThai, NgayTao, MaVaiTro) VALUES
(N'admin','Admin@123', N'Quản trị', NULL, NULL, N'admin@example.com', NULL, 1, GETDATE(), 1),
(N'doctor1', 'Doctor@123', N'Bác sĩ', NULL, 1, N'doctor1@example.com', NULL, 1, GETDATE(), 2),
(N'doctor2',  'Doctor@456', N'Bác sĩ', NULL, 2, N'doctor2@example.com', NULL, 1, GETDATE(), 2),
(N'staff1',  'Staff@123', N'Nhân viên', 1, NULL, N'staff1@example.com', NULL, 1, GETDATE(), 3),
(N'staff2',  'Staff@456', N'Nhân viên', 2, NULL, N'staff2@example.com', NULL, 1, GETDATE(), 3),
(N'accountant1',  'Accountant@123', N'Kế toán', NULL, NULL, N'accountant1@example.com', NULL, 1, GETDATE(), 4),
(N'admin2',  'Admin2@123', N'Quản trị', NULL, NULL, N'admin2@example.com', NULL, 1, GETDATE(), 1),
(N'doctor3',  'Doctor@789', N'Bác sĩ', NULL, 3, N'doctor3@example.com', NULL, 1, GETDATE(), 2),
(N'staff3',  'Staff@789', N'Nhân viên', 3, NULL, N'staff3@example.com', NULL, 1, GETDATE(), 3),
(N'accountant2', 'Accountant@456', N'Kế toán', NULL, NULL, N'accountant2@example.com', NULL, 1, GETDATE(), 4);

-- Bảng Nhật ký hệ thống (20 records)
INSERT INTO NhatKyHeThong (MaTaiKhoan, HanhDong, NoiDung, BangTacDong, MaBanGhi, ThoiGian, DiaChiIP)
VALUES
-- Nhật ký cho tài khoản quản trị viên
(1, N'Đăng nhập', N'Quản trị viên đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.1'),
(1, N'Truy vấn', N'Quản trị viên truy vấn danh sách bệnh nhân', N'BenhNhan', NULL, GETDATE(), '192.168.1.1'),
(1, N'Thêm', N'Quản trị viên thêm bác sĩ mới', N'BacSi', 1, GETDATE(), '192.168.1.1'),
(1, N'Sửa', N'Quản trị viên sửa thông tin nhân viên', N'NhanVien', 1, GETDATE(), '192.168.1.1'),
(1, N'Xóa', N'Quản trị viên xóa tài khoản nhân viên', N'TaiKhoan', 2, GETDATE(), '192.168.1.1'),

-- Nhật ký cho tài khoản kế toán
(2, N'Đăng nhập', N'Kế toán đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.2'),
(2, N'Truy vấn', N'Kế toán truy vấn hóa đơn', N'HoaDon', NULL, GETDATE(), '192.168.1.2'),
(2, N'Tải xuống', N'Kế toán tải xuống báo cáo tài chính', N'Báo cáo', NULL, GETDATE(), '192.168.1.2'),

-- Nhật ký cho tài khoản bác sĩ
(3, N'Đăng nhập', N'Bác sĩ đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.3'),
(3, N'Truy vấn', N'Bác sĩ truy vấn hồ sơ khám', N'HoSoKham', NULL, GETDATE(), '192.168.1.3'),
(3, N'Sửa', N'Bác sĩ sửa thông tin chẩn đoán', N'HoSoKham', 1, GETDATE(), '192.168.1.3'),

-- Nhật ký cho tài khoản nhân viên
(4, N'Đăng nhập', N'Nhân viên đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.4'),
(4, N'Truy vấn', N'Nhân viên truy vấn lịch khám', N'LichKham', NULL, GETDATE(), '192.168.1.4'),
(4, N'Thêm', N'Nhân viên thêm bệnh nhân mới', N'BenhNhan', 1, GETDATE(), '192.168.1.4'),

-- Nhật ký cho tài khoản khác
(5, N'Đăng nhập', N'Nhân viên đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.5'),
(5, N'Truy vấn', N'Nhân viên truy vấn danh sách thuốc', N'Thuoc', NULL, GETDATE(), '192.168.1.5'),
(5, N'Sửa', N'Nhân viên sửa thông tin thuốc', N'Thuoc', 1, GETDATE(), '192.168.1.5'),

-- Nhật ký cho tài khoản bác sĩ khác
(6, N'Đăng nhập', N'Bác sĩ đăng nhập vào hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.6'),
(6, N'Truy vấn', N'Bác sĩ truy vấn đơn thuốc', N'DonThuoc', NULL, GETDATE(), '192.168.1.6'),
(6, N'Tải xuống', N'Bác sĩ tải xuống báo cáo bệnh nhân', N'Báo cáo', NULL, GETDATE(), '192.168.1.6'),

-- Nhật ký cho tài khoản quản trị viên khác
(1, N'Đăng xuất', N'Quản trị viên đăng xuất khỏi hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.1'),
(2, N'Đăng xuất', N'Kế toán đăng xuất khỏi hệ thống', N'Tài khoản', NULL, GETDATE(), '192.168.1.2');

INSERT INTO PhieuNhapThuoc (MaNV, GhiChu, TrangThai, TongTien) VALUES
(1, N'Nhập thuốc định kỳ tháng 1', N'Đã nhập', 500000.00),
(2, N'Nhập thuốc khẩn cấp', N'Đã nhập', 300000.00),
(1, N'Nhập thuốc cho bệnh viện', N'Đã nhập', 700000.00),
(3, N'Nhập thuốc cho phòng khám', N'Đã nhập', 450000.00),
(2, N'Nhập thuốc bổ sung', N'Đã nhập', 600000.00);

INSERT INTO CT_PhieuNhap (MaPhieuNhap, MaThuoc, SoLuongNhap, DonGiaNhap) VALUES
(1, 1, 50, 25000.00), -- Amoxicillin
(1, 2, 30, 5000.00),  -- Paracetamol
(1, 3, 20, 12000.00), -- Ibuprofen
(2, 4, 10, 300000.00), -- Insulin
(2, 5, 15, 20000.00),  -- Atorvastatin
(3, 6, 25, 15000.00),  -- Omeprazole
(3, 7, 40, 25000.00),  -- Losartan
(4, 8, 60, 15000.00),  -- Metformin
(4, 9, 20, 18000.00),  -- Meloxicam
(5, 10, 10, 22000.00);  -- Prednisolon

INSERT INTO LichSuNhapThuoc (MaThuoc, SoLuongThayDoi, LoaiThayDoi, MaNV, GhiChu) VALUES
(1, 50, N'Nhập kho', 1, N'Nhập lần đầu'),
(2, 30, N'Nhập kho', 1, N'Nhập lần đầu'),
(3, 20, N'Nhập kho', 1, N'Nhập lần đầu'),
(4, 10, N'Nhập kho', 2, N'Nhập khẩn cấp'),
(5, 15, N'Nhập kho', 2, N'Nhập khẩn cấp'),
(6, 25, N'Nhập kho', 3, N'Nhập cho bệnh viện'),
(7, 40, N'Nhập kho', 3, N'Nhập cho phòng khám'),
(8, 60, N'Nhập kho', 3, N'Nhập bổ sung'),
(9, 20, N'Nhập kho', 1, N'Nhập bổ sung'),
(10, 10, N'Hủy nhập', 2, N'Hủy do lỗi nhập');

CREATE TABLE PhieuXuatThuoc (
    MaPhieuXuat INT IDENTITY(1,1) PRIMARY KEY,
    NgayXuat DATETIME NOT NULL DEFAULT GETDATE(),
    MaNV INT NOT NULL,  -- Nhân viên phụ trách xuất thuốc
    GhiChu NVARCHAR(255),

    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

CREATE TABLE CT_PhieuXuatThuoc (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuXuat INT NOT NULL,
    MaThuoc INT NOT NULL,
    SoLuongXuat INT NOT NULL CHECK (SoLuongXuat > 0),
    DonGiaXuat DECIMAL(18,2) NOT NULL CHECK (DonGiaXuat >= 0),
    ThanhTien AS (SoLuongXuat * DonGiaXuat) PERSISTED,

    FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuatThuoc(MaPhieuXuat),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc)
);

INSERT INTO PhieuXuatThuoc (NgayXuat, MaNV, GhiChu) VALUES
('2025-07-10', 1, N'Xuất thuốc theo đơn'),
('2025-07-11', 2, N'Xuất nội bộ'),
('2025-07-12', 3, N'Xuất cho phòng cấp cứu'),
('2025-07-12', 1, N'Xuất theo đơn BN Lê Văn A'),
('2025-07-13', 4, N'Xuất thuốc bổ sung'),
('2025-07-13', 2, N'Xuất hủy thuốc hết hạn'),
('2025-07-14', 5, N'Xuất theo đơn BN Nguyễn Thị B'),
('2025-07-15', 1, N'Xuất test tồn kho'),
('2025-07-16', 2, N'Xuất điều chỉnh kho'),
('2025-07-17', 3, N'Xuất cho bác sĩ trưởng khoa');

-- Seed dữ liệu cho bảng CT_PhieuXuatThuoc
INSERT INTO CT_PhieuXuatThuoc (MaPhieuXuat, MaThuoc, SoLuongXuat, DonGiaXuat)
VALUES 
(1, 1, 5, 12000),
(1, 2, 3, 18000),
(2, 3, 10, 5000),
(2, 4, 2, 25000),
(3, 5, 1, 100000),
(3, 1, 6, 11000),
(4, 6, 4, 22000),
(5, 7, 8, 7000),
(5, 2, 5, 19000),
(4, 8, 3, 15000);


>>>>>>> 89c2e69 (Chỉnh sửa tính năng XYZ)
