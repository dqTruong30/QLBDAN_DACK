namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGTHUC")]
    public partial class CONGTHUC
    {
        [Key]
        public int MaCongThuc { get; set; }

        public int MaMon { get; set; }

        public int MaNL { get; set; }

        public decimal SoLuong { get; set; }

        [StringLength(50)]
        public string DonVi { get; set; }

        public virtual MONAN MONAN { get; set; }

        public virtual NGUYENLIEU NGUYENLIEU { get; set; }
    }
}
