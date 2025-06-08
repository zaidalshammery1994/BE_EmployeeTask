namespace EmployeeTasks.Domain.Entities;

public class Employee
{
    public int EmployeeID { get; set; }
    public string? EmployeeName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDelete { get; set; }
    public bool IsActive { get; set; }
}
