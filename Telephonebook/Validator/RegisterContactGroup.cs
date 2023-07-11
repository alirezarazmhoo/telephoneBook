using FluentValidation;
using static Telephonebook.Features.ContactPersonGroup.AddContactGroup;

namespace Telephonebook.Validator
{
	public class RegisterContactGroup : AbstractValidator<ContactGroupCommand>
	{
		public RegisterContactGroup() {
			RuleFor(p => p.Name).NotEmpty().WithMessage("نام گروه را وارد کنید ").MinimumLength(5).WithMessage("تعداد کاراکتر ها کم است");

		}

	}
}
