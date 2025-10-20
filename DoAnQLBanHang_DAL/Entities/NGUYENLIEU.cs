namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUYENLIEU")]
    public partial class NGUYENLIEU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUYENLIEU()
        {
            CONGTHUCs = new HashSet<CONGTHUC>();
            KHOes = new HashSet<KHO>();
            NHAPKHOes = new HashSet<NHAPKHO>();
        }

        [Key]
        public int MaNL { get; set; }

        [Required]
        [StringLength(150)]
        public string TenNL { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int? MaNCC { get; set; }

        public decimal? GiaNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGTHUC> CONGTHUCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO> KHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAPKHO> NHAPKHOes { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
