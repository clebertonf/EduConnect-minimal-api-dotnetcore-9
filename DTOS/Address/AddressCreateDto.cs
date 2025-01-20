namespace EduConnect.API.DTOS;

public class AddressCreateDto
{
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int StudentId { get; set; }
}