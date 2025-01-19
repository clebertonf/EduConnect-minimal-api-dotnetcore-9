namespace EduConnect.API.Extensions;

public static class EndPointRouterBuilderExtensions
{
    public static void RegisterStudentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/student").WithTags("Student");
        baseEndpoint.MapGet("", () => "Hello World!");
    }
    
    public static void RegisterAddressEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/address").WithTags("Address");
        baseEndpoint.MapGet("", () => "Hello World!");
    }
    
    public static void RegisterCourseEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/course").WithTags("Course");
        baseEndpoint.MapGet("", () => "Hello World!");
    }
    
    public static void RegisterEnrollmentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var baseEndpoint = endpoints.MapGroup("/enrollment").WithTags("Enrollment");
        baseEndpoint.MapGet("", () => "Hello World!");
    }
}