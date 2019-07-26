namespace FullStackSample.Server.DomainLayer.Services
{
	public class UnitOfWorkResult
	{
		public string ErrorMessage { get; private set; }
		public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
		public bool Successful => !HasError;

		public static readonly UnitOfWorkResult Success;

		static UnitOfWorkResult()
		{
			Success = new UnitOfWorkResult();
		}

		public UnitOfWorkResult() { }

		public UnitOfWorkResult(string errorMessage) : this()
		{
			ErrorMessage = errorMessage;
		}
	}
}
