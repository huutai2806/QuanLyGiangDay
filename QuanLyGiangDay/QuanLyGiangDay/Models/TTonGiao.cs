using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TTonGiao
{
    public int MaTonGiao { get; set; }

    public string TenTonGiao { get; set; } = null!;

    public virtual ICollection<TGiaoVien> TGiaoViens { get; } = new List<TGiaoVien>();

    public virtual ICollection<TSinhVien> TSinhViens { get; } = new List<TSinhVien>();
}
