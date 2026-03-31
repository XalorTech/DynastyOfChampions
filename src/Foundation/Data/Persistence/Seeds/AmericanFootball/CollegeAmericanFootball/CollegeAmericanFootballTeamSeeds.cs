using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball.CollegeAmericanFootball;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds.AmericanFootball.CollegeAmericanFootball
{
	/// <summary>
	/// Seeds all College American Football teams into the database.
	/// </summary>
	public static class CollegeAmericanFootballTeamSeeds
	{
		public static void Seed(DynastyDbContext db)
		{
			SeedTeam(db,
				CollegeAmericanFootballTeamEnums.Princeton);

			SeedTeam(db,
				CollegeAmericanFootballTeamEnums.Rutgers);

			db.SaveChanges();
		}

		private static void SeedTeam(DynastyDbContext db,
			CollegeAmericanFootballTeamEnums teamEnum)
		{
			var id = teamEnum.ToGuid();

			if (db.Teams.Any(t => t.Id == id))
				return;

			db.Teams.Add(new Team
			{
				Id = id
			});
		}
	}
}