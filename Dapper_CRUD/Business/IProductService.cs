using Dapper_CRUD.DTOs.ProductDto;

namespace Dapper_CRUD.Business;

public interface IProductService
{
    Task<List<GetProductDto>> GetAllProductsAsync();
    void InsertProduct(CreateProductDto product);
    void DeleteProduct(int id);
    void UpdateProduct(UpdateProductDto product);
    Task<GetProductDto> GetProductById(int id);
}