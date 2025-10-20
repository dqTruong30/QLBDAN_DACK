namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAPKHO")]
    public partial class NHAPKHO
    {
        [Key]
        public int MaPhieu { get; set; }

        public int MaNCC { get; set; }

        public int MaNL { get; set; }

        public decimal SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhap { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }

        public virtual NGUYENLIEU NGUYENLIEU { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
