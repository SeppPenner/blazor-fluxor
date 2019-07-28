using Blazor.Fluxor;

namespace FullStackSample.Client.Store.Main
{
	public class NotifyBusyStartReducer : Reducer<MainState, NotifyBusyStart>
	{
		public override MainState Reduce(MainState state, NotifyBusyStart action)
			=> state.WithIncrementedBusyCount();
	}
}
