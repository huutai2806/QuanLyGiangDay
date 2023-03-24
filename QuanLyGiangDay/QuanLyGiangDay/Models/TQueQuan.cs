using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TQueQuan
{
    public int MaQueQuan { get; set; }

    public string TenTinhThanhPho { get; set; } = null!;

    public string? TenQuanHuyen { get; set; }

    public string? TenPhuongXa { get; set; }

    public virtual ICollection<TGiaoVien> TGiaoViens { get; } = new List<TGiaoVien>();

    public virtual ICollection<TSinhVien> TSinhViens { get; } = new List<TSinhVien>();
}
