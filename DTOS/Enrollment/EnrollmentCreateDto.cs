namespace EduConnect.API.DTOS;

public class EnrollmentCreateDto
{
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset EnrollmentDate { get; set; }
    
    public int StudentId { get; set; }
    public int CourseId { get; set; }
}