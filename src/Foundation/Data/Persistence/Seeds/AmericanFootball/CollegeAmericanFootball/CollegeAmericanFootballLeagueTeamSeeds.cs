using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds.AmericanFootball.CollegeAmericanFootball
{
	/// <summary>
	/// Seeds all College American Football league teams into the database.
	/// </summary>
	public static class CollegeAmericanFootballLeagueTeamSeeds
	{
		public static void Seed(DynastyDbContext db)
		{
			SeedLeagueTeam(db,
				CollegeAmericanFootballLeagueTeamEnums.Princeton,
				AmericanFootballLeagueEnums.CollegeAmericanFootball);

			SeedLeagueTeam(db,
				CollegeAmericanFootballLeagueTeamEnums.Rutgers,
				AmericanFootballLeagueEnums.CollegeAmericanFootball);

			db.SaveChanges();
		}

		private static void SeedLeagueTeam(DynastyDbContext db,
			CollegeAmericanFootballLeagueTeamEnums leagueTeamEnum,
			AmericanFootballLeagueEnums leagueEnum)
		{
			var id = leagueTeamEnum.ToGuid();
			var leagueId = leagueEnum.ToGuid();

			if (db.LeagueTeams.Any(lt => lt.Id == id))
				return;

			db.LeagueTeams.Add(new LeagueTeam
			{
				Id = id,
				LeagueId = leagueId
			});
		}
	}
}