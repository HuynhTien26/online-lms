USE QL_ThiTracNghiem;
GO

-- ==========================================
-- 1. BẢNG KHOA
-- ==========================================
IF OBJECT_ID('Khoa', 'U') IS NULL
BEGIN
    CREATE TABLE Khoa (
        Ma_Khoa VARCHAR(20) PRIMARY KEY,
        Ten_Khoa NVARCHAR(100) NOT NULL
    );
END
GO

INSERT INTO Khoa (Ma_Khoa, Ten_Khoa)
SELECT 'CNTT', N'Công nghệ thông tin' WHERE NOT EXISTS (SELECT 1 FROM Khoa WHERE Ma_Khoa = 'CNTT')
UNION ALL SELECT 'KT', N'Kinh tế' WHERE NOT EXISTS (SELECT 1 FROM Khoa WHERE Ma_Khoa = 'KT')
UNION ALL SELECT 'NN', N'Ngoại ngữ' WHERE NOT EXISTS (SELECT 1 FROM Khoa WHERE Ma_Khoa = 'NN')
UNION ALL SELECT 'CB', N'Cơ bản' WHERE NOT EXISTS (SELECT 1 FROM Khoa WHERE Ma_Khoa = 'CB');
GO

-- ==========================================
-- 2. BẢNG LỚP
-- ==========================================
IF OBJECT_ID('Lop', 'U') IS NULL
BEGIN
    CREATE TABLE Lop (
        Ma_Lop VARCHAR(20) PRIMARY KEY,
        Ten_Lop NVARCHAR(100) NOT NULL,
        Ma_Khoa VARCHAR(20) NOT NULL REFERENCES Khoa(Ma_Khoa) ON UPDATE CASCADE
    );
END
GO

INSERT INTO Lop (Ma_Lop, Ten_Lop, Ma_Khoa)
SELECT 'A1', N'Lớp A1', 'CNTT' WHERE NOT EXISTS (SELECT 1 FROM Lop WHERE Ma_Lop = 'A1')
UNION ALL SELECT 'A2', N'Lớp A2', 'CNTT' WHERE NOT EXISTS (SELECT 1 FROM Lop WHERE Ma_Lop = 'A2')
UNION ALL SELECT 'DCT1231', N'Lớp DCT1231', 'CNTT' WHERE NOT EXISTS (SELECT 1 FROM Lop WHERE Ma_Lop = 'DCT1231')
UNION ALL SELECT 'DCT1232', N'Lớp DCT1232', 'CNTT' WHERE NOT EXISTS (SELECT 1 FROM Lop WHERE Ma_Lop = 'DCT1232')
UNION ALL SELECT 'KT01', N'Lớp KT01', 'KT' WHERE NOT EXISTS (SELECT 1 FROM Lop WHERE Ma_Lop = 'KT01');
GO

-- ==========================================
-- 3. BẢNG TÀI KHOẢN NGƯỜI DÙNG (ID TK + MẬT KHẨU MẶC ĐỊNH 123456 + TỰ ĐỔI MK)
-- ==========================================
IF OBJECT_ID('Tai_Khoan', 'U') IS NULL
BEGIN
    CREATE TABLE Tai_Khoan (
        Ma_TK VARCHAR(30) PRIMARY KEY,          -- ID tài khoản đăng nhập (VD: ADMIN01, GV01, SV01)
        Mat_Khau_Hash NVARCHAR(256) NOT NULL, -- Lưu chuỗi hash/mật khẩu (không trả về cho Admin)
        Loai_TK VARCHAR(10) NOT NULL,         -- 'AD', 'GV', 'SV'
        Trang_Thai VARCHAR(20) NOT NULL DEFAULT 'ACTIVE', -- 'ACTIVE', 'TEMP_LOCKED', 'LOCKED_BY_ADMIN'
        So_Lan_Sai INT NOT NULL DEFAULT 0,
        Khoa_Den_Luc DATETIME NULL,
        Bat_Buoc_Doi_MK BIT NOT NULL DEFAULT 1, -- 1 = đang dùng MK mặc định 123456
        Ngay_Doi_MK DATETIME NULL,
        Ngay_Tao DATETIME NOT NULL DEFAULT GETDATE()
    );
END
GO

-- Đảm bảo đủ cột nếu bảng Tai_Khoan đã tồn tại từ trước
IF COL_LENGTH('Tai_Khoan', 'So_Lan_Sai') IS NULL
    ALTER TABLE Tai_Khoan ADD So_Lan_Sai INT NOT NULL DEFAULT 0;
IF COL_LENGTH('Tai_Khoan', 'Khoa_Den_Luc') IS NULL
    ALTER TABLE Tai_Khoan ADD Khoa_Den_Luc DATETIME NULL;
IF COL_LENGTH('Tai_Khoan', 'Bat_Buoc_Doi_MK') IS NULL
    ALTER TABLE Tai_Khoan ADD Bat_Buoc_Doi_MK BIT NOT NULL DEFAULT 1;
