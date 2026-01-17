using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a team's time-variant attributes,
	/// including name, abbreviation, and structured geographic location.
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
		/// The city associated with the team during this period.
		/// </summary>
		public string? City { get; set; }

		/// <summary>
		/// The region, state, or province associated with the team during this period.
		/// </summary>
		public string? Region { get; set; }

		/// <summary>
		/// The country associated with the team during this period.
		/// </summary>
		public string? Country { get; set; }

		/// <summary>
		/// A display-friendly location string (e.g., "Dallas", "Manchester").
		/// </summary>
		public string? DisplayLocation { get; set; }

		/// <summary>
		/// A short location code used for scoreboards or abbreviations (e.g., "DAL", "MUN").
		/// </summary>
		public string? ShortLocation { get; set; }

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
		/// Navigation to the team associated with this historical record.
		/// </summary>
		public Team Team { get; set; } = null!;

		#endregion
	}
}