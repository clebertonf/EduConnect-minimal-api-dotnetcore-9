using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class AddressHandlers
{
    public static async Task<Ok<IEnumerable<AddressDto>>> GetAddressAsync(ApplicationDbContext context, IMapper mapper)
    {
        var address = await context.Addresses.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<AddressDto>>(address));
    }
}