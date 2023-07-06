using BUS;
using BUS.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["AppSettings:Audience"],
//        ValidIssuer = builder.Configuration["AppSettings:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),
//        RoleClaimType = "Role"
//    };
//});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//               .AddJwtBearer("Bearer", options =>
//               {
//                   options.ValidateIssuer = true,
//                   options.RequireHttpsMetadata = false;
//                   options.Audience = "Api";
//               });


//IdentityModelEventSource.ShowPII = true;


//builder.Services.AddCors(c =>
//{
//    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT..."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});




builder.Services.AddControllers();
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();

builder.Services.AddTransient<ILuongDAL, LuongDAL>();
builder.Services.AddTransient<ILuongBusiness, LuongBusiness>();

builder.Services.AddTransient<IUsersssDAL, UsersssDAL>();
builder.Services.AddTransient<IUsersBusiness, UsersBusiness>();

builder.Services.AddTransient<IMenuDAL, MenuDAL>();
builder.Services.AddTransient<IMenuBUS, MenuBus>();

builder.Services.AddTransient<IphongbanDAL, phongbanDAL>();
builder.Services.AddTransient<IphongbanBusiness, phongbanBusiness>();

builder.Services.AddTransient<IChinhanhDAL, chinhanhDAL>();
builder.Services.AddTransient<IchinhanhBusiness, chinhanhBusiness>();

builder.Services.AddTransient<ITonhomDAL, TonhomDAL>();
builder.Services.AddTransient<ITonhomBusiness, tonhomBusiness>();

builder.Services.AddTransient<INhanvienDAL, NhanvienDAL>();
builder.Services.AddTransient<INhanvienBusiness, NhanvienBusiness>();

builder.Services.AddTransient<IkiemtraDAL, kiemtraDAL>();
builder.Services.AddTransient<IkiemtraBusiness, kiemtraBusiness>();

builder.Services.AddTransient<ITimesDAL, TimeDAL>();
builder.Services.AddTransient<ItimeBusiness, TimeBusiness>();

builder.Services.AddTransient<IBacluongDAL, BacluongDAL>();
builder.Services.AddTransient<IBacluongBusiness, BacluongBusiness>();

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();



