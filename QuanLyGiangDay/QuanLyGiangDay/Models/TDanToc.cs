using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TDanToc
{
    public int MaDanToc { get; set; }

    public string TenDanToc { get; set; } = null!;

    public virtual ICollection<TGiaoVien> TGiaoViens { get; } = new List<TGiaoVien>();

    public virtual ICollection<TSinhVien> TSinhViens { get; } = new List<TSinhVien>();
}
