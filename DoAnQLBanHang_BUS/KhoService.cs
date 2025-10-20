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
    }
}
