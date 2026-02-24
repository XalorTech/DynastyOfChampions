using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds.AmericanFootball.CollegeAmericanFootball
{
	/// <summary>
	/// Seeds all College American Football league units into the database.
	/// </summary>
	public static class CollegeAmericanFootballLeagueUnitSeeds
	{
		public static void Seed(DynastyDbContext db)
		{
			SeedLeagueUnit(db,
				CollegeAmericanFootballLeagueUnitEnums.IndependentConference,
				AmericanFootballLeagueEnums.CollegeAmericanFootball);

			db.SaveChanges();
		}

		private static void SeedLeagueUnit(DynastyDbContext db,
			CollegeAmericanFootballLeagueUnitEnums leagueUnitEnum,
			AmericanFootballLeagueEnums leagueEnum)
		{
			var id = leagueUnitEnum.ToGuid();
			var leagueId = leagueEnum.ToGuid();

			if (db.LeagueUnits.Any(lu => lu.Id == id))
				return;

			db.LeagueUnits.Add(new LeagueUnit
			{
				Id = id,
				LeagueId = leagueId
			});
		}
	}
}