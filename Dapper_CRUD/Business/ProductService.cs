using Dapper;
using Dapper_CRUD.DataAccess;
using Dapper_CRUD.DTOs.ProductDto;

namespace Dapper_CRUD.Business;

public class ProductService:IProductService
{
    private readonly Context _context;

    public ProductService(Context context)
    {
        _context = context;
    }
    
    public async Task<List<GetProductDto>> GetAllProductsAsync()
    {
        string query = "SELECT * FROM DapperProduct";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<GetProductDto>(query);
            return values.ToList();
        }
    }

    public async void InsertProduct(CreateProductDto product)
    {
        string query =
            "INSERT INTO DapperProduct (Title, Price, City, District) VALUES (@Title, @Price, @City, @District)";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", product.Title);
        parameters.Add("@Price", product.Price);
        parameters.Add("@City", product.City);
        parameters.Add("@District", product.District);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteProduct(int id)
    {
        string query = "DELETE FROM DapperProduct WHERE ProductId=@productId";
        var parameters = new DynamicParameters();
        parameters.Add("@productId",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void UpdateProduct(UpdateProductDto product)
    {
        string query = "UPDATE DapperProduct SET Title=@title,Price=@price,City=@city ,District=@district  WHERE ProductId=@productId";
        var parameters = new DynamicParameters();
        parameters.Add("@productId", product.ProductId);
        parameters.Add("@title", product.Title);
        parameters.Add("@price", product.Price);
        parameters.Add("@city", product.City);
        parameters.Add("@district", product.District);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetProductDto> GetProductById(int id)
    {
        string query = "SELECT * FROM DapperProduct WHERE ProductId=@ProductId";
        var parameters = new DynamicParameters();
        parameters.Add("@ProductId", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetProductDto>(query, parameters);
            return value;
        }
    }
}