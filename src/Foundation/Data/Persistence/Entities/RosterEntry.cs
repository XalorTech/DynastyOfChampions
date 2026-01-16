using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a player's membership within a roster. Roster entries track
	/// historical changes such as trades, signings, releases, and status updates.
	/// Each entry includes effective dates to support accurate historical queries.
	/// </summary>
	public class RosterEntry
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the roster entry.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The date on which the player joined this roster.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The date on which the player left this roster, if applicable.
		/// Null indicates the player is currently active on this roster.
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// The player's status during this roster assignment
		/// (e.g., "Active", "IR", "Suspended").
		/// </summary>
		public string? Status { get; set; }

		/// <summary>
		/// Optional notes providing additional context about the roster entry.
		/// </summary>
		public string? Notes { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the roster to which this entry belongs.
		/// </summary>
		public Guid RosterId { get; set; }

		/// <summary>
		/// The identifier of the player associated with this entry.
		/// </summary>
		public Guid PlayerId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The roster associated with this entry.
		/// </summary>
		public Roster Roster { get; set; } = null!;

		/// <summary>
		/// The player associated with this entry.
		/// </summary>
		public Player Player { get; set; } = null!;

		#endregion
	}
}