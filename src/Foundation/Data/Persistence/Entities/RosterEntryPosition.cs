using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents the assignment of a specific position to a roster entry.
	/// Supports multiple positions per roster assignment, enabling league- and
	/// season-specific roles for a player.
	/// </summary>
	public class RosterEntryPosition
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this roster entry position assignment.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the roster entry associated with this position assignment.
		/// </summary>
		public Guid RosterEntryId { get; set; }

		/// <summary>
		/// The identifier of the position assigned to this roster entry.
		/// </summary>
		public Guid PositionId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the roster entry associated with this position assignment.
		/// </summary>
		public RosterEntry RosterEntry { get; set; } = null!;

		/// <summary>
		/// Navigation to the position assigned to this roster entry.
		/// </summary>
		public Position Position { get; set; } = null!;

		#endregion
	}
}