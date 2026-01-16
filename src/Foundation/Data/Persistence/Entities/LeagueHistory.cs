using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a league's time-variant attributes,
	/// such as name, abbreviation, and description.
	/// </summary>
	public class LeagueHistory
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this historical record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The human-readable name of the league during this period.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// The abbreviation used by the league during this period.
		/// </summary>
		public string Abbreviation { get; set; } = null!;

		/// <summary>
		/// Optional descriptive text associated with the league during this period.
		/// </summary>
		public string? Description { get; set; }

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
		/// The identifier of the league to which this historical record belongs.
		/// </summary>
		public Guid LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The league associated with this historical record.
		/// </summary>
		public League League { get; set; } = null!;

		#endregion
	}
}