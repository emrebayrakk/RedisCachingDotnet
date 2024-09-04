using Microsoft.EntityFrameworkCore;
using RedisCachingDotnet.Context;
using RedisCachingDotnet.Repository;
using RedisCachingDotnet.Repository.CacheRepository;
using RedisCachingDotnet.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RedisCachingDotnetContext>(options =>
    options.UseSqlServer
        (builder.Configuration.GetConnectionString("RedisCachingDbContext")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.Decorate<IUserRepository, CachedUserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddStackExchangeRedisCache(opt =>
{
    string connection = builder.Configuration.GetConnectionString("Redis");
    opt.Configuration = connection;
});

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
