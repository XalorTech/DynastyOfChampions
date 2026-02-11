namespace DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball
{
	/// <summary>
	/// Enum Ids for the different American Football leagues.
	/// </summary>
	/// <remarks>
	/// Guid rules are as follows:
	/// - The first two bytes represent the system, in this case, Sports (01).
	/// - The next two bytes represent the sport, in this case, American Football (01).
	/// - The next two bytes represent the league (e.g., College).
	/// - The remaining bytes are used for versioning and other purposes pertaining to the particular league we identify here.
	/// </remarks>
	public enum AmericanFootballLeagueEnums : ulong
	{
		CollegeAmericanFootball = 0x0101010000000000
	}

	/// <summary>
	/// Extension methods for the AmericanFootballLeagueEnums.
	/// </summary>
	public static class AmericanFootballLeagueEnumExtensions
	{
		/// <summary>
		/// Converts the AmericanFootballLeagueEnums value to a Guid.
		/// </summary>
		public static Guid ToGuid(this AmericanFootballLeagueEnums value)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((ulong)value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}
	}
}