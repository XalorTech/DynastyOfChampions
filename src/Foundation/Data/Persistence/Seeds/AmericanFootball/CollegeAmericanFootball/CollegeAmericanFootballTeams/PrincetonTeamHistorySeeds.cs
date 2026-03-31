using DynastyOfChampions.Foundation.Data.Persistence.Context;
using DynastyOfChampions.Foundation.Data.Persistence.Entities;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball.CollegeAmericanFootball;
using DynastyOfChampions.Foundation.Data.Persistence.SeedEnums.AmericanFootball.CollegeAmericanFootball.CollegeAmericanFootballTeams;

namespace DynastyOfChampions.Foundation.Data.Persistence.Seeds.AmericanFootball.CollegeAmericanFootball.CollegeAmericanFootballTeams
{
    /// <summary>
    /// Seeds all Princeton team history data into the database.
    /// </summary>
    public static class PrincetonTeamHistorySeeds
    {
        public static void Seed(DynastyDbContext db)
        {
            SeedTeamHistory(db,
                PrincetonTeamHistoryEnums.TheCollegeOfNewJersey,
                CollegeAmericanFootballTeamEnums.Princeton,
                AmericanFootballLeagueEnums.CollegeAmericanFootball,
                CollegeAmericanFootballLeagueUnitEnums.IndependentConference,
                "Princeton Tigers", "PRN", "The College of New Jersey",
                "Princeton", "New Jersey", "USA",
                new DateTime(1869, 11, 6), new DateTime(1880, 12, 31));
        }

        public static void SeedTeamHistory(DynastyDbContext db,
            PrincetonTeamHistoryEnums teamHistoryEnum,
            CollegeAmericanFootballTeamEnums teamEnum,
            AmericanFootballLeagueEnums leagueEnum,
            CollegeAmericanFootballLeagueUnitEnums leagueUnitEnum,
            string name, string abbreviation, string? organization,
            string? city, string? region, string? country,
            DateTime startDate, DateTime? endDate)
        {
            var id = teamHistoryEnum.ToGuid();
            var teamId = teamEnum.ToGuid();
            var leagueId = leagueEnum.ToGuid();
            var leagueUnitId = leagueUnitEnum.ToGuid();

            if (db.TeamHistories.Any(th => th.Id == id))
                return;
            
            db.TeamHistories.Add(new TeamHistory
            {
                Id = id,
                TeamId = teamId,
                LeagueId = leagueId,
                LeagueUnitId = leagueUnitId,
                Name = name,
                Abbreviation = abbreviation,
                Organization = organization,
                City = city,
                Region = region,
                Country = country,
                StartDate = startDate,
                EndDate = endDate
            });
        }
    }
}