namespace FullStackSample.Client.Store.EntityStateEvents
{
	public class ClientStateNotification
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
