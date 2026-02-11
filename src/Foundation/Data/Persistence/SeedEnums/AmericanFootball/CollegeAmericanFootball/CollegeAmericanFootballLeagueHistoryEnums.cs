namespace DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball
{
	/// <summary>
	/// Enum Ids for the different historical changes to the College American Football league.
	/// </summary>
	/// <remarks>
	/// Guid rules are as follows:
	/// - The first two bytes represent the system, in this case, Sports (01).
	/// - The next two bytes represent the sport, in this case, American Football (01).
	/// - The next two bytes represent the league, in this case, College American Football (01).
	/// - The next two bytes represent whether the record is a league history (01), a league unit (02), or a team (03).
	/// - The remaining bytes are used for versioning and other purposes pertaining to the particular league we identify here.
	/// </remarks>
	public enum CollegeAmericanFootballLeagueHistoryEnums : ulong
	{
		PreRegulation = 0x0101010100000000
	}

	/// <summary>
	/// Extension methods for the CollegeAmericanFootballLeagueHistoryEnums.
	/// </summary>
	public static class CollegeAmericanFootballLeagueHistoryEnumExtensions
	{
		/// <summary>
		/// Converts the CollegeAmericanFootballLeagueHistoryEnums value to a Guid.
		/// </summary>
		public static Guid ToGuid(this CollegeAmericanFootballLeagueHistoryEnums value)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((ulong)value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}
	}
}