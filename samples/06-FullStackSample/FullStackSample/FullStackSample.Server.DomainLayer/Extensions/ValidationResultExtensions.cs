using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace FullStackSample.Server.DomainLayer.Extensions
{
	public static class ValidationResultExtensions
	{
		public static IEnumerable<KeyValuePair<string, string>> ToResponseErrors(
			this ValidationResult validationResult) =>
				validationResult
				.Errors
				.Select(x => new KeyValuePair<string, string>(x.PropertyName, x.ErrorMessage));
	}
}
