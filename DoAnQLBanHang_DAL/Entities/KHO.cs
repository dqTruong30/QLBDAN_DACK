namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHO")]
    public partial class KHO
    {
        [Key]
        public int MaKho { get; set; }

        public int MaNL { get; set; }

        public decimal? SoLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        public virtual NGUYENLIEU NGUYENLIEU { get; set; }
    }
}
