using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a league-specific roster status such as "IR", "PUP", "Suspended",
	/// or "Loaned". Statuses are temporary conditions applied to a player's roster
	/// assignment rather than to the player directly.
	/// </summary>
	public class Status
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the status.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The human-readable name of the status (e.g., "Injured Reserve").
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// The short code used to represent the status (e.g., "IR", "PUP").
		/// </summary>
		public string Abbreviation { get; set; } = null!;

		/// <summary>
		/// Optional descriptive text providing additional context about the status.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// A value used to control the display order of statuses in UIs.
		/// </summary>
		public int SortOrder { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the league this status belongs to.
		/// </summary>
		public Guid LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the league associated with this status.
		/// </summary>
		public League League { get; set; } = null!;

		#endregion
	}
}