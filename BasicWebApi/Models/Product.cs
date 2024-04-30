namespace BasicWebApi.Models;

public class Product
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; set; }
    public double Price { get; init; }
}