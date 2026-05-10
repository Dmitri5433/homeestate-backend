using HomeEstate.Domains;
using HomeEstate.DataAccess.Context;
using HomeEstate.DataAccess;
using HomeEstate.BusinessLogic;  
using HomeEstate.BusinessLogic.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DbSession>(options => 
    options.UseSqlite(connString));

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<DbSession>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "http://localhost:5174",
            "https://homeestate-peach.vercel.app"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

builder.Services.AddScoped<BusinessLogic>();
builder.Services.AddScoped<IApartment>(sp => sp.GetRequiredService<BusinessLogic>().GetApartmentActions());
builder.Services.AddScoped<IAuthActions>(sp => sp.GetRequiredService<BusinessLogic>().GetAuthActions());

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication(); 
app.UseAuthorization(); 
app.MapIdentityApi<User>();
app.MapControllers();
app.Run();