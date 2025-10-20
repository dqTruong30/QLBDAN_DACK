using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoAnQLBanHang_DAL.Entities
{
    public partial class QLBDANmodel : DbContext
    {
        public QLBDANmodel()
            : base("name=QLBDANmodel")
        {
        }

        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CONGTHUC> CONGTHUCs { get; set; }
        public virtual DbSet<DATHANGTRUOC> DATHANGTRUOCs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KHO> KHOes { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<LOAIMON> LOAIMONs { get; set; }
        public virtual DbSet<MONAN> MONANs { get; set; }
        public virtual DbSet<NGUYENLIEU> NGUYENLIEUx { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAPKHO> NHAPKHOes { get; set; }
        public virtual DbSet<NhatKyHeThong> NhatKyHeThongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.ThanhTien)
                .HasPrecision(29, 2);

            modelBuilder.Entity<CONGTHUC>()
                .Property(e => e.SoLuong)
                .HasPrecision(18, 3);

            modelBuilder.Entity<DATHANGTRUOC>()
                .Property(e => e.SDTNguoiDat)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.SDTGiaoHang)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHO>()
                .Property(e => e.SoLuong)
                .HasPrecision(18, 3);

            modelBuilder.Entity<LOAIMON>()
                .HasMany(e => e.MONANs)
                .WithRequired(e => e.LOAIMON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONAN>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.MONAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONAN>()
                .HasMany(e => e.CONGTHUCs)
                .WithRequired(e => e.MONAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .HasMany(e => e.CONGTHUCs)
                .WithRequired(e => e.NGUYENLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .HasMany(e => e.KHOes)
                .WithRequired(e => e.NGUYENLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUYENLIEU>()
                .HasMany(e => e.NHAPKHOes)
                .WithRequired(e => e.NGUYENLIEU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.NHAPKHOes)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.CCCD)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAPKHO>()
                .Property(e => e.SoLuong)
                .HasPrecision(18, 3);
        }
    }
}
