using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a league-specific coaching role such as "Head Coach",
	/// "Offensive Coordinator", or "Defensive Backs Coach".
	/// </summary>
	public class CoachType
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the coach type.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The human-readable name of the coach type.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// The short code used to represent the coach type.
		/// </summary>
		public string Abbreviation { get; set; } = null!;

		/// <summary>
		/// Optional descriptive text providing additional context about the coach type.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// A value used to control the display order of coach types in UIs.
		/// </summary>
		public int SortOrder { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the league this coach type belongs to.
		/// </summary>
		public Guid LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the league associated with this coach type.
		/// </summary>
		public League League { get; set; } = null!;

		/// <summary>
		/// Navigation to the collection of roster coach assignments referencing this type.
		/// </summary>
		public ICollection<RosterCoachType> RosterCoachTypes { get; set; } = new List<RosterCoachType>();

		#endregion
	}
}