using AutoMapper;
using EduConnect.API.Context;
using EduConnect.API.DTOS;
using EduConnect.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduConnect.API.EndpointHandlres;

public static class AddressHandlers
{
    public static async Task<Ok<IEnumerable<AddressDto>>> GetAddressAsync(ApplicationDbContext context, IMapper mapper)
    {
        var address = await context.Addresses.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<AddressDto>>(address));
    }

    public static async Task<Results<Ok<AddressDto>, NotFound>> GetAddressByIdAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var address = await context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if (address is null)
            return TypedResults.NotFound();
        
        return TypedResults.Ok(mapper.Map<AddressDto>(address));
    }

    public static async Task<CreatedAtRoute<AddressCreateDto>> CreateAddressAsync(ApplicationDbContext context, IMapper mapper, [FromBody] AddressCreateDto address)
    {
        var addressEntity = mapper.Map<Address>(address);
        await context.AddAsync(addressEntity);
        await context.SaveChangesAsync();
        var addressDto = mapper.Map<AddressCreateDto>(addressEntity);

        return TypedResults.CreatedAtRoute(addressDto, "GetAddressById", new { id = addressEntity.Id });
    }

    public static async Task<Results<NoContent, BadRequest, NotFound>> UpdateAddressAsync(ApplicationDbContext context, IMapper mapper, [FromBody] AddressDto addressUpdate, int id)
    {
        if(addressUpdate.Id != id)
            return TypedResults.BadRequest();
        
        var address = await context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if(address is null)
            return TypedResults.NotFound();
        
        mapper.Map(addressUpdate, address);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
        
    }
    
    public static async Task<Results<NoContent, NotFound>> DeleteAddressAsync(ApplicationDbContext context, IMapper mapper, int id)
    {
        var addressEntity = await context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
        if(addressEntity is null)
            return TypedResults.NotFound();
        
        context.Remove(addressEntity);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }
}