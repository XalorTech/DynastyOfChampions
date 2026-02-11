using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds.AmericanFootball
{
	/// <summary>
	/// Seeds all American Football leagues into the database.
	/// </summary>
	public static class AmericanFootballLeagueSeeds
	{
		public static void Seed(DynastyDbContext db)
		{
			SeedLeague(db, AmericanFootballLeagueEnums.CollegeAmericanFootball, SportEnums.AmericanFootball);

			db.SaveChanges();
		}

		private static void SeedLeague(DynastyDbContext db, AmericanFootballLeagueEnums leagueEnum, SportEnums sportEnum)
		{
			var id = leagueEnum.ToGuid();
			var sportId = sportEnum.ToGuid();

			if (db.Leagues.Any(l => l.Id == id))
				return;

			db.Leagues.Add(new League
			{
				Id = id,
				SportId = sportId
			});
		}
	}
}