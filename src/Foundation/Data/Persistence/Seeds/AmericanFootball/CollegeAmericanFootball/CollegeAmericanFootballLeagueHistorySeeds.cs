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