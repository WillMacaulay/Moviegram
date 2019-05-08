using FluentValidation; 
using MoviegramApi.WebUI.Api.ApiModels;

public class CreateMovieDTOValidator : AbstractValidator<MovieDTO>
{
    public CreateMovieDTOValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
        RuleFor(m => m.Duration).NotEmpty();
        RuleFor(m => m.ShowTime).NotEmpty();
    }
}