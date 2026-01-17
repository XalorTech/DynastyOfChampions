using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a player's time-variant identity attributes,
	/// including names, nickname, and suffix during a specific period.
	/// </summary>
	public class PlayerHistory
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this historical record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The player's given names during this period (may include multiple names).
		/// </summary>
		public string GivenNames { get; set; } = null!;

		/// <summary>
		/// The player's surname during this period.
		/// </summary>
		public string Surname { get; set; } = null!;

		/// <summary>
		/// Optional suffix associated with the player's name (e.g., "Jr.", "III").
		/// </summary>
		public string? Suffix { get; set; }

		/// <summary>
		/// Optional nickname used during this period (e.g., "Hollywood", "Megatron").
		/// </summary>
		public string? Nickname { get; set; }

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
		/// Navigation to the player associated with this historical record.
		/// </summary>
		public Player Player { get; set; } = null!;

		#endregion
	}
}