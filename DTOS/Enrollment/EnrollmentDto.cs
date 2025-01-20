namespace EduConnect.API.DTOS;

public class EnrollmentDto
{
    public int Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset EnrollmentDate { get; set; }
    
    public int StudentId { get; set; }
    public int CourseId { get; set; } 
    public CourseDto? Course { get; set; }
}