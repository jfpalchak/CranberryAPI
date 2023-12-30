using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CranberryAPI.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myCranberryCORS";
builder.Services.AddCors(options => 
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy => 
                    {
                      policy.WithOrigins("http://localhost:3000", 
                                          "https://cranberry-quit.vercel.app")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                    });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CranberryAPIContext>(
                  dbContextOptions => dbContextOptions
                    .UseMySql(
                    	builder.Configuration["ConnectionStrings:DefaultConnection"],
                      ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                  )
                );

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<CranberryAPIContext>()
  .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => 
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:ValidAudience"],
    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
  };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseHttpsRedirection();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();