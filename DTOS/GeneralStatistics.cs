namespace EduConnect.API.DTOS;

public class GeneralStatistics
{
    public int TotalStudants { get; set; }
    public int TotalCourses { get; set; }
    public int TotalEnrollments { get; set; }
    public int TotalActiveEnrollments { get; set; }
    
    public int TotalDeactivatedEnrollments  { get; set; }
}