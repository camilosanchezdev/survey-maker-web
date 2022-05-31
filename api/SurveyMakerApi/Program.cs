using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SurveyMakerApi.Core.Auth;
using SurveyMakerApi.Core.Middlewares;
using SurveyMakerApi.Domain;
using SurveyMakerApi.Persistence.Context;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
string mySqlConnectionStr = $"server={Environment.GetEnvironmentVariable("DB_SERVER")}; port = 3306; database = {Environment.GetEnvironmentVariable("DB_DATABASE")}; user = {Environment.GetEnvironmentVariable("DB_USER")}; password = {Environment.GetEnvironmentVariable("DB_PASSWORD")}; Persist Security Info=False; Connect Timeout = 300";
// Add services to the container.

// For Entity Framework
builder.Services.AddDbContextPool<SurveyMakerContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


builder.Services
    .AddControllers(options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
// Authorization
builder.Services.Configure<JWTConfig>(builder.Configuration);
builder.Services.AddSingleton<ITokenFactory, TokenFactory>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidAudience = configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
        };
    });
builder.Services.AddAuthorization(options =>
    options.AddPolicy("admin", policy => policy.RequireRole("admin"))
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile(new SurveyMakerApi.Domain.Mapper.Mapper());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var domainConfig = new DomainContext();

// Repositories
if (domainConfig.Repositories != null)
{
    for (int i = 0; i < domainConfig.Repositories.Length; i++)
    {
        builder.Services.AddScoped(domainConfig.Repositories[i].Item1, domainConfig.Repositories[i].Item2);
    }
}
// Services
if (domainConfig.Services != null)
{
    for (int i = 0; i < domainConfig.Services.Length; i++)
    {
        builder.Services.AddScoped(domainConfig.Services[i].Item1, domainConfig.Services[i].Item2);
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("corsapp");

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


//app.MapControllers();

app.Run();