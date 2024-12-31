
using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator: AbstractValidator<CreateGuestDto>//burada sınıf değil dto referans alınır
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter girin");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En az 3 karakter girin");
        }
    }
}
