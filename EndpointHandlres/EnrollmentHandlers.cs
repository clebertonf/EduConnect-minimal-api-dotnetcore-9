using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class EnrollmentHandlers
{
    public static async Task<Ok<IEnumerable<EnrollmentDto>>> GetEnrollmentsAsync(ApplicationDbContext context, IMapper mapper)
    {
        var enrollments = await context.Enrollments.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<EnrollmentDto>>(enrollments));
    }
 }