using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TLop
{
    public int MaLop { get; set; }

    public string TenLop { get; set; } = null!;

    public int? MaNganhHoc { get; set; }

    public int? MaGvcn { get; set; }

    public virtual TGiaoVien? MaGvcnNavigation { get; set; }

    public virtual ICollection<TPhanCong> TPhanCongs { get; } = new List<TPhanCong>();

    public virtual ICollection<TSinhVien> TSinhViens { get; } = new List<TSinhVien>();
}
