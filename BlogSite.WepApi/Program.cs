using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using Blog.Service.Mappings;
using Blog.Service.Rules;
using BlogSite.Models.Entities;
using BlogSite.Repository.Contexts;
using BlogSite.Repository.Repositories.Abstracts;
using BlogSite.Repository.Repositories.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, EfPostRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository , EfCommentRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();

builder.Services.AddScoped<PostBusinessRules>();
builder.Services.AddScoped<UserBusinessRules>();
builder.Services.AddScoped<CommentBusinessRules>();
builder.Services.AddScoped<CategoryBusinessRules>();
builder.Services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<BaseDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
