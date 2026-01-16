using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a player's time-variant attributes,
	/// such as jersey number, position, or name changes.
	/// </summary>
	public class PlayerHistory
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this historical record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The player's first name during this period.
		/// </summary>
		public string FirstName { get; set; } = null!;

		/// <summary>
		/// The player's last name during this period.
		/// </summary>
		public string LastName { get; set; } = null!;

		/// <summary>
		/// The player's primary position during this period.
		/// </summary>
		public string? Position { get; set; }

		/// <summary>
		/// The jersey number worn by the player during this period.
		/// </summary>
		public int? JerseyNumber { get; set; }

		/// <summary>
		/// The date on which this historical record became effective.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The date on which this historical record ended, if applicable.
		/// </summary>
		public DateTime? EndDate { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the player to which this historical record belongs.
		/// </summary>
		public Guid PlayerId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The player associated with this historical record.
		/// </summary>
		public Player Player { get; set; } = null!;

		#endregion
	}
}