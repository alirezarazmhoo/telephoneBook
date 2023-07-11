using FluentValidation;
using static Telephonebook.Features.Persons.AddNewPerson;

namespace Telephonebook.Validator
{
	public class RegisterPersonValidator : AbstractValidator<Command>
	{
		public RegisterPersonValidator() {
			RuleFor(p => p.FullName).NotEmpty().WithMessage("نام و نام خانوادگی خالی است ").MinimumLength(5).WithMessage("تعداد کاراکتر ها کم است");
			RuleFor(p => p.Address).NotEmpty().WithMessage("آدرس را وارد کنید").MinimumLength(5).WithMessage("تعداد کاراکتر ها کم است");
			RuleFor(p => p.Email).NotEmpty().EmailAddress().WithMessage("فرمت ایمیل صحیح نیست");
			RuleFor(p => p.Mobile).NotNull().WithMessage("موبایل را وارد کنید");
		
		}
	}
}
