using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using EduConnect.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class EnrollmentHandlers
{
    public static async Task<Ok<IEnumerable<EnrollmentDto>>> GetEnrollmentsAsync(ApplicationDbContext context, IMapper mapper)
    {
        var enrollments = await context.Enrollments.
            Include(e => e.Course).ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<EnrollmentDto>>(enrollments));
    }

    public static async Task<Results<Ok<EnrollmentDto>, NotFound>> GetEnrollmetByIdAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var enrollment = await context.Enrollments
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (enrollment is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(mapper.Map<EnrollmentDto>(enrollment));
    }

    public static async Task<CreatedAtRoute<EnrollmentDto>> CreateEnrollmentAsync(ApplicationDbContext context, IMapper mapper, [FromBody] EnrollmentCreateDto enrollmentCreateDto)
    {
        var enrollment = mapper.Map<Enrollment>(enrollmentCreateDto);
        context.Enrollments.Add(enrollment);
        await context.SaveChangesAsync();
        var enrollmentDto = mapper.Map<EnrollmentDto>(enrollment);
        
        return TypedResults.CreatedAtRoute(enrollmentDto, "GetEnrollmentById", new { id = enrollment.Id });
    }

    public static async Task<Results<BadRequest, NotFound, NoContent>> UpdateEnrollmetAsync(ApplicationDbContext context, IMapper mapper, [FromBody] EnrollmentDto enrollmentDto, int id)
    {
        if(enrollmentDto.Id != id)
            return TypedResults.BadRequest();
        
        var enrollment = await context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
        if(enrollment is null)
            return TypedResults.NotFound();
        
        mapper.Map(enrollmentDto, enrollment);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public static async Task<Results<NotFound, NoContent>> DeleteEnrollmentAsync(ApplicationDbContext context, int id)
    {
        var enrollment = await context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
        if(enrollment is null)
            return TypedResults.NotFound();
        
        context.Enrollments.Remove(enrollment);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }
 }