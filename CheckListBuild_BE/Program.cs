using CheckListBuild_BE.Database;
using CheckListBuild_BE.service;
using CheckListBuild_BE.service.impl;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CheckListBuild_BE.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.Configure<CheckListConfiguration>(
    builder.Configuration.GetSection("CheckListConfiguration"));

builder.Services.AddSingleton<ApplicationDbContext>();

builder.Services.AddSingleton<ICheckListService, CheckListServiceImpl>();
builder.Services.AddSingleton<ICheckListItem, CheckListItemServiceImpl>();
builder.Services.AddSingleton<IUserService, UserServiceImpl>();
builder.Services.AddSingleton<IAuthService, AuthServiceImpl>();

//configure jwt authentication

string authenticationSecret = CommonConfig.AccessTokenConfig.SecretKey;
var key = Encoding.ASCII.GetBytes(authenticationSecret);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAllOrigins");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
