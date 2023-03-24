using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TSinhVien
{
    public int MaSinhVien { get; set; }

    public string HoSinhVien { get; set; } = null!;

    public string TenSinhVien { get; set; } = null!;

    public int? MaLop { get; set; }

    public string? PhaiNu { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public int? MaQueQuan { get; set; }

    public byte[]? Hinh { get; set; }

    public int? MaDanToc { get; set; }

    public int? MaTonGiao { get; set; }

    public virtual TDanToc? MaDanTocNavigation { get; set; }

    public virtual TLop? MaLopNavigation { get; set; }

    public virtual TQueQuan? MaQueQuanNavigation { get; set; }

    public virtual TTonGiao? MaTonGiaoNavigation { get; set; }

    public virtual ICollection<TKetQua> TKetQuas { get; } = new List<TKetQua>();
}
