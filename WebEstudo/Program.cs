using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebEstudo.DAO;
using WebEstudo.DAO.EntidadesDAO;
using WebEstudo.DAO.Factory;
using WebEstudo.DAO.InterFaces;
using WebEstudo.DTO.Interfaces;
using WebEstudo.DTO.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<Conexao>();

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.Configure<DaoContext>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddDbContext<DaoContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient<IRepository, Conexao>();
builder.Services.AddTransient<IUsuarioDao, UsuarioDAO>();
builder.Services.AddTransient<IUsuarioDTO, UsuarioServices>();
builder.Services.AddTransient<IProdutoDao, ProdutoDAO>();
builder.Services.AddTransient<IProdutoDTO, ProdutoServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add JWT Authentication Middleware - This code will intercept HTTP request and validate the JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt => {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
  );


var app = builder.Build();

app.UseCors(policy =>
            policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            );


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseAuthentication();

app.MapControllers();

app.Run();
