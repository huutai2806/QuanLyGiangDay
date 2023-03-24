using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TMonHoc
{
    public int MaMonHoc { get; set; }

    public string TenMonHoc { get; set; } = null!;

    public int? SoTietLyThuyet { get; set; }

    public int? SoTietThucHanh { get; set; }

    public virtual ICollection<TPhanCong> TPhanCongs { get; } = new List<TPhanCong>();
}
