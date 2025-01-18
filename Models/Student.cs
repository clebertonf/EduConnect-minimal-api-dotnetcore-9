namespace EduConnect.API.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Address? Address { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}