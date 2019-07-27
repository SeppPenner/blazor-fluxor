using System;
using System.Collections.Generic;
using System.Linq;

namespace FullStackSample.Api.Requests
{
	public class ApiResponse
	{
		public string ErrorMessage { get; private set; }
		public bool HasErrors => !string.IsNullOrEmpty(ErrorMessage) || ValidationErrors.Any();
		public bool IsValid => !HasErrors;
		public bool Successful => !HasErrors;
		public IEnumerable<KeyValuePair<string, string>> ValidationErrors { get; private set; }

		public ApiResponse()
		{
			ValidationErrors = Array.Empty<KeyValuePair<string, string>>();
		}

		public ApiResponse(
			string errorMessage,
			IEnumerable<KeyValuePair<string, string>> validationErrors)
			: this()
		{
			ErrorMessage = errorMessage;
			ValidationErrors = validationErrors ?? Array.Empty<KeyValuePair<string, string>>();
		}
	}
}
