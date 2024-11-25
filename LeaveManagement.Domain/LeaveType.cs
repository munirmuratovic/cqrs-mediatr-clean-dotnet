using LeaveManagement.Domain.Common;

namespace LeaveManagement.Domain;

public class LeaveType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
