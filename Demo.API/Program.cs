using Demo.BusinessTier.Services;
using Demo.BusinessTier.Services.Implements;
using Demo.DataTier.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Package management console
//cd Project.Data (folder dataTier)
//dotnet ef --startup-project ../Project.Api/ migrations add Initial (change Project.API to Demo.API)
builder.Services.AddDbContext<DemoDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnectionString")));
//Create instance of Service
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
