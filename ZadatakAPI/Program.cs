using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ZadatakAPI.Extensions;
using ZadatakAPI.Data;
using ZadatakAPI.Core;
using ZadatakAPI.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<ZadatakAPIDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ZadatakAPIDB")));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.Password.RequiredLength = 4)
    .AddEntityFrameworkStores<ZadatakAPIDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //CORS
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
