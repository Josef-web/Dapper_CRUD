namespace Dapper_CRUD.DTOs.ProductDto;

public class CreateProductDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string City { get; set; }
    public string District { get; set; }
}