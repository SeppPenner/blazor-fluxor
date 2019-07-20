namespace FullStackSample.Client.Store
{
	public class PropertyUpdate<T>
	{
		public readonly bool Updated;
		private readonly T Value;

		public static implicit operator PropertyUpdate<T>(T value) => new PropertyUpdate<T>(value);
		public T GetValueOrDefault(T @default) => Updated ? Value : @default;

		public PropertyUpdate(T value)
		{
			Updated = true;
			Value = value;
		}
	}
}
