namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MONAN")]
    public partial class MONAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONAN()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
            CONGTHUCs = new HashSet<CONGTHUC>();
            KHUYENMAIs = new HashSet<KHUYENMAI>();
        }

        [Key]
        public int MaMon { get; set; }

        [Required]
        [StringLength(150)]
        public string TenMon { get; set; }

        public int MaLoai { get; set; }

        public decimal DonGia { get; set; }

        public bool? TrangThai { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGTHUC> CONGTHUCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHUYENMAI> KHUYENMAIs { get; set; }

        public virtual LOAIMON LOAIMON { get; set; }
    }
}
