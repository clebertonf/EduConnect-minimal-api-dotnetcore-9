﻿namespace EduConnect.API.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TimeSpan Duration { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}