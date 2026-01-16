using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a team's time-variant attributes,
	/// such as name, abbreviation, and geographic location.
	/// </summary>
	public class TeamHistory
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this historical record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The name of the team during this period.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// The abbreviation used by the team during this period.
		/// </summary>
		public string Abbreviation { get; set; } = null!;

		/// <summary>
		/// The geographic location or city associated with the team during this period.
		/// </summary>
		public string Location { get; set; } = null!;

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
		/// The identifier of the team to which this historical record belongs.
		/// </summary>
		public Guid TeamId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The team associated with this historical record.
		/// </summary>
		public Team Team { get; set; } = null!;

		#endregion
	}
}