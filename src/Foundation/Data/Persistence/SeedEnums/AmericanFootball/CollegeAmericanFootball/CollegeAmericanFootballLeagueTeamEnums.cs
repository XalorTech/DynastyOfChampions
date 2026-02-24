namespace DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball.CollegeAmericanFootball
{
	/// <summary>
	/// Enum Ids for the teams within the College American Football league.
	/// </summary>
	/// <remarks>
	/// Guid rules are as follows:
	/// - The first two bytes represent the system, in this case, Sports (01).
	/// - The next two bytes represent the sport, in this case, American Football (01).
	/// - The next two bytes represent the league, in this case, College American Football (01).
	/// - The next two bytes represent whether the record is a league history (01), a league unit (02), or a team (03).
	/// - For Teams, the next four bytes represent the team itself, such as Princeton (0001).
	/// - The remaining bytes are used for versioning and other purposes pertaining to the particular league unit we identify here.
	/// </remarks>
	public enum CollegeAmericanFootballLeagueTeamEnums : ulong
	{
		Princeton = 0x0101010300010000,
		Rutgers = 0x0101010300020000
	}

	/// <summary>
	/// Extension methods for the CollegeAmericanFootballLeagueTeamEnums.
	/// </summary>
	public static class CollegeAmericanFootballLeagueTeamEnumExtensions
	{
		/// <summary>
		/// Converts the CollegeAmericanFootballLeagueTeamEnums value to a Guid.
		/// </summary>
		public static Guid ToGuid(this CollegeAmericanFootballLeagueTeamEnums value)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((ulong)value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}
	}
}