using FluentValidation;

namespace FullStackSample.Api.Models
{
	public class ClientCreateOrUpdate
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int RegistrationNumber { get; set; }
	}

	public class ClientCreateOrUpdateValidator : AbstractValidator<ClientCreateOrUpdate>
	{
		public ClientCreateOrUpdateValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name required");
			RuleFor(x => x.RegistrationNumber)
				.GreaterThan(0)
				.WithMessage("Registration number must be greater than 0");
		}
	}
}
