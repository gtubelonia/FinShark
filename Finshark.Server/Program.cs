using FinShark.Data;
using FinShark.Interfaces;
using FinShark.Models;
using FinShark.Repository;
using FinShark.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(option =>
//{
//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});

//Add SqlConnection
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
}).AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});

builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IFMPService, FMPService>();
builder.Services.AddHttpClient<IFMPService, FMPService>();

builder.Services.AddControllers()
   .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
//.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials()
.WithOrigins("http://localhost:5173/", "https://gtubelonia.github.io/FinShark/")
.SetIsOriginAllowed(origin => true));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
