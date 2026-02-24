using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds.AmericanFootball.CollegeAmericanFootball
{
	/// <summary>
	/// Seeds all College American Football league history into the database.
	/// </summary>
	public static class CollegeAmericanFootballLeagueHistorySeeds
	{
		public static void Seed(DynastyDbContext db)
		{
			SeedLeagueHistory(db,
				CollegeAmericanFootballLeagueHistoryEnums.PreRegulation,
				AmericanFootballLeagueEnums.CollegeAmericanFootball,
				"Pre-Regulation Era",
				"PreReg",
				"The era of college American football before the establishment of formalized rules and regulations.",
				new DateTime(1869, 11, 6),
				new DateTime(1905, 1, 1));

			SeedLeagueHistory(db,
				CollegeAmericanFootballLeagueHistoryEnums.IntercollegiateAthleticAssociationOfTheUnitedStates,
				AmericanFootballLeagueEnums.CollegeAmericanFootball,
				"Intercollegiate Athletic Association of the United States",
				"IAAUS",
				"The first governing body for college football in the United States.",
				new DateTime(1905, 1, 1),
				new DateTime(1910, 1, 1));

			SeedLeagueHistory(db,
				CollegeAmericanFootballLeagueHistoryEnums.NationalCollegeAthleticAssociation,
				AmericanFootballLeagueEnums.CollegeAmericanFootball,
				"National College Athletic Association",
				"NCAA",
				"The main governing body for college athletics in the United States.",
				new DateTime(1910, 1, 1),
				null);

			db.SaveChanges();
		}

		private static void SeedLeagueHistory(DynastyDbContext db,
			CollegeAmericanFootballLeagueHistoryEnums leagueHistoryEnum,
			AmericanFootballLeagueEnums leagueEnum,
			string name,
			string abbreviation,
			string description,
			DateTime startDate,
			DateTime? endDate)
		{
			var id = leagueHistoryEnum.ToGuid();
			var leagueId = leagueEnum.ToGuid();

			if (db.LeagueHistories.Any(lh => lh.Id == id))
				return;

			db.LeagueHistories.Add(new LeagueHistory
			{
				Id = id,
				LeagueId = leagueId,
				Name = name,
				Abbreviation = abbreviation,
				Description = description,
				StartDate = startDate,
				EndDate = endDate ?? null
			});
		}
	}
}