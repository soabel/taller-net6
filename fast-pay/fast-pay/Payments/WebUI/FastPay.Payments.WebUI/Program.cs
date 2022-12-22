using System.Net.Sockets;
using FastPay.Payments.Application;
using FastPay.Payments.Infrastructure;
using FastPay.Payments.WebUI;
using Microsoft.AspNetCore.Authentication.JwtBearer; //Agregar nuget
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebUIServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://alfredobenaute.us.auth0.com/";
    options.Audience = "https://fastpay-payments/api/";
}); // add security

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication(); 

app.UseAuthorization();

app.MapControllers();
app.Run();

//docker build -t fastpay-payments -f Payments/WebUI/FastPay.Payments.WebUI/Dockerfile .
//docker run -d --name fastpay-payments -p 8088:80 -p 8089:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8089 -e ASPNETCORE_Kestrel__Certificates__Default__Password=dasser -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v ${HOME}/.aspnet/https:/https/ fastpay-payments
