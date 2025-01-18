namespace EduConnect.API.Models;

public class Enrollment
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset EnrollmentDate { get; set; }
    
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}