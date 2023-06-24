using Microsoft.EntityFrameworkCore;
using Project.DAL.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options=> options.AddDefaultPolicy(policy=>
policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<MyContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
