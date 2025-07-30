using Microsoft.EntityFrameworkCore;
using Nexus.NPS.Infra;
using Nexus.NPS.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NpsDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ReviewServices>();
builder.Services.AddScoped<DashboardServices>();
//builder.Services.AddScoped

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend", policy =>
		policy.WithOrigins("http://localhost:3000")
			.AllowAnyHeader()
			.AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");
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
