using Microsoft.EntityFrameworkCore;
using MilkTeaShopping.Entities;
using MilkTeaShopping.Helper;
using MilkTeaShopping.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MilkTeaShoppingContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("LocallinhConnection")));

// Cors
//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy("MyCors",
//        build =>
//        {
//            build
//                .AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//});

// khai báo cloundinay
builder.Services.Configure<CloundinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

// khai báo service
builder.Services.AddScoped<IProductService, ProductService>();

// Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors("MyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
