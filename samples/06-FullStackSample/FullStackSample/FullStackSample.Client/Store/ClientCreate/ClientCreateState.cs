namespace FullStackSample.Client.Store.ClientCreate
{
	public class ClientCreateState
	{
		public bool IsExecutingApi { get; private set; }
		public string ErrorMessage { get; }

		public ClientCreateState(bool isExecutingApi, string errorMessage)
		{
			IsExecutingApi = isExecutingApi;
			ErrorMessage = errorMessage;
		}
	}
}
