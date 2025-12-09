//تا دقیقه 16 قسمت 7

using Asp.Versioning;
using AutoMapper;
using IDP.Application.Handller.Command.User;
using IDP.Domain.IRepository.Command.Base;
using IDP.Infra.Repository.Command;
using MediatR;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region redisconfig
builder.Services.AddStackExchangeRedisCache(opition =>
{
    opition.Configuration = builder.Configuration.GetValue<string>("CashSetting:RedisUrl");
});
// Auto Mapper Configurations
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new MappingProfile());
//});

//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);

#endregion
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(UserHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped<IOtpRedisRepository, OtpRedisRepository>();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
})
.AddMvc() // This is needed for controllers
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

Auth.Extensions.AddJwt(builder.Services, builder.Configuration); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
