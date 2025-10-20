namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhatKyHeThong")]
    public partial class NhatKyHeThong
    {
        [Key]
        public int MaLog { get; set; }

        public int? MaNV { get; set; }

        public DateTime? ThoiGian { get; set; }

        [StringLength(100)]
        public string HanhDong { get; set; }

        [StringLength(1000)]
        public string ChiTiet { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
