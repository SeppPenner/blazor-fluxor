using Blazor.Fluxor;

namespace FullStackSample.Client.Store.Main
{
	public class NotifyUnexpectedServerErrorStatusChangedReducer : Reducer<MainState, NotifyUnexpectedServerErrorStatusChanged>
	{
		public override MainState Reduce(MainState state, NotifyUnexpectedServerErrorStatusChanged action)
			=> state.WithUnexpectedError(action.HasUnexpectedServerError);
	}
}
