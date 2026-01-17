using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a player's membership within a roster. Tracks jersey number,
	/// status, positions, and the time period during which the player was part
	/// of the roster.
	/// </summary>
	public class RosterEntry
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this roster entry.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The jersey number worn by the player during this roster assignment.
		/// </summary>
		public int? JerseyNumber { get; set; }

		/// <summary>
		/// Optional freeform notes associated with this roster assignment.
		/// </summary>
		public string? Notes { get; set; }

		/// <summary>
		/// The date on which this roster assignment became effective.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The date on which this roster assignment ended, if applicable.
		/// </summary>
		public DateTime? EndDate { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the roster to which this entry belongs.
		/// </summary>
		public Guid RosterId { get; set; }

		/// <summary>
		/// The identifier of the player associated with this roster entry.
		/// </summary>
		public Guid PlayerId { get; set; }

		/// <summary>
		/// The identifier of the status applied to this roster entry, if any.
		/// </summary>
		public Guid? StatusId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the roster associated with this entry.
		/// </summary>
		public Roster Roster { get; set; } = null!;

		/// <summary>
		/// Navigation to the player associated with this entry.
		/// </summary>
		public Player Player { get; set; } = null!;

		/// <summary>
		/// Navigation to the status applied to this roster entry, if any.
		/// </summary>
		public Status? Status { get; set; }

		/// <summary>
		/// Navigation to the collection of positions assigned to this roster entry.
		/// </summary>
		public ICollection<RosterEntryPosition> Positions { get; set; } = new List<RosterEntryPosition>();

		#endregion
	}
}