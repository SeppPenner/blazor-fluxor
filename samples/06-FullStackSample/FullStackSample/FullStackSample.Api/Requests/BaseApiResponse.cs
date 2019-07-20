namespace FullStackSample.Api.Requests
{
	public class BaseApiResponse
	{
		public string ErrorMessage { get; private set; }
		public bool HasErrors => !string.IsNullOrEmpty(ErrorMessage);

		public BaseApiResponse() { }

		public BaseApiResponse(string errorMessage)
		{
			ErrorMessage = errorMessage;
		}
	}
}
