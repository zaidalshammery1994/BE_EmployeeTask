namespace EmployeeTasks.Domain.Entities;

public class EmployeeTask
{
    public int EmployeeTaskID { get; set; }
    public int EmployeeID { get; set; }
    public string? Task { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDelete { get; set; }
    public bool IsActive { get; set; }
}
