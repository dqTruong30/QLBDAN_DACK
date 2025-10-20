namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUYENMAI")]
    public partial class KHUYENMAI
    {
        [Key]
        public int MaKM { get; set; }

        public int? MaMon { get; set; }

        public int? MaLoai { get; set; }

        public int? MaKH { get; set; }

        [StringLength(150)]
        public string TenKM { get; set; }

        [StringLength(50)]
        public string LoaiKM { get; set; }

        public decimal? GiaTri { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TuNgay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DenNgay { get; set; }

        [StringLength(255)]
        public string DieuKien { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual LOAIMON LOAIMON { get; set; }

        public virtual MONAN MONAN { get; set; }
    }
}
