namespace DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball.CollegeAmericanFootball
{
	/// <summary>
	/// Enum Ids for the league units within the College American Football league.
	/// </summary>
	/// <remarks>
	/// Guid rules are as follows:
	/// - The first two bytes represent the system, in this case, Sports (01).
	/// - The next two bytes represent the sport, in this case, American Football (01).
	/// - The next two bytes represent the league, in this case, College American Football (01).
	/// - The next two bytes represent whether the record is a league history (01), a league unit (02), or a team (03).
	/// - For League Units, the next four bytes represent the league unit itself, such as the Independent Conference (0001).
	/// - The remaining bytes are used for versioning and other purposes pertaining to the particular league unit we identify here.
	/// </remarks>
	public enum CollegeAmericanFootballLeagueUnitEnums : ulong
	{
		IndependentConference = 0x0101010200010000
	}

	/// <summary>
	/// Extension methods for the CollegeAmericanFootballLeagueUnitEnums.
	/// </summary>
	public static class CollegeAmericanFootballLeagueUnitEnumExtensions
	{
		/// <summary>
		/// Converts the CollegeAmericanFootballLeagueUnitEnums value to a Guid.
		/// </summary>
		public static Guid ToGuid(this CollegeAmericanFootballLeagueUnitEnums value)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((ulong)value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}
	}
}