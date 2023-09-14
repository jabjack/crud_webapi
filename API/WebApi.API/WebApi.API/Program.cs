using Microsoft.EntityFrameworkCore;
using WebApi.API.Data;
using WebApi.API.Repositories.Implementation;
using WebApi.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add de dependency DbContext

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("CodePulseConnectionString"));

}
);


//add injecte de repositoy patterns   the interface y metodo

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors( options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyOrigin();
        options.AllowAnyMethod();

    }
); 

app.UseAuthorization();

app.MapControllers();

app.Run();
