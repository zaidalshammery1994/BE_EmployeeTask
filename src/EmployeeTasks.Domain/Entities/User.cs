namespace EmployeeTasks.Domain.Entities;

public class User
{
    public string? UserID { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDelete { get; set; }
    public bool IsActive { get; set; }
}