IF COL_LENGTH('Tai_Khoan', 'Ngay_Doi_MK') IS NULL
    ALTER TABLE Tai_Khoan ADD Ngay_Doi_MK DATETIME NULL;
GO

-- Cấp tài khoản mặc định với mật khẩu ban đầu '123456' (nếu chưa có)
IF NOT EXISTS (SELECT 1 FROM Tai_Khoan WHERE Ma_TK = 'AD01')
    INSERT INTO Tai_Khoan (Ma_TK, Mat_Khau_Hash, Loai_TK, Trang_Thai, Bat_Buoc_Doi_MK)
    VALUES ('AD01', N'123456', 'AD', 'ACTIVE', 1);

IF NOT EXISTS (SELECT 1 FROM Tai_Khoan WHERE Ma_TK = 'GV01')
    INSERT INTO Tai_Khoan (Ma_TK, Mat_Khau_Hash, Loai_TK, Trang_Thai, Bat_Buoc_Doi_MK)
    VALUES ('GV01', N'123456', 'GV', 'ACTIVE', 1);

IF NOT EXISTS (SELECT 1 FROM Tai_Khoan WHERE Ma_TK = 'SV01')
    INSERT INTO Tai_Khoan (Ma_TK, Mat_Khau_Hash, Loai_TK, Trang_Thai, Bat_Buoc_Doi_MK)
    VALUES ('SV01', N'123456', 'SV', 'ACTIVE', 1);
GO

-- ==========================================
-- 4. BẢNG KỲ THI & LIÊN KẾT ĐỀ THI
-- ==========================================
IF OBJECT_ID('Ky_Thi', 'U') IS NULL
BEGIN
    CREATE TABLE Ky_Thi (
        Ma_KT VARCHAR(20) PRIMARY KEY,
        Ten_KT NVARCHAR(50) NOT NULL,
        Ngay_Thi DATE NOT NULL,
        Nam_Hoc VARCHAR(20) NOT NULL
    );
END
GO

IF COL_LENGTH('Ky_Thi', 'Nam_Hoc') IS NULL
    ALTER TABLE Ky_Thi ADD Nam_Hoc VARCHAR(20) NULL;
GO

INSERT INTO Ky_Thi (Ma_KT, Ten_KT, Ngay_Thi, Nam_Hoc)
SELECT 'HK1_2425', N'Học kỳ 1', '2024-12-15', '2024-2025' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK1_2425')
UNION ALL SELECT 'HK2_2425', N'Học kỳ 2', '2025-05-15', '2024-2025' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK2_2425')
UNION ALL SELECT 'HK3_2425', N'Học kỳ 3', '2025-07-20', '2024-2025' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK3_2425')
UNION ALL SELECT 'HK1_2526', N'Học kỳ 1', '2025-12-15', '2025-2026' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK1_2526')
UNION ALL SELECT 'HK2_2526', N'Học kỳ 2', '2026-05-15', '2025-2026' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK2_2526')
UNION ALL SELECT 'HK3_2526', N'Học kỳ 3', '2026-07-20', '2025-2026' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK3_2526')
UNION ALL SELECT 'HK1_2627', N'Học kỳ 1', '2026-12-15', '2026-2027' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK1_2627')
UNION ALL SELECT 'HK2_2627', N'Học kỳ 2', '2027-05-15', '2026-2027' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK2_2627')
UNION ALL SELECT 'HK3_2627', N'Học kỳ 3', '2027-07-20', '2026-2027' WHERE NOT EXISTS (SELECT 1 FROM Ky_Thi WHERE Ma_KT = 'HK3_2627');
GO

IF OBJECT_ID('De_Thi', 'U') IS NOT NULL
BEGIN
    IF COL_LENGTH('De_Thi', 'Ma_KT') IS NULL
        ALTER TABLE De_Thi ADD Ma_KT VARCHAR(20) NULL REFERENCES Ky_Thi(Ma_KT) ON UPDATE CASCADE;

    IF COL_LENGTH('De_Thi', 'Trang_Thai') IS NULL
        ALTER TABLE De_Thi ADD Trang_Thai NVARCHAR(30) NOT NULL DEFAULT N'Chờ duyệt';
END
GO

IF OBJECT_ID('De_Thi', 'U') IS NOT NULL
BEGIN
    UPDATE De_Thi SET Ma_KT = 'HK1_2526' WHERE Ma_KT IS NULL;
    UPDATE De_Thi SET Trang_Thai = N'Đã đăng tải' WHERE Trang_Thai IS NULL OR Trang_Thai = '';
END
GO

