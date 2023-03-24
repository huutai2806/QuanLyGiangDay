using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TGiaoVien
{
    public int MaGiaoVien { get; set; }

    public string TenGiaoVien { get; set; } = null!;

    public string? PhaiNu { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public int? MaQueQuan { get; set; }

    public int? MaDanToc { get; set; }

    public int? MaTonGiao { get; set; }

    public virtual TDanToc? MaDanTocNavigation { get; set; }

    public virtual TQueQuan? MaQueQuanNavigation { get; set; }

    public virtual TTonGiao? MaTonGiaoNavigation { get; set; }

    public virtual ICollection<TLop> TLops { get; } = new List<TLop>();

    public virtual ICollection<TPhanCong> TPhanCongs { get; } = new List<TPhanCong>();
}
