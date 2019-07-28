namespace FullStackSample.Client.Store.Main
{
	public class MainState
	{
		public bool HasUnexpectedServerError { get; private set; }
		public bool IsBusy => BusyCount > 0;
		private int BusyCount;

		public static MainState CreateDefaultState()
			=> new MainState(
				hasUnexpectedServerError: false,
				busyCount: 0);

		public MainState WithIncrementedBusyCount()
			=> new MainState(
				hasUnexpectedServerError: HasUnexpectedServerError,
				busyCount: BusyCount + 1);

		public MainState WithDecrementedBusyCount()
			=> new MainState(
				hasUnexpectedServerError: HasUnexpectedServerError,
				busyCount: BusyCount - 1);

		public MainState WithUnexpectedError(bool hasUnexpectedError)
			=> new MainState(
				hasUnexpectedServerError: hasUnexpectedError,
				busyCount: BusyCount);


		private MainState(bool hasUnexpectedServerError, int busyCount)
		{
			HasUnexpectedServerError = hasUnexpectedServerError;
			BusyCount = busyCount;
		}
	}
}
