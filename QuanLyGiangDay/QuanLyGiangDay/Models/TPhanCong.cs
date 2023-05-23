using System;
using System.Collections.Generic;

namespace QuanLyGiangDay.Models;

public partial class TPhanCong
{
    public int MaPhanCong { get; set; }

    public int? MaMonHoc { get; set; }

    public int? MaGiaoVien { get; set; }

    public int? MaLop { get; set; }

    public int? HocKy { get; set; }

    public int? Nam { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public virtual TGiaoVien? MaGiaoVienNavigation { get; set; }

    public virtual TLop? MaLopNavigation { get; set; }

    public virtual TMonHoc? MaMonHocNavigation { get; set; }

    public virtual ICollection<TKetQua> TKetQuas { get; } = new List<TKetQua>();
}