-- ==========================================
-- 5. LÀM SẠCH DỮ LIỆU GIẢNG VIÊN, SINH VIÊN, MÔN HỌC
-- ==========================================
IF OBJECT_ID('Giang_Vien', 'U') IS NOT NULL
BEGIN
    ALTER TABLE Giang_Vien ALTER COLUMN Ma_Mon NVARCHAR(255);
    UPDATE Giang_Vien SET Ma_Mon = N'Cơ sở dữ liệu' WHERE Ma_GV = 'GV01';
    UPDATE Giang_Vien SET Ma_Mon = N'Công nghệ phần mềm' WHERE Ma_GV = 'GV02';
    UPDATE Giang_Vien SET Ma_Mon = N'Lập trình trực quan' WHERE Ma_GV = 'GV03';
    UPDATE Giang_Vien SET Ma_Khoa = 'KT' WHERE Ma_Khoa LIKE N'Kinh%';
    UPDATE Giang_Vien SET Ma_Khoa = 'CNTT' WHERE Ma_Khoa LIKE N'C%ng ngh%' OR Ma_Khoa = 'CNTT';
    UPDATE Giang_Vien SET Ma_Khoa = 'CB' WHERE Ma_Khoa LIKE N'C%B%n%';
END
GO

IF OBJECT_ID('Mon', 'U') IS NOT NULL
BEGIN
    ALTER TABLE Mon ALTER COLUMN Ten_Mon NVARCHAR(100);
END
GO

IF OBJECT_ID('Sinh_Vien', 'U') IS NOT NULL
BEGIN
    UPDATE Sinh_Vien SET Ma_Khoa = 'CNTT' WHERE Ma_Khoa LIKE N'C%ng ngh%' OR Ma_Khoa = 'CNTT';
    UPDATE Sinh_Vien SET Lop = 'DCT1231' WHERE Ma_SV = 'SV01';
    UPDATE Sinh_Vien SET Lop = 'DCT1232' WHERE Ma_SV = 'SV02';
END
GO

-- ==========================================
-- 6. STORED PROCEDURE ĐỔI MẬT KHẨU RIÊNG TƯ CHO CHÍNH NGƯỜI DÙNG
-- ==========================================
CREATE OR ALTER PROCEDURE sp_DoiMatKhauCaNhan
    @Ma_TK VARCHAR(30),
    @Mat_Khau_Cu NVARCHAR(256),
    @Mat_Khau_Moi NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Tai_Khoan WHERE Ma_TK = @Ma_TK)
    BEGIN
        SELECT 0 AS Success, N'Tài khoản không tồn tại.' AS Message;
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Tai_Khoan WHERE Ma_TK = @Ma_TK AND Mat_Khau_Hash = @Mat_Khau_Cu)
    BEGIN
        SELECT 0 AS Success, N'Mật khẩu hiện tại không chính xác.' AS Message;
        RETURN;
    END

    UPDATE Tai_Khoan
    SET Mat_Khau_Hash = @Mat_Khau_Moi,
        Bat_Buoc_Doi_MK = 0,
        Ngay_Doi_MK = GETDATE()
    WHERE Ma_TK = @Ma_TK;

    SELECT 1 AS Success, N'Đổi mật khẩu thành công.' AS Message;
END
GO

USE QL_ThiTracNghiem;
GO

IF OBJECT_ID('TaiKhoan', 'U') IS NULL
BEGIN
    CREATE TABLE TaiKhoan (
        UserID INT IDENTITY(1,1) PRIMARY KEY,
        TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
        MatKhau NVARCHAR(256) NOT NULL,
        HoTen NVARCHAR(100) NULL,
        LoaiTaiKhoan VARCHAR(10) NOT NULL, -- 'AD', 'GV', 'SV', 'TS'
        PhaiDoiMatKhau BIT NOT NULL DEFAULT 1,
        NgayCapNhatMatKhau DATETIME NULL
    );
END
GO

IF COL_LENGTH('TaiKhoan', 'PhaiDoiMatKhau') IS NULL
    ALTER TABLE TaiKhoan ADD PhaiDoiMatKhau BIT NOT NULL DEFAULT 1;
GO

IF COL_LENGTH('TaiKhoan', 'NgayCapNhatMatKhau') IS NULL
    ALTER TABLE TaiKhoan ADD NgayCapNhatMatKhau DATETIME NULL;
GO

-- Đảm bảo tài khoản mặc định dùng mật khẩu ban đầu 123456 nếu chưa tồn tại
IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'admin')
    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan, PhaiDoiMatKhau)
    VALUES ('admin', N'123456', N'Quản trị viên', 'AD', 1);

IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'GV01')
    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan, PhaiDoiMatKhau)
    VALUES ('GV01', N'123456', N'Giảng viên 01', 'GV', 1);

IF NOT EXISTS (SELECT 1 FROM TaiKhoan WHERE TenDangNhap = 'SV01')
    INSERT INTO TaiKhoan (TenDangNhap, MatKhau, HoTen, LoaiTaiKhoan, PhaiDoiMatKhau)
    VALUES ('SV01', N'123456', N'Sinh viên 01', 'SV', 1);
GO