using EduConnect.API.EndpointHandlres;

namespace EduConnect.API.Extensions;

public static class EndPointRouterBuilderExtensions
{
    public static void RegisterStudentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/student").WithTags("Student");
        baseEndpoint.MapGet("", StudentHandlers.GetStudentsAsync);
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