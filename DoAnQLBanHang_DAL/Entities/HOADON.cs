namespace DoAnQLBanHang_DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        public int MaHD { get; set; }

        public int? MaKH { get; set; }

        public int MaNV { get; set; }

        public DateTime? NgayLap { get; set; }

        public decimal? TongTien { get; set; }

        public decimal? PhiGiaoHang { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string PhuongThucTT { get; set; }

        [StringLength(50)]
        public string LoaiDon { get; set; }

        [StringLength(255)]
        public string DiaChiGiaoHang { get; set; }

        [StringLength(20)]
        public string SDTGiaoHang { get; set; }

        [StringLength(100)]
        public string TenNguoiNhan { get; set; }

        public DateTime? ThoiGianGiao { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
