using Blazor.Fluxor;

namespace FullStackSample.Client.Store.Main
{
	public class MainFeature : Feature<MainState>
	{
		public override string GetName() => "Main";
		protected override MainState GetInitialState() => MainState.CreateDefaultState();
	}
}
