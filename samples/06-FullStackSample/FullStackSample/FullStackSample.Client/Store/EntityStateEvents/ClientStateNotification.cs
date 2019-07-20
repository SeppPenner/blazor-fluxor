
using Blazor.Fluxor;

namespace FullStackSample.Client.Store.EntityStateEvents
{
	public class ClientStateNotification : IAction
	{
		public int Id { get; set; }
		public PropertyUpdate<string> Name { get; set; }

		public ClientStateNotification(int id, PropertyUpdate<string> name)
		{
			Id = id;
			Name = name;
		}
	}
}
