namespace DynastyOfChampions.Foundation.Data.Persistence.SeedEnums
{
	/// <summary>
	/// Enum Ids for the different sports in the system.
	/// </summary>
	/// <remarks>
	/// Guid rules are as follows:
	/// - The first two bytes represent the system, in this case, Sports (01).
	/// - The next two bytes represent the specific sport (e.g., American Football).
	/// - The remaining bytes are used for versioning and other purposes pertaining to the particular sport we identify here.
	/// </remarks>
	public enum SportEnums : ulong
	{
		AmericanFootball = 0x0101000000000000
	}

	/// <summary>
	/// Extension methods for the SportEnums.
	/// </summary>
	public static class SportEnumExtensions
	{
		/// <summary>
		/// Converts the SportEnums value to a Guid.
		/// </summary>
		public static Guid ToGuid(this SportEnums value)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((ulong)value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}
	}
}