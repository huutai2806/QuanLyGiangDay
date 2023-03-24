using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TKetQua
{
    public int MaPhanCong { get; set; }

    public int MaSinhVien { get; set; }

    public int LanThi { get; set; }

    public double? Diem { get; set; }

    public string? GhiChu { get; set; }

    public virtual TPhanCong MaPhanCongNavigation { get; set; } = null!;

    public virtual TSinhVien MaSinhVienNavigation { get; set; } = null!;
}
