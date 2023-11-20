namespace VnResourceTestBE.Models;

public partial class KhoaHoc
{
    public int Id { get; set; }

    public string? TenKhoaHoc { get; set; }

    public virtual ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();
}
