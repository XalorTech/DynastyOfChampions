using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents the assignment of a specific position to a roster player entry.
	/// Supports multiple positions per roster assignment.
	/// </summary>
	public class RosterPlayerPosition
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this roster player position assignment.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the roster player associated with this position assignment.
		/// </summary>
		public Guid RosterPlayerId { get; set; }

		/// <summary>
		/// The identifier of the position assigned to this roster player.
		/// </summary>
		public Guid PositionId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the roster player associated with this position assignment.
		/// </summary>
		public RosterPlayer RosterPlayer { get; set; } = null!;

		/// <summary>
		/// Navigation to the position assigned to this roster player.
		/// </summary>
		public Position Position { get; set; } = null!;

		#endregion
	}
}