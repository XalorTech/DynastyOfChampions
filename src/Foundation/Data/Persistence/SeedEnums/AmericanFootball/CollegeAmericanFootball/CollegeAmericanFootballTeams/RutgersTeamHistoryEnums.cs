namespace DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball.CollegeAmericanFootball.CollegeAmericanFootballTeams
{
	/// <summary>
	/// Enum Ids for the different historical changes to the Rutgers team within the College American Football league.
	/// </summary>
	/// Guid rules are as follows:
	/// - The first two bytes represent the system, in this case, Sports (01).
	/// - The next two bytes represent the sport, in this case, American Football (01).
	/// - The next two bytes represent the league, in this case, College American Football (01).
	/// - The next two bytes represent whether the record is a league history (01), a league unit (02), or a team (03).
	/// - For Teams, the next four bytes represent the team itself, such as Rutgers (0002).
	/// - The remaining bytes are used for versioning.
	public enum RutgersTeamHistoryEnums : ulong
	{
		RutgersCollege = 0x0101010300020001
	}

	/// <summary>
	/// Extension methods for the RutgersTeamHistoryEnums.
	/// </summary>
	public static class RutgersTeamHistoryEnumExtensions
	{
		/// <summary>
		/// Converts the RutgersTeamHistoryEnums value to a Guid.
		/// </summary>
		public static Guid ToGuid(this RutgersTeamHistoryEnums value)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((ulong)value).CopyTo(bytes, 0);
			return new Guid(bytes);
		}
	}
}