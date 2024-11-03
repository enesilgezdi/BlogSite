using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using Blog.Service.Mappings;
using Blog.Service.Rules;
using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using BlogSite.Repository.Repositories.Concretes;
using BlogSite.WepApi.Middlewares;
using Core.Tokens.Configuraiton;
using Core.Tokens.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, EfPostRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository , EfCommentRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();

builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));
//var tokenOption = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<PostBusinessRules>();

builder.Services.AddScoped<CommentBusinessRules>();
builder.Services.AddScoped<CategoryBusinessRules>();
builder.Services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<BaseDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var tokenOption = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience[0],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOption.SecurityKey)
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();
