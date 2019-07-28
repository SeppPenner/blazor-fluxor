namespace FullStackSample.Client.Store.Main
{
	public class NotifyUnexpectedServerErrorStatusChanged
	{
		public bool HasUnexpectedServerError { get; private set; }

		public NotifyUnexpectedServerErrorStatusChanged(bool hasUnexpectedServerError)
		{
			HasUnexpectedServerError = hasUnexpectedServerError;
		}
	}
}
