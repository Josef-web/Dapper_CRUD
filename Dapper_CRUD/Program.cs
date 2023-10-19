using Dapper_CRUD.Business;
using Dapper_CRUD.DataAccess;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();