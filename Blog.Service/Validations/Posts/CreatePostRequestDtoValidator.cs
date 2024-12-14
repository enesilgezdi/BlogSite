using BlogSite.Models.Posts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Validations.Posts;

public class CreatePostRequestDtoValidator : AbstractValidator<CreatePostRequestDto>
{
    public CreatePostRequestDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Post Baslıgı bos olamaz")
            .Length(2, 50).WithMessage("Post Baslıgı minimmum 2 max 50 karakterlii olmalıdır.");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content alanı bos olamaz");

    }

}
