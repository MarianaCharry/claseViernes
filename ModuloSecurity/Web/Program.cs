using Business.Implements;
using Business.Interface;
using Data.Implements;
using Data.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Configura DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDBContext>(optiones =>
optiones.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection")));

// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityData, cityData>();
builder.Services.AddScoped<ICountryData, countryData>();
builder.Services.AddScoped<IModuloData, ModuloData>();
builder.Services.AddScoped<IPersonData, PersonData>();
builder.Services.AddScoped<IRoleData, RoleData>();
builder.Services.AddScoped<IRoleViewData, RoleViewData>();
builder.Services.AddScoped<IStateData, stateData>();
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();
builder.Services.AddScoped<IViewData, ViewData>();



builder.Services.AddScoped<ICityBusiness, cityBusiness>();
builder.Services.AddScoped<ICountryBusiness, countryBusiness>();
builder.Services.AddScoped<IModuloBusiness, ModuloBusiness>();
builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
builder.Services.AddScoped<IStateBusiness, stateBusiness>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IViewBusiness, ViewBusiness>();

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