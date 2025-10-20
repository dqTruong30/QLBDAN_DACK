namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATHANGTRUOC")]
    public partial class DATHANGTRUOC
    {
        [Key]
        public int MaDat { get; set; }

        [StringLength(120)]
        public string TenNguoiDat { get; set; }

        [StringLength(20)]
        public string SDTNguoiDat { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime ThoiGianGiao { get; set; }

        [StringLength(255)]
        public string DiaChiGiaoHang { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(255)]
        public string GhiChu { get; set; }
    }
}
