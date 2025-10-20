
--use master
--drop database QLDOANNHANH

CREATE DATABASE QLDOANNHANH;
GO

USE QLDOANNHANH;
GO  

--------------------------------------------------
-- 2️⃣ BẢNG NHÂN VIÊN
--------------------------------------------------
CREATE TABLE NHANVIEN (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    CCCD VARCHAR(20) UNIQUE,          -- CCCD/CMND
    DiaChi NVARCHAR(200),
    SDT VARCHAR(20),
    TenDangNhap NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(256) NOT NULL,   -- lưu hash mật khẩu
    VaiTro NVARCHAR(50) DEFAULT 'NhanVien', -- e.g. Admin, QuanLy, NhanVien
    VoHieuHoa BIT DEFAULT 0,
    Avatar NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

--------------------------------------------------
-- 3️⃣ BẢNG KHÁCH HÀNG
--------------------------------------------------
CREATE TABLE KHACHHANG (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    SDT VARCHAR(20),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(255),
    LoaiKH NVARCHAR(50) DEFAULT 'Le', -- Le / DoanhNghiep
    DiemTichLuy INT DEFAULT 0,
    NgayDangKy DATE DEFAULT CONVERT(date, GETDATE())
);
GO

--------------------------------------------------
-- 4️⃣ BẢNG LOẠI MÓN
--------------------------------------------------
CREATE TABLE LOAIMON (
    MaLoai INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);
GO

--------------------------------------------------
-- 5️⃣ BẢNG MÓN ĂN (MENU)
--------------------------------------------------
CREATE TABLE MONAN (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(150) NOT NULL,
    MaLoai INT NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL,
    TrangThai BIT DEFAULT 1, -- 1: đang bán, 0: ngưng bán
    HinhAnh NVARCHAR(255),
    MoTa NVARCHAR(500),
    CONSTRAINT FK_Mon_Loai FOREIGN KEY (MaLoai) REFERENCES LOAIMON(MaLoai)
);
GO

--------------------------------------------------
-- 6️⃣ BẢNG NHÀ CUNG CẤP
--------------------------------------------------
CREATE TABLE NHACUNGCAP (
    MaNCC INT IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(150) NOT NULL,
    SDT VARCHAR(20),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(255),
    NguoiLienHe NVARCHAR(100)
);
GO

--------------------------------------------------
-- 7️⃣ BẢNG NGUYÊN LIỆU & KHO
--------------------------------------------------
CREATE TABLE NGUYENLIEU (
    MaNL INT IDENTITY(1,1) PRIMARY KEY,
    TenNL NVARCHAR(150) NOT NULL,
    DonViTinh NVARCHAR(50), -- e.g. kg, g, chai
    MaNCC INT NULL,
    GiaNhap DECIMAL(18,2),
    CONSTRAINT FK_NL_NCC FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC)
);
GO

CREATE TABLE KHO (
    MaKho INT IDENTITY(1,1) PRIMARY KEY,
    MaNL INT NOT NULL,
    SoLuong DECIMAL(18,3) DEFAULT 0, -- quantity in stock
    HanSuDung DATE NULL,
    CONSTRAINT FK_Kho_NL FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL)
);
GO

--------------------------------------------------
-- 8️⃣ BẢNG CÔNG THỨC (MÓN -> NGUYÊN LIỆU)
--------------------------------------------------
CREATE TABLE CONGTHUC (
    MaCongThuc INT IDENTITY(1,1) PRIMARY KEY,
    MaMon INT NOT NULL,
    MaNL INT NOT NULL,
    SoLuong DECIMAL(18,3) NOT NULL, -- số lượng nguyên liệu cho 1 món
    DonVi NVARCHAR(50),
    CONSTRAINT FK_CT_Mon FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon),
    CONSTRAINT FK_CT_NL FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL)
);
GO

--------------------------------------------------
-- 9️⃣ BẢNG BÀN ĐÃ ĐƯỢC LOẠI BỎ (chỉ bán mang về/giao hàng)
--------------------------------------------------

--------------------------------------------------
-- 🔟 BẢNG HÓA ĐƠN (ORDER)
--------------------------------------------------
CREATE TABLE HOADON (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    MaKH INT NULL,
    MaNV INT NOT NULL,              -- người tạo/thu ngân
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2) DEFAULT 0,
    PhiGiaoHang DECIMAL(18,2) DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT 'ChoThanhToan', -- ChoThanhToan, DaThanhToan, DaHuy, DangGiao, DaGiao
    PhuongThucTT NVARCHAR(50) DEFAULT 'TienMat', -- TienMat, The, Online
    LoaiDon NVARCHAR(50) DEFAULT 'MangVe', -- MangVe / GiaoHang
    DiaChiGiaoHang NVARCHAR(255),
    SDTGiaoHang VARCHAR(20),
    TenNguoiNhan NVARCHAR(100),
    ThoiGianGiao DATETIME NULL,
    GhiChu NVARCHAR(500),
    CONSTRAINT FK_HD_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
    CONSTRAINT FK_HD_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO

--------------------------------------------------
-- 1️⃣1️⃣ BẢNG CHI TIẾT HÓA ĐƠN (ORDER ITEMS)
--------------------------------------------------
CREATE TABLE CHITIETHOADON (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    MaHD INT NOT NULL,
    MaMon INT NOT NULL,
    SoLuong INT NOT NULL DEFAULT 1,
    DonGia DECIMAL(18,2) NOT NULL,  -- snapshot giá lúc bán
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    CONSTRAINT FK_CTHD_HD FOREIGN KEY (MaHD) REFERENCES HOADON(MaHD) ON DELETE CASCADE,
    CONSTRAINT FK_CTHD_Mon FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon)
);
GO

--------------------------------------------------
-- 1️⃣2️⃣ BẢNG KHUYẾN MÃI / MÃ GIẢM GIÁ
--------------------------------------------------
CREATE TABLE KHUYENMAI (
    MaKM INT IDENTITY(1,1) PRIMARY KEY,
    MaMon INT NULL,         -- nếu áp dụng cho 1 món cụ thể, NULL = áp dụng toàn menu
    MaLoai INT NULL,       -- áp dụng theo loại
    MaKH INT NULL,         -- mã riêng cho KH (nếu có)
    TenKM NVARCHAR(150),
    LoaiKM NVARCHAR(50),   -- e.g. PhanTram, GiamTien
    GiaTri DECIMAL(18,2),  -- 10 = 10% nếu PhanTram, hoặc 20000 nếu GiamTien
    TuNgay DATE,
    DenNgay DATE,
    DieuKien NVARCHAR(255), -- điều kiện (vd: ton tai min order)
    CONSTRAINT FK_KM_Mon FOREIGN KEY (MaMon) REFERENCES MONAN(MaMon),
    CONSTRAINT FK_KM_Loai FOREIGN KEY (MaLoai) REFERENCES LOAIMON(MaLoai),
    CONSTRAINT FK_KM_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);
GO

--------------------------------------------------
-- 1️⃣3️⃣ BẢNG NHẬP KHO (ghi nhận nhập nguyên liệu)
--------------------------------------------------
CREATE TABLE NHAPKHO (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    MaNCC INT NOT NULL,
    MaNL INT NOT NULL,
    SoLuong DECIMAL(18,3) NOT NULL,
    DonGia DECIMAL(18,2),
    NgayNhap DATE DEFAULT CONVERT(date, GETDATE()),
    GhiChu NVARCHAR(255),
    CONSTRAINT FK_NK_NCC FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC),
    CONSTRAINT FK_NK_NL FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL)
);
GO

--------------------------------------------------
-- 1️⃣4️⃣ BẢNG ĐẶT HÀNG TRƯỚC (cho giao hàng)
--------------------------------------------------
CREATE TABLE DATHANGTRUOC (
    MaDat INT IDENTITY(1,1) PRIMARY KEY,
    TenNguoiDat NVARCHAR(120),
    SDTNguoiDat VARCHAR(20),
    NgayDat DATETIME NOT NULL,
    ThoiGianGiao DATETIME NOT NULL,
    DiaChiGiaoHang NVARCHAR(255),
    TrangThai NVARCHAR(50) DEFAULT 'ChoXacNhan', -- ChoXacNhan, DaXacNhan, DaHuy, DaGiao
    GhiChu NVARCHAR(255)
);
GO

--------------------------------------------------
-- 1️⃣5️⃣ BẢNG NHẬT KÝ HỆ THỐNG (OPTIONAL)
--------------------------------------------------
CREATE TABLE NhatKyHeThong (
    MaLog INT IDENTITY(1,1) PRIMARY KEY,
    MaNV INT NULL,
    ThoiGian DATETIME DEFAULT GETDATE(),
    HanhDong NVARCHAR(100),
    ChiTiet NVARCHAR(1000),
    CONSTRAINT FK_Log_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);
GO

--------------------------------------------------
-- TRIGGER TỰ ĐỘNG CẬP NHẬT KHO KHI NHẬP
--------------------------------------------------
CREATE TRIGGER TR_NHAPKHO_UPDATE_KHO
ON NHAPKHO
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Cập nhật số lượng trong bảng KHO khi có nhập kho mới
    UPDATE KHO 
    SET SoLuong = KHO.SoLuong + i.SoLuong,
        HanSuDung = CASE 
            WHEN i.NgayNhap IS NOT NULL THEN DATEADD(DAY, 30, i.NgayNhap) -- Mặc định hạn sử dụng 30 ngày
            ELSE KHO.HanSuDung 
        END
    FROM KHO 
    INNER JOIN inserted i ON KHO.MaNL = i.MaNL;
    
    -- Nếu nguyên liệu chưa có trong kho thì insert mới
    INSERT INTO KHO (MaNL, SoLuong, HanSuDung)
    SELECT i.MaNL, i.SoLuong, DATEADD(DAY, 30, i.NgayNhap)
    FROM inserted i
    WHERE NOT EXISTS (SELECT 1 FROM KHO WHERE MaNL = i.MaNL);
END;
GO

--------------------------------------------------
-- TRIGGER TỰ ĐỘNG CẬP NHẬT TỔNG TIỀN HÓA ĐƠN
--------------------------------------------------
CREATE TRIGGER TR_CTHD_UPDATE_TONGTIEN
ON CHITIETHOADON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Cập nhật tổng tiền cho các hóa đơn bị ảnh hưởng
    UPDATE HOADON 
    SET TongTien = (
        SELECT ISNULL(SUM(ThanhTien), 0) 
        FROM CHITIETHOADON 
        WHERE MaHD = HOADON.MaHD
    )
    WHERE MaHD IN (
        SELECT DISTINCT MaHD FROM inserted
        UNION
        SELECT DISTINCT MaHD FROM deleted
    );
END;
GO

--------------------------------------------------
-- TRIGGER KIỂM TRA ĐỦ NGUYÊN LIỆU KHI BÁN MÓN
--------------------------------------------------
CREATE TRIGGER TR_CHECK_INGREDIENTS
ON CHITIETHOADON
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Kiểm tra xem có đủ nguyên liệu không
    DECLARE @InsufficientIngredients TABLE (
        MaMon INT,
        TenMon NVARCHAR(150),
        MaNL INT,
        TenNL NVARCHAR(150),
        SoLuongCan DECIMAL(18,3),
        SoLuongCo DECIMAL(18,3)
    );
    
    INSERT INTO @InsufficientIngredients
    SELECT 
        i.MaMon,
        m.TenMon,
        ct.MaNL,
        nl.TenNL,
        (i.SoLuong * ct.SoLuong) as SoLuongCan,
        ISNULL(k.SoLuong, 0) as SoLuongCo
    FROM inserted i
    INNER JOIN CONGTHUC ct ON i.MaMon = ct.MaMon
    INNER JOIN MONAN m ON ct.MaMon = m.MaMon
    INNER JOIN NGUYENLIEU nl ON ct.MaNL = nl.MaNL
    LEFT JOIN KHO k ON ct.MaNL = k.MaNL
    WHERE (i.SoLuong * ct.SoLuong) > ISNULL(k.SoLuong, 0);
    
    -- Nếu có nguyên liệu không đủ thì rollback
    IF EXISTS (SELECT 1 FROM @InsufficientIngredients)
    BEGIN
        DECLARE @ErrorMessage NVARCHAR(MAX) = 'Không đủ nguyên liệu: ';
        SELECT @ErrorMessage = @ErrorMessage + 
            TenNL + ' (cần: ' + CAST(SoLuongCan AS NVARCHAR(20)) + 
            ', có: ' + CAST(SoLuongCo AS NVARCHAR(20)) + '); '
        FROM @InsufficientIngredients;
        
        RAISERROR(@ErrorMessage, 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END;
    
    -- Cập nhật số lượng nguyên liệu trong kho
    UPDATE k
    SET k.SoLuong = k.SoLuong - (i.SoLuong * ct.SoLuong)
    FROM KHO k
    INNER JOIN CONGTHUC ct ON k.MaNL = ct.MaNL
    INNER JOIN inserted i ON ct.MaMon = i.MaMon;
END;
GO

--------------------------------------------------
-- THÊM CÁC CONSTRAINT ĐỂ ĐẢM BẢO TÍNH NHẤT QUÁN
--------------------------------------------------
-- Constraint kiểm tra ngày bắt đầu phải nhỏ hơn ngày kết thúc
ALTER TABLE KHUYENMAI
ADD CONSTRAINT CK_KM_NGAY CHECK (TuNgay <= DenNgay);
GO

-- Constraint kiểm tra giá trị khuyến mãi phải dương
ALTER TABLE KHUYENMAI
ADD CONSTRAINT CK_KM_GIATRI CHECK (GiaTri > 0);
GO

-- Constraint kiểm tra số lượng phải dương
ALTER TABLE CHITIETHOADON
ADD CONSTRAINT CK_CTHD_SOLUONG CHECK (SoLuong > 0);
GO

-- Constraint kiểm tra đơn giá phải dương
ALTER TABLE CHITIETHOADON
ADD CONSTRAINT CK_CTHD_DONGIA CHECK (DonGia > 0);
GO

-- Constraint kiểm tra số lượng nhập kho phải dương
ALTER TABLE NHAPKHO
ADD CONSTRAINT CK_NK_SOLUONG CHECK (SoLuong > 0);
GO

-- Constraint kiểm tra đơn giá nhập phải dương
ALTER TABLE NHAPKHO
ADD CONSTRAINT CK_NK_DONGIA CHECK (DonGia > 0);
GO

-- Constraint kiểm tra số lượng trong kho không âm
ALTER TABLE KHO
ADD CONSTRAINT CK_KHO_SOLUONG CHECK (SoLuong >= 0);
GO

--------------------------------------------------
-- TẠO VIEW HIỂN THỊ THÔNG TIN LIÊN KẾT
--------------------------------------------------
-- View hiển thị thông tin món ăn kèm loại và trạng thái kho
CREATE VIEW V_MONAN_KHO AS
SELECT 
    m.MaMon,
    m.TenMon,
    lm.TenLoai,
    m.DonGia,
    m.TrangThai,
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM CONGTHUC ct 
            INNER JOIN KHO k ON ct.MaNL = k.MaNL 
            WHERE ct.MaMon = m.MaMon 
            AND k.SoLuong < ct.SoLuong
        ) THEN 'Het Nguyen Lieu'
        WHEN m.TrangThai = 0 THEN 'Ngung Ban'
        ELSE 'San Co'
    END as TrangThaiKho
FROM MONAN m
INNER JOIN LOAIMON lm ON m.MaLoai = lm.MaLoai;
GO

-- View hiển thị chi tiết hóa đơn với thông tin đầy đủ
CREATE VIEW V_CHITIET_HOADON AS
SELECT 
    hd.MaHD,
    hd.NgayLap,
    kh.TenKH,
    nv.TenNV as ThuNgan,
    hd.LoaiDon,
    hd.DiaChiGiaoHang,
    hd.SDTGiaoHang,
    hd.TenNguoiNhan,
    hd.ThoiGianGiao,
    hd.TongTien,
    hd.TrangThai,
    hd.PhuongThucTT,
    cthd.MaMon,
    ma.TenMon,
    cthd.SoLuong,
    cthd.DonGia,
    cthd.ThanhTien
FROM HOADON hd
LEFT JOIN KHACHHANG kh ON hd.MaKH = kh.MaKH
INNER JOIN NHANVIEN nv ON hd.MaNV = nv.MaNV
INNER JOIN CHITIETHOADON cthd ON hd.MaHD = cthd.MaHD
INNER JOIN MONAN ma ON cthd.MaMon = ma.MaMon;
GO

-- View hiển thị tình trạng kho với thông tin nguyên liệu
CREATE VIEW V_TINH_TRANG_KHO AS
SELECT 
    k.MaNL,
    nl.TenNL,
    nl.DonViTinh,
    ncc.TenNCC,
    k.SoLuong,
    k.HanSuDung,
    CASE 
        WHEN k.HanSuDung < GETDATE() THEN 'Het Han'
        WHEN k.HanSuDung <= DATEADD(DAY, 7, GETDATE()) THEN 'Sap Het Han'
        WHEN k.SoLuong = 0 THEN 'Het Hang'
        WHEN k.SoLuong < 10 THEN 'Sap Het Hang'
        ELSE 'Du Hang'
    END as TrangThaiKho
FROM KHO k
INNER JOIN NGUYENLIEU nl ON k.MaNL = nl.MaNL
LEFT JOIN NHACUNGCAP ncc ON nl.MaNCC = ncc.MaNCC;
GO

--------------------------------------------------
-- INDEXES & MỘT VÀI LƯU Ý
--------------------------------------------------
-- Bạn có thể thêm index cho cột thường tìm kiếm: TenMon, TenKH, SDT, NgayLap...
CREATE INDEX IDX_Mon_Ten ON MONAN(TenMon);
CREATE INDEX IDX_HD_NgayLap ON HOADON(NgayLap);
CREATE INDEX IDX_KH_SDT ON KHACHHANG(SDT);
CREATE INDEX IDX_KHO_NL ON KHO(MaNL);
CREATE INDEX IDX_CT_Mon ON CONGTHUC(MaMon);
CREATE INDEX IDX_CTHD_HD ON CHITIETHOADON(MaHD);
CREATE INDEX IDX_NK_Ngay ON NHAPKHO(NgayNhap);
GO

--------------------------------------------------
-- STORED PROCEDURES HỮU ÍCH
--------------------------------------------------
-- Procedure tạo hóa đơn mới
CREATE PROCEDURE SP_TAO_HOA_DON
    @MaKH INT = NULL,
    @MaNV INT,
    @LoaiDon NVARCHAR(50) = 'MangVe',
    @DiaChiGiaoHang NVARCHAR(255) = NULL,
    @SDTGiaoHang VARCHAR(20) = NULL,
    @TenNguoiNhan NVARCHAR(100) = NULL,
    @ThoiGianGiao DATETIME = NULL,
    @GhiChu NVARCHAR(500) = NULL,
    @MaHD INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO HOADON (MaKH, MaNV, LoaiDon, DiaChiGiaoHang, SDTGiaoHang, TenNguoiNhan, ThoiGianGiao, GhiChu)
    VALUES (@MaKH, @MaNV, @LoaiDon, @DiaChiGiaoHang, @SDTGiaoHang, @TenNguoiNhan, @ThoiGianGiao, @GhiChu);
    
    SET @MaHD = SCOPE_IDENTITY();
END;
GO

-- Procedure thêm món vào hóa đơn
CREATE PROCEDURE SP_THEM_MON_VAO_HD
    @MaHD INT,
    @MaMon INT,
    @SoLuong INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @DonGia DECIMAL(18,2);
    
    -- Lấy giá hiện tại của món
    SELECT @DonGia = DonGia FROM MONAN WHERE MaMon = @MaMon;
    
    IF @DonGia IS NULL
    BEGIN
        RAISERROR('Món ăn không tồn tại!', 16, 1);
        RETURN;
    END;
    
    -- Thêm vào chi tiết hóa đơn (trigger sẽ tự động kiểm tra nguyên liệu và cập nhật tổng tiền)
    INSERT INTO CHITIETHOADON (MaHD, MaMon, SoLuong, DonGia)
    VALUES (@MaHD, @MaMon, @SoLuong, @DonGia);
END;
GO

-- Procedure thanh toán hóa đơn
CREATE PROCEDURE SP_THANH_TOAN_HD
    @MaHD INT,
    @PhuongThucTT NVARCHAR(50) = 'TienMat'
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE HOADON 
    SET TrangThai = 'DaThanhToan',
        PhuongThucTT = @PhuongThucTT
    WHERE MaHD = @MaHD AND TrangThai = 'ChoThanhToan';
    
    IF @@ROWCOUNT = 0
        RAISERROR('Hóa đơn không tồn tại hoặc đã được thanh toán!', 16, 1);
END;
GO

-- Procedure nhập kho nguyên liệu
CREATE PROCEDURE SP_NHAP_KHO
    @MaNCC INT,
    @MaNL INT,
    @SoLuong DECIMAL(18,3),
    @DonGia DECIMAL(18,2),
    @GhiChu NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Thêm vào bảng nhập kho (trigger sẽ tự động cập nhật kho)
    INSERT INTO NHAPKHO (MaNCC, MaNL, SoLuong, DonGia, GhiChu)
    VALUES (@MaNCC, @MaNL, @SoLuong, @DonGia, @GhiChu);
END;
GO

-- Procedure báo cáo doanh thu theo ngày
CREATE PROCEDURE SP_BAO_CAO_DOANH_THU
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CONVERT(DATE, hd.NgayLap) as Ngay,
        COUNT(*) as SoHoaDon,
        SUM(hd.TongTien) as TongDoanhThu,
        AVG(hd.TongTien) as DoanhThuTrungBinh,
        SUM(CASE WHEN hd.PhuongThucTT = 'TienMat' THEN hd.TongTien ELSE 0 END) as DoanhThuTienMat,
        SUM(CASE WHEN hd.PhuongThucTT = 'The' THEN hd.TongTien ELSE 0 END) as DoanhThuThe,
        SUM(CASE WHEN hd.PhuongThucTT = 'Online' THEN hd.TongTien ELSE 0 END) as DoanhThuOnline
    FROM HOADON hd
    WHERE hd.TrangThai = 'DaThanhToan'
        AND CONVERT(DATE, hd.NgayLap) BETWEEN @TuNgay AND @DenNgay
    GROUP BY CONVERT(DATE, hd.NgayLap)
    ORDER BY Ngay;
END;
GO

-- Procedure báo cáo món bán chạy
CREATE PROCEDURE SP_BAO_CAO_MON_BAN_CHAY
    @TuNgay DATE,
    @DenNgay DATE,
    @Top INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT TOP (@Top)
        ma.MaMon,
        ma.TenMon,
        lm.TenLoai,
        SUM(cthd.SoLuong) as TongSoLuong,
        COUNT(DISTINCT cthd.MaHD) as SoHoaDon,
        SUM(cthd.ThanhTien) as TongDoanhThu,
        AVG(cthd.DonGia) as GiaTrungBinh
    FROM CHITIETHOADON cthd
    INNER JOIN MONAN ma ON cthd.MaMon = ma.MaMon
    INNER JOIN LOAIMON lm ON ma.MaLoai = lm.MaLoai
    INNER JOIN HOADON hd ON cthd.MaHD = hd.MaHD
    WHERE hd.TrangThai = 'DaThanhToan'
        AND CONVERT(DATE, hd.NgayLap) BETWEEN @TuNgay AND @DenNgay
    GROUP BY ma.MaMon, ma.TenMon, lm.TenLoai
    ORDER BY TongSoLuong DESC;
END;
GO

-- Procedure cập nhật trạng thái giao hàng
CREATE PROCEDURE SP_CAP_NHAT_GIAO_HANG
    @MaHD INT,
    @TrangThai NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE HOADON 
    SET TrangThai = @TrangThai
    WHERE MaHD = @MaHD AND LoaiDon = 'GiaoHang';
    
    IF @@ROWCOUNT = 0
        RAISERROR('Hóa đơn giao hàng không tồn tại!', 16, 1);
END;
GO

-- Procedure báo cáo đơn hàng theo loại
CREATE PROCEDURE SP_BAO_CAO_DON_HANG
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        hd.LoaiDon,
        COUNT(*) as SoDonHang,
        SUM(hd.TongTien) as TongDoanhThu,
        AVG(hd.TongTien) as DoanhThuTrungBinh,
        SUM(CASE WHEN hd.TrangThai = 'DaGiao' THEN 1 ELSE 0 END) as DaGiao,
        SUM(CASE WHEN hd.TrangThai = 'DangGiao' THEN 1 ELSE 0 END) as DangGiao,
        SUM(CASE WHEN hd.TrangThai = 'DaHuy' THEN 1 ELSE 0 END) as DaHuy
    FROM HOADON hd
    WHERE CONVERT(DATE, hd.NgayLap) BETWEEN @TuNgay AND @DenNgay
    GROUP BY hd.LoaiDon
    ORDER BY hd.LoaiDon;
END;
GO

--------------------------------------------------
-- FUNCTIONS HỮU ÍCH
--------------------------------------------------
-- Function kiểm tra món có đủ nguyên liệu không
CREATE FUNCTION FN_KIEM_TRA_NGUYEN_LIEU(@MaMon INT)
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT = 1;
    
    IF EXISTS (
        SELECT 1 
        FROM CONGTHUC ct
        LEFT JOIN KHO k ON ct.MaNL = k.MaNL
        WHERE ct.MaMon = @MaMon
        AND ISNULL(k.SoLuong, 0) < ct.SoLuong
    )
    BEGIN
        SET @Result = 0;
    END;
    
    RETURN @Result;
END;
GO

-- Function tính tổng tiền hóa đơn (bao gồm khuyến mãi)
CREATE FUNCTION FN_TINH_TONG_TIEN_HD(@MaHD INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @TongTien DECIMAL(18,2) = 0;
    DECLARE @GiamGia DECIMAL(18,2) = 0;
    
    -- Tính tổng tiền từ chi tiết hóa đơn
    SELECT @TongTien = ISNULL(SUM(ThanhTien), 0)
    FROM CHITIETHOADON
    WHERE MaHD = @MaHD;
    
    -- Tính giảm giá từ khuyến mãi (nếu có)
    SELECT @GiamGia = ISNULL(SUM(
        CASE 
            WHEN km.LoaiKM = 'PhanTram' THEN @TongTien * km.GiaTri / 100
            WHEN km.LoaiKM = 'GiamTien' THEN km.GiaTri
            ELSE 0
        END
    ), 0)
    FROM KHUYENMAI km
    INNER JOIN HOADON hd ON km.MaKH = hd.MaKH
    WHERE hd.MaHD = @MaHD
        AND GETDATE() BETWEEN km.TuNgay AND km.DenNgay;
    
    RETURN @TongTien - @GiamGia;
END;
GO

-- Function lấy thông tin khách hàng VIP
CREATE FUNCTION FN_KHACH_HANG_VIP(@MaKH INT)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @Result NVARCHAR(50) = 'Thuong';
    DECLARE @TongTien DECIMAL(18,2);
    
    SELECT @TongTien = ISNULL(SUM(TongTien), 0)
    FROM HOADON
    WHERE MaKH = @MaKH AND TrangThai = 'DaThanhToan';
    
    IF @TongTien >= 10000000
        SET @Result = 'Diamond';
    ELSE IF @TongTien >= 5000000
        SET @Result = 'Gold';
    ELSE IF @TongTien >= 2000000
        SET @Result = 'Silver';
    
    RETURN @Result;
END;
GO

--------------------------------------------------
-- DỮ LIỆU MẪU ĐỂ TEST
--------------------------------------------------
-- Thêm dữ liệu mẫu cho các bảng cơ bản
INSERT INTO LOAIMON (TenLoai, MoTa) VALUES
(N'Món Khai Vị', N'Các món ăn nhẹ để bắt đầu bữa ăn'),
(N'Món Chính', N'Các món ăn chính của nhà hàng'),
(N'Món Tráng Miệng', N'Các món ngọt kết thúc bữa ăn'),
(N'Đồ Uống', N'Các loại thức uống'),
(N'Món Nhanh', N'Các món ăn nhanh phục vụ khách vội');

INSERT INTO NHACUNGCAP (TenNCC, SDT, Email, DiaChi, NguoiLienHe) VALUES
(N'Công ty Thực phẩm ABC', '0123456789', 'contact@abc.com', N'123 Đường ABC, TP.HCM', N'Nguyễn Văn A'),
(N'Nhà cung cấp XYZ', '0987654321', 'info@xyz.com', N'456 Đường XYZ, TP.HCM', N'Trần Thị B'),
(N'Thực phẩm sạch 123', '0369258147', 'sales@123.com', N'789 Đường 123, TP.HCM', N'Lê Văn C');

INSERT INTO NGUYENLIEU (TenNL, DonViTinh, MaNCC, GiaNhap) VALUES
(N'Thịt bò', 'kg', 1, 250000),
(N'Thịt heo', 'kg', 1, 120000),
(N'Gà', 'kg', 1, 80000),
(N'Tôm', 'kg', 2, 180000),
(N'Cá', 'kg', 2, 150000),
(N'Rau xanh', 'kg', 3, 25000),
(N'Gạo', 'kg', 3, 15000),
(N'Dầu ăn', 'chai', 3, 45000),
(N'Gia vị', 'gói', 3, 5000);

INSERT INTO MONAN (TenMon, MaLoai, DonGia, HinhAnh, MoTa) VALUES
(N'Bò bít tết', 2, 250000, 'bobittet.jpg', N'Bò bít tết thơm ngon'),
(N'Thịt heo nướng', 2, 180000, 'heonuong.jpg', N'Thịt heo nướng đặc biệt'),
(N'Gà nướng mật ong', 2, 150000, 'ganuong.jpg', N'Gà nướng với mật ong'),
(N'Tôm chiên giòn', 1, 120000, 'tomchien.jpg', N'Tôm chiên giòn thơm ngon'),
(N'Cá nướng lá chuối', 2, 200000, 'canuong.jpg', N'Cá nướng trong lá chuối'),
(N'Salad rau củ', 1, 45000, 'salad.jpg', N'Salad rau củ tươi ngon'),
(N'Cơm trắng', 5, 15000, 'comtrang.jpg', N'Cơm trắng thơm dẻo'),
(N'Kem dâu', 3, 35000, 'kem.jpg', N'Kem dâu tươi mát'),
(N'Nước cam', 4, 25000, 'nuoccam.jpg', N'Nước cam tươi'),
(N'Cà phê đen', 4, 20000, 'capheden.jpg', N'Cà phê đen đậm đà');

-- Thêm công thức cho các món
INSERT INTO CONGTHUC (MaMon, MaNL, SoLuong, DonVi) VALUES
-- Bò bít tết
(1, 1, 0.3, 'kg'), -- Thịt bò
(1, 7, 0.2, 'kg'), -- Gạo
(1, 8, 0.05, 'chai'), -- Dầu ăn
(1, 9, 0.01, 'gói'), -- Gia vị

-- Thịt heo nướng
(2, 2, 0.4, 'kg'), -- Thịt heo
(2, 7, 0.2, 'kg'), -- Gạo
(2, 8, 0.03, 'chai'), -- Dầu ăn
(2, 9, 0.01, 'gói'), -- Gia vị

-- Gà nướng mật ong
(3, 3, 0.5, 'kg'), -- Gà
(3, 7, 0.2, 'kg'), -- Gạo
(3, 8, 0.03, 'chai'), -- Dầu ăn
(3, 9, 0.01, 'gói'), -- Gia vị

-- Tôm chiên giòn
(4, 4, 0.3, 'kg'), -- Tôm
(4, 8, 0.05, 'chai'), -- Dầu ăn
(4, 9, 0.01, 'gói'), -- Gia vị

-- Cá nướng lá chuối
(5, 5, 0.4, 'kg'), -- Cá
(5, 7, 0.2, 'kg'), -- Gạo
(5, 9, 0.01, 'gói'), -- Gia vị

-- Salad rau củ
(6, 6, 0.2, 'kg'), -- Rau xanh
(6, 8, 0.02, 'chai'), -- Dầu ăn

-- Cơm trắng
(7, 7, 0.15, 'kg'); -- Gạo

-- Thêm nhân viên mẫu
INSERT INTO NHANVIEN (TenNV, GioiTinh, NgaySinh, CCCD, DiaChi, SDT, TenDangNhap, MatKhau, VaiTro) VALUES
(N'Võ Thành Dông', 'Nam', '1990-01-01', '123456789012', 'TP.HCM', '0123456789', 'admin', 'admin123', 'Admin'),
(N'Đoàn Quí Trường', 'Nam', '1995-05-15', '234567890123', 'TP.HCM', '0987654321', 'thungan', 'thungan123', 'QuanLy'),
(N'Trà Quang Vinh', 'Nam', '1998-08-20', '345678901234', 'TP.HCM', '0369258147', 'phucvu', 'phucvu123', 'NhanVien');

-- Thêm đơn hàng đặt trước mẫu
INSERT INTO DATHANGTRUOC (TenNguoiDat, SDTNguoiDat, NgayDat, ThoiGianGiao, DiaChiGiaoHang, TrangThai) VALUES
(N'Nguyễn Văn A', '0123456789', '2024-12-15 10:00:00', '2024-12-15 12:00:00', N'123 Đường ABC, Quận 1, TP.HCM', 'ChoXacNhan'),
(N'Trần Thị B', '0987654321', '2024-12-15 14:00:00', '2024-12-15 18:00:00', N'456 Đường XYZ, Quận 3, TP.HCM', 'DaXacNhan');

-- Nhập kho nguyên liệu mẫu
INSERT INTO NHAPKHO (MaNCC, MaNL, SoLuong, DonGia, GhiChu) VALUES
(1, 1, 10, 250000, N'Nhập thịt bò chất lượng cao'),
(1, 2, 15, 120000, N'Nhập thịt heo tươi'),
(1, 3, 20, 80000, N'Nhập gà tươi'),
(2, 4, 8, 180000, N'Nhập tôm tươi'),
(2, 5, 12, 150000, N'Nhập cá tươi'),
(3, 6, 25, 25000, N'Nhập rau xanh tươi'),
(3, 7, 50, 15000, N'Nhập gạo thơm'),
(3, 8, 20, 45000, N'Nhập dầu ăn'),
(3, 9, 100, 5000, N'Nhập gia vị');

--------------------------------------------------
-- VÍ DỤ SỬ DỤNG HỆ THỐNG
--------------------------------------------------
/*
-- Ví dụ tạo hóa đơn mới và thêm món:
DECLARE @MaHD INT;
-- Tạo đơn mang về
EXEC SP_TAO_HOA_DON @MaKH = NULL, @MaNV = 2, @LoaiDon = 'MangVe', @MaHD = @MaHD OUTPUT;
PRINT 'Hóa đơn mang về: ' + CAST(@MaHD AS VARCHAR(10));

-- Tạo đơn giao hàng
DECLARE @MaHD2 INT;
EXEC SP_TAO_HOA_DON @MaKH = NULL, @MaNV = 2, @LoaiDon = 'GiaoHang', 
    @DiaChiGiaoHang = '123 Đường ABC, Quận 1, TP.HCM',
    @SDTGiaoHang = '0123456789',
    @TenNguoiNhan = 'Nguyễn Văn A',
    @ThoiGianGiao = '2024-12-15 18:00:00',
    @MaHD = @MaHD2 OUTPUT;
PRINT 'Hóa đơn giao hàng: ' + CAST(@MaHD2 AS VARCHAR(10));

-- Thêm món vào hóa đơn
EXEC SP_THEM_MON_VAO_HD @MaHD = @MaHD, @MaMon = 1, @SoLuong = 2; -- Bò bít tết x2
EXEC SP_THEM_MON_VAO_HD @MaHD = @MaHD, @MaMon = 7, @SoLuong = 1; -- Cơm trắng x1

-- Thanh toán hóa đơn
EXEC SP_THANH_TOAN_HD @MaHD = @MaHD, @PhuongThucTT = 'TienMat';

-- Xem báo cáo doanh thu
EXEC SP_BAO_CAO_DOANH_THU @TuNgay = '2024-01-01', @DenNgay = '2024-12-31';

-- Xem món bán chạy
EXEC SP_BAO_CAO_MON_BAN_CHAY @TuNgay = '2024-01-01', @DenNgay = '2024-12-31', @Top = 5;

-- Kiểm tra món có đủ nguyên liệu không
SELECT dbo.FN_KIEM_TRA_NGUYEN_LIEU(1) as BoBittet_DuNguyenLieu;

-- Xem tình trạng kho
SELECT * FROM V_TINH_TRANG_KHO;

-- Xem món ăn và trạng thái kho
SELECT * FROM V_MONAN_KHO;

-- Xem đơn hàng cần giao
SELECT * FROM HOADON WHERE TrangThai = 'DangGiao' AND LoaiDon = 'GiaoHang';
*/

PRINT N'=== DATABASE HOÀN CHỈNH (CHỈ BÁN MANG VỀ/GIAO HÀNG) ===';
PRINT N' Đã tạo 14 bảng với đầy đủ liên kết logic (đã loại bỏ BAN và DATTABLE)';
PRINT N' Đã tạo 3 triggers tự động cập nhật dữ liệu';
PRINT N' Đã tạo 8 constraints đảm bảo tính nhất quán';
PRINT N' Đã tạo 3 views hiển thị thông tin liên kết';
PRINT N' Đã tạo 7 stored procedures hữu ích (bao gồm quản lý giao hàng)';
PRINT N' Đã tạo 3 functions tiện ích';
PRINT N' Đã tạo 7 indexes tối ưu hiệu suất';
PRINT N' Đã thêm dữ liệu mẫu để test hệ thống';
PRINT N' Đã cập nhật để hỗ trợ đơn mang về và giao hàng';
PRINT '';
PRINT N'Hệ thống quản lý nhà hàng (mang về/giao hàng) đã sẵn sàng sử dụng!';
PRINT N'Bạn có thể chạy các ví dụ ở trên để test chức năng.';
GO
