using FluentValidation;
using FullStackSample.Api.Models;

namespace FullStackSample.Api.Validators
{
	public class ClientValidator : AbstractValidator<Client>
	{
		public ClientValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage($"{nameof(Client.Name)} required");
		}
	}
}
