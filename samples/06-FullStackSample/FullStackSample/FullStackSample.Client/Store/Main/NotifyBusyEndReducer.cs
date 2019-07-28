using Blazor.Fluxor;

namespace FullStackSample.Client.Store.Main
{
	public class NotifyBusyEndReducer : Reducer<MainState, NotifyBusyEnd>
	{
		public override MainState Reduce(MainState state, NotifyBusyEnd action)
			=> state.WithDecrementedBusyCount();
	}
}
