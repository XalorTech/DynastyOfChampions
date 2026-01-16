using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a competitive season within a league (e.g., "2024 Season").
	/// Seasons define the time-bound context for rosters, schedules, and statistics.
	/// </summary>
	public class Season
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the season.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The year associated with the season (e.g., 2024).
		/// </summary>
		public int Year { get; set; }

		/// <summary>
		/// The date on which the season begins.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The date on which the season ends.
		/// </summary>
		public DateTime EndDate { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the league to which this season belongs.
		/// </summary>
		public Guid LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The league associated with this season.
		/// </summary>
		public League League { get; set; } = null!;

		/// <summary>
		/// The collection of rosters associated with this season.
		/// </summary>
		public ICollection<Roster> Rosters { get; set; } = new List<Roster>();

		#endregion
	}
}