﻿namespace EduConnect.API.DTOS;

public class AddressDto
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
}