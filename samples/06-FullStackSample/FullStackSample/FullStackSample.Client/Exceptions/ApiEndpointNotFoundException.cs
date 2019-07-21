using System;

namespace FullStackSample.Client.Exceptions
{
	public class ApiEndpointNotFoundException : ApiException
	{
		public readonly Type RequestType;

		public ApiEndpointNotFoundException(Type requestType)
			: base($"API endpoint not found for request type {requestType}")
		{
			RequestType = requestType;
		}
	}
}
