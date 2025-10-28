namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONs = new HashSet<HOADON>();
            NhatKyHeThongs = new HashSet<NhatKyHeThong>();
        }

        [Key]
        public int MaNV { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNV { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]
        public string CCCD { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(256)]
        public string MatKhau { get; set; }

        [StringLength(50)]
        public string VaiTro { get; set; }

        public bool? VoHieuHoa { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public DateTime? NgayTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhatKyHeThong> NhatKyHeThongs { get; set; }
        public object CHUCVU { get; set; }
    }
}
