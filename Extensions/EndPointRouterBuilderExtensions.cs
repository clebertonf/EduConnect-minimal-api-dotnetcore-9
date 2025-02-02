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
        var baseEndpoint = endpoints.MapGroup("/").WithTags("Address");
        baseEndpoint.MapGet("address", AddressHandlers.GetAddressAsync);
        baseEndpoint.MapGet("address/{id:int}", AddressHandlers.GetAddressByIdAsync).WithName("GetAddressById");
        baseEndpoint.MapPost("address", AddressHandlers.CreateAddressAsync);
        baseEndpoint.MapPut("address/{id:int}", AddressHandlers.UpdateAddressAsync);
        baseEndpoint.MapDelete("address/{id:int}", AddressHandlers.DeleteAddressAsync);
    }
    
    public static void RegisterCourseEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/").WithTags("Course");
        baseEndpoint.MapGet("courses", CourseHandlers.GetCoursesAsync);
        baseEndpoint.MapGet("course/{id:int}", CourseHandlers.GetCourseByIdAsync).WithName("GetCourseById");
        baseEndpoint.MapPost("course", CourseHandlers.CreateCourseAsync);
        baseEndpoint.MapPut("course/{id:int}", CourseHandlers.UpdateCourseAsync);
        baseEndpoint.MapDelete("course/{id:int}", CourseHandlers.DeleteCourseAsync);
    }
    
    public static void RegisterEnrollmentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/").WithTags("Enrollment");
        baseEndpoint.MapGet("enrollment", EnrollmentHandlers.GetEnrollmentsAsync);
        baseEndpoint.MapGet("enrollment/{id:int}", EnrollmentHandlers.GetEnrollmetByIdAsync).WithName("GetEnrollmentById");
        baseEndpoint.MapPost("enrollment", EnrollmentHandlers.CreateEnrollmentAsync);
        baseEndpoint.MapPut("enrollment/{id:int}", EnrollmentHandlers.UpdateEnrollmetAsync);
        baseEndpoint.MapDelete("enrollment/{id:int}", EnrollmentHandlers.DeleteEnrollmentAsync);
    }

    public static void RegisterDashboardEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("Dashboard/").WithTags("Dashboard");
        baseEndpoint.MapGet("students/{id:int}/details", DashboardHandlers.GetStudantsDetailsAsync);
        baseEndpoint.MapGet("courses/{id:int}/details", DashboardHandlers.GetCourseDetailsAsync);
        baseEndpoint.MapGet("statistics", DashboardHandlers.GetGeneralStatisticsAsync);
    }
}