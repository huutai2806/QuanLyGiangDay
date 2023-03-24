using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGiangDay.Models;

public partial class QuanLyGiangDayContext : DbContext
{
    public QuanLyGiangDayContext()
    {
    }

    public QuanLyGiangDayContext(DbContextOptions<QuanLyGiangDayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TDanToc> TDanTocs { get; set; }

    public virtual DbSet<TGiaoVien> TGiaoViens { get; set; }

    public virtual DbSet<TKetQua> TKetQuas { get; set; }

    public virtual DbSet<TLop> TLops { get; set; }

    public virtual DbSet<TMonHoc> TMonHocs { get; set; }

    public virtual DbSet<TPhanCong> TPhanCongs { get; set; }

    public virtual DbSet<TQueQuan> TQueQuans { get; set; }

    public virtual DbSet<TSinhVien> TSinhViens { get; set; }

    public virtual DbSet<TTonGiao> TTonGiaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=MvcSingerConnectionStrings");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TDanToc>(entity =>
        {
            entity.HasKey(e => e.MaDanToc).HasName("PK__tDanToc__A5FA0970D8FEF141");

            entity.ToTable("tDanToc");

            entity.Property(e => e.MaDanToc).ValueGeneratedNever();
            entity.Property(e => e.TenDanToc).HasMaxLength(50);
        });

        modelBuilder.Entity<TGiaoVien>(entity =>
        {
            entity.HasKey(e => e.MaGiaoVien).HasName("PK__tGiaoVie__8D374F50EA23CFAE");

            entity.ToTable("tGiaoVien");

            entity.Property(e => e.MaGiaoVien).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.PhaiNu).HasMaxLength(3);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenGiaoVien).HasMaxLength(50);

            entity.HasOne(d => d.MaDanTocNavigation).WithMany(p => p.TGiaoViens)
                .HasForeignKey(d => d.MaDanToc)
                .HasConstraintName("FK__tGiaoVien__MaDan__300424B4");

            entity.HasOne(d => d.MaQueQuanNavigation).WithMany(p => p.TGiaoViens)
                .HasForeignKey(d => d.MaQueQuan)
                .HasConstraintName("FK__tGiaoVien__MaQue__2F10007B");

            entity.HasOne(d => d.MaTonGiaoNavigation).WithMany(p => p.TGiaoViens)
                .HasForeignKey(d => d.MaTonGiao)
                .HasConstraintName("FK__tGiaoVien__MaTon__30F848ED");
        });

        modelBuilder.Entity<TKetQua>(entity =>
        {
            entity.HasKey(e => new { e.MaPhanCong, e.MaSinhVien, e.LanThi }).HasName("PC_MaPhanCong_MaSinhVien_LanThi_PK");

            entity.ToTable("tKetQua");

            entity.Property(e => e.GhiChu).IsUnicode(false);

            entity.HasOne(d => d.MaPhanCongNavigation).WithMany(p => p.TKetQuas)
                .HasForeignKey(d => d.MaPhanCong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tKetQua__MaPhanC__412EB0B6");

            entity.HasOne(d => d.MaSinhVienNavigation).WithMany(p => p.TKetQuas)
                .HasForeignKey(d => d.MaSinhVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tKetQua__MaSinhV__4222D4EF");
        });

        modelBuilder.Entity<TLop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__tLop__3B98D273FE28ABC0");

            entity.ToTable("tLop");

            entity.Property(e => e.MaLop).ValueGeneratedNever();
            entity.Property(e => e.MaGvcn).HasColumnName("MaGVCN");
            entity.Property(e => e.TenLop).HasMaxLength(50);

            entity.HasOne(d => d.MaGvcnNavigation).WithMany(p => p.TLops)
                .HasForeignKey(d => d.MaGvcn)
                .HasConstraintName("FK__tLop__MaGVCN__33D4B598");
        });

        modelBuilder.Entity<TMonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMonHoc).HasName("PK__tMonHoc__4127737F290E0110");

            entity.ToTable("tMonHoc");

            entity.Property(e => e.MaMonHoc).ValueGeneratedNever();
            entity.Property(e => e.TenMonHoc).HasMaxLength(50);
        });

        modelBuilder.Entity<TPhanCong>(entity =>
        {
            entity.HasKey(e => e.MaPhanCong).HasName("PK__tPhanCon__C279D916FC281775");

            entity.ToTable("tPhanCong");

            entity.Property(e => e.MaPhanCong).ValueGeneratedNever();
            entity.Property(e => e.NgayBatDau).HasColumnType("date");
            entity.Property(e => e.NgayKetThuc).HasColumnType("date");

            entity.HasOne(d => d.MaGiaoVienNavigation).WithMany(p => p.TPhanCongs)
                .HasForeignKey(d => d.MaGiaoVien)
                .HasConstraintName("FK__tPhanCong__MaGia__3D5E1FD2");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.TPhanCongs)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK__tPhanCong__MaLop__3E52440B");

            entity.HasOne(d => d.MaMonHocNavigation).WithMany(p => p.TPhanCongs)
                .HasForeignKey(d => d.MaMonHoc)
                .HasConstraintName("FK__tPhanCong__MaMon__3C69FB99");
        });

        modelBuilder.Entity<TQueQuan>(entity =>
        {
            entity.HasKey(e => e.MaQueQuan).HasName("PK__tQueQuan__5C969AF6992C95FB");

            entity.ToTable("tQueQuan");

            entity.Property(e => e.MaQueQuan).ValueGeneratedNever();
            entity.Property(e => e.TenPhuongXa).HasMaxLength(50);
            entity.Property(e => e.TenQuanHuyen).HasMaxLength(50);
            entity.Property(e => e.TenTinhThanhPho).HasMaxLength(50);
        });

        modelBuilder.Entity<TSinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("PK__tSinhVie__939AE775052EB7E1");

            entity.ToTable("tSinhVien");

            entity.Property(e => e.MaSinhVien).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(100);
            entity.Property(e => e.Hinh).HasColumnType("image");
            entity.Property(e => e.HoSinhVien).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.PhaiNu).HasMaxLength(3);
            entity.Property(e => e.TenSinhVien).HasMaxLength(50);

            entity.HasOne(d => d.MaDanTocNavigation).WithMany(p => p.TSinhViens)
                .HasForeignKey(d => d.MaDanToc)
                .HasConstraintName("FK__tSinhVien__MaDan__38996AB5");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.TSinhViens)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK__tSinhVien__MaLop__36B12243");

            entity.HasOne(d => d.MaQueQuanNavigation).WithMany(p => p.TSinhViens)
                .HasForeignKey(d => d.MaQueQuan)
                .HasConstraintName("FK__tSinhVien__MaQue__37A5467C");

            entity.HasOne(d => d.MaTonGiaoNavigation).WithMany(p => p.TSinhViens)
                .HasForeignKey(d => d.MaTonGiao)
                .HasConstraintName("FK__tSinhVien__MaTon__398D8EEE");
        });

        modelBuilder.Entity<TTonGiao>(entity =>
        {
            entity.HasKey(e => e.MaTonGiao).HasName("PK__tTonGiao__C49C68F99D25FDDF");

            entity.ToTable("tTonGiao");

            entity.Property(e => e.MaTonGiao).ValueGeneratedNever();
            entity.Property(e => e.TenTonGiao).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
