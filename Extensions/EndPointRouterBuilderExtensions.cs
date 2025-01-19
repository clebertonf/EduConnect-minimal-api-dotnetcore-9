﻿using EduConnect.API.EndpointHandlres;

namespace EduConnect.API.Extensions;

public static class EndPointRouterBuilderExtensions
{
    public static void RegisterStudentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/").WithTags("Student");
        baseEndpoint.MapGet("students", StudentHandlers.GetStudentsAsync);
        baseEndpoint.MapGet("student/{id:int}", StudentHandlers.GetStudentIdAsync).WithName("GetStudentById");
        baseEndpoint.MapGet("student/{id:int}/address", StudentHandlers.GetStudentWithAddressAsync);
        baseEndpoint.MapGet("student/{id:int}/enrollments", StudentHandlers.GetStudentsWithEnrollmentsAsync);
        baseEndpoint.MapGet("student/{id}/courses", StudentHandlers.GetStudentWithCoursesAsync);
        baseEndpoint.MapPost("student", StudentHandlers.CreateStudentAsync);
        baseEndpoint.MapPut("student/{id:int}", StudentHandlers.UpdateStudentAsync);
        baseEndpoint.MapDelete("student/{id:int}", StudentHandlers.DeleteStudentAsync);

    }
    
    public static void RegisterAddressEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/address").WithTags("Address");
        baseEndpoint.MapGet("", AddressHandlers.GetAddressAsync);
    }
    
    public static void RegisterCourseEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/course").WithTags("Course");
        baseEndpoint.MapGet("", CourseHandlers.GetCoursesAsync);
    }
    
    public static void RegisterEnrollmentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/enrollment").WithTags("Enrollment");
        baseEndpoint.MapGet("", EnrollmentHandlers.GetEnrollmentsAsync);
    }
}