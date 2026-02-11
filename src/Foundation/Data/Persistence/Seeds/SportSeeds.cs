using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds
{
	/// <summary>
	/// Seeds all canonical sports into the database.
	/// </summary>
	public static class SportSeeds
	{
		public static void Seed(DynastyDbContext db)
		{
			SeedSport(db, SportEnums.AmericanFootball,
				"American Football",
				"A highly popular team sport that combines elements of strategy, athleticism, and physicality. It is played between two teams, each consisting of eleven players, on a rectangular field. The objective of the game is to score points by advancing the ball into the opponent’s end zone or kicking it through the goalposts.");

			db.SaveChanges();
		}

		private static void SeedSport(DynastyDbContext db, SportEnums sportEnum, string name, string description)
		{
			var id = sportEnum.ToGuid();

			if (db.Sports.Any(s => s.Id == id))
				return;

			db.Sports.Add(new Sport
			{
				Id = id,
				Name = name,
				Description = description
			});
		}
	}
}