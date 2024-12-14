

using Blog.Service.Abstracts;
using Blog.Service.Concretes;
using Blog.Service.Mappings;
using Blog.Service.Rules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Service;

public static class ServiceDependencies
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<PostBusinessRules>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<CommentBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
