namespace EduConnect.API.DTOS;

public class EnrollmentDto
{
    public string Status { get; set; } = string.Empty;
    public DateTimeOffset EnrollmentDate { get; set; }
}