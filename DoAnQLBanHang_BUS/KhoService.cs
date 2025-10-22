using DoAnQLBanHang_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DoAnQLBanHang_BUS
{
    public class KhoService
    {
       private readonly QLBDANmodel db;

       public KhoService()
       {
            db = new QLBDANmodel();
       }

        // Phương thức lấy toàn bộ thông tin tồn kho
        public List<KHO> GetAllTonKho()
        {
            // Dùng LINQ to Entities kết hợp .Include() để lấy dữ liệu
            // từ bảng KHO và tải đồng thời các thông tin liên quan (Nguyên liệu, Nhà cung cấp)
            return db.KHOes
                     .Include(k => k.NGUYENLIEU)
                     .Include(k => k.NGUYENLIEU.NHACUNGCAP)
                     .ToList();
        }

        public List<NHACUNGCAP> GetAllNhaCungCap()
        {
            return db.NHACUNGCAPs.ToList();
        }

        // 🔹 Lọc theo tên nguyên liệu hoặc mã nhà cung cấp
        public List<KHO> FilterTonKho(string tenNguyenLieu, int? maNCC)
        {
            var query = db.KHOes
                .Include(k => k.NGUYENLIEU)
                .Include(k => k.NGUYENLIEU.NHACUNGCAP)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(tenNguyenLieu))
                query = query.Where(k => k.NGUYENLIEU.TenNL.Contains(tenNguyenLieu));

            if (maNCC.HasValue)
                query = query.Where(k => k.NGUYENLIEU.MaNCC == maNCC.Value);

            return query.ToList();
        }

        public void XoaKho(int maNL)
        {
            var kho = db.KHOes.FirstOrDefault(k => k.MaNL == maNL);
            if (kho == null)
                throw new Exception("Không tìm thấy nguyên liệu trong kho!");

            // Xóa bản ghi kho
            db.KHOes.Remove(kho);
            db.SaveChanges();

            // Xóa nguyên liệu tương ứng
            var nguyenLieu = db.NGUYENLIEUx.FirstOrDefault(n => n.MaNL == maNL);
            if (nguyenLieu != null)
            {
                db.NGUYENLIEUx.Remove(nguyenLieu);
                db.SaveChanges();
            }
        }


        /*
        // 🔹 Xóa nguyên liệu khỏi kho
        public void XoaKho(int maNL)
        {
            var kho = db.KHOes.FirstOrDefault(k => k.MaNL == maNL);
            if (kho != null)
            {
                db.KHOes.Remove(kho);
                db.SaveChanges();
            }
        }*/

        public void ThemHoacCapNhatKho(int maNL, decimal soLuong, DateTime? hanSuDung, string tenNguyenLieu = null, string donViTinh = null, int? maNCC = null)
        {
            if (string.IsNullOrWhiteSpace(tenNguyenLieu) || string.IsNullOrWhiteSpace(donViTinh) || maNCC == null)
            {
                throw new Exception("Thiếu thông tin nguyên liệu (Tên, Đơn vị tính, Nhà cung cấp)!");
            }

            // 🔎 Tìm nguyên liệu theo mã
            var nguyenLieu = db.NGUYENLIEUx.FirstOrDefault(n => n.MaNL == maNL);

            if (nguyenLieu != null)
            {
                // ✅ Đã tồn tại nguyên liệu, kiểm tra thông tin khớp
                if (!nguyenLieu.TenNL.Equals(tenNguyenLieu, StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Tên nguyên liệu không khớp với mã nguyên liệu!");

                if (nguyenLieu.MaNCC != maNCC)
                    throw new Exception("Nhà cung cấp không khớp với mã nguyên liệu!");

                if (!nguyenLieu.DonViTinh.Equals(donViTinh, StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Đơn vị tính không khớp với mã nguyên liệu!");

                // 🏭 Tìm xem kho đã có nguyên liệu này chưa
                var tonKho = db.KHOes.FirstOrDefault(k => k.MaNL == maNL);

                if (tonKho == null)
                {
                    // ➕ Nếu chưa có trong kho → thêm mới vào kho
                    var newKho = new KHO
                    {
                        MaNL = maNL,
                        SoLuong = soLuong,
                        HanSuDung = hanSuDung
                    };
                    db.KHOes.Add(newKho);
                }
                else
                {
                    // 🔄 Nếu đã có → cộng dồn số lượng
                    tonKho.SoLuong += soLuong;
                    if (hanSuDung.HasValue)
                        tonKho.HanSuDung = hanSuDung;
                }
            }
            else
            {
                // 🆕 Nếu nguyên liệu chưa có (hoặc đã bị xóa trước đó) → thêm mới
                var newNguyenLieu = new NGUYENLIEU
                {
                    MaNL = maNL,
                    TenNL = tenNguyenLieu,
                    DonViTinh = donViTinh,
                    MaNCC = maNCC.Value
                };
                db.NGUYENLIEUx.Add(newNguyenLieu);

                var newKho = new KHO
                {
                    MaNL = maNL,
                    SoLuong = soLuong,
                    HanSuDung = hanSuDung
                };
                db.KHOes.Add(newKho);
            }

            db.SaveChanges();
        }

    }
}
