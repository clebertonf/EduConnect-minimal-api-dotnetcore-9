using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using EduConnect.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public class DashboardHandlers
{
    public static async Task<Ok<Student>> GetStudantsDetailsAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var students = await context.Students
            .Include(s => s.Address)
            .Include(s => s.Enrollments)!
            .ThenInclude(s => s.Course)
            .FirstOrDefaultAsync(s => s.Id == id);
        
        return TypedResults.Ok(mapper.Map<Student>(students));
    }

    public static async Task<Ok<Course>> GetCourseDetailsAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var courses = await context.Courses
            .Include(c => c.Enrollments)!
            .ThenInclude(e => e.Student)!
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return TypedResults.Ok(mapper.Map<Course>(courses));
    }

    public static async Task<Ok<GeneralStatistics>> GetGeneralStatisticsAsync(ApplicationDbContext context, IMapper mapper)
    {
        var countActiveEnrollments = await context.Enrollments.Where(e => e.Status == "Active").CountAsync();
        var countDeactivatedEnrollments = await context.Enrollments.Where(e => e.Status == "Deactive").CountAsync();
        
        var totalStudents = await context.Students.CountAsync();
        var totalCourses = await context.Courses.CountAsync();
        var totalEnrollments = await context.Enrollments.CountAsync();
        
        var statistics = new GeneralStatistics
        {
            TotalStudants = totalStudents,
            TotalCourses = totalCourses,
            TotalEnrollments = totalEnrollments,
            TotalActiveEnrollments = countActiveEnrollments,
            TotalDeactivatedEnrollments = countDeactivatedEnrollments
        };
        
        return TypedResults.Ok(statistics);
    }
}