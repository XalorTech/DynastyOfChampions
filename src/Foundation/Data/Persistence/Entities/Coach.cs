using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a coach's role within a specific league.
	/// A single person may have multiple coach roles across different leagues.
	/// </summary>
	public class Coach
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this coach role.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the person associated with this coach role.
		/// </summary>
		public Guid PersonId { get; set; }

		/// <summary>
		/// The identifier of the league this coach role is associated with.
		/// </summary>
		public Guid LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the person associated with this coach role.
		/// </summary>
		public Person Person { get; set; } = null!;

		/// <summary>
		/// Navigation to the league associated with this coach role.
		/// </summary>
		public League League { get; set; } = null!;

		/// <summary>
		/// Navigation to the collection of roster assignments for this coach.
		/// </summary>
		public ICollection<RosterCoach> RosterCoaches { get; set; } = new List<RosterCoach>();

		#endregion
	}
}