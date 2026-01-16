using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a league unit's attributes and structural
	/// hierarchy, including name, display label, parent relationship, and depth level.
	/// </summary>
	public class LeagueUnitHistory
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this historical record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The name of the league unit during this period.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// Optional display label describing the type of this unit.
		/// </summary>
		public string? DisplayLabel { get; set; }

		/// <summary>
		/// The depth level of this unit within the hierarchy during this period.
		/// </summary>
		public int Level { get; set; }

		/// <summary>
		/// The identifier of the parent unit during this period, if applicable.
		/// </summary>
		public Guid? ParentId { get; set; }

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
		/// The identifier of the league unit to which this historical record belongs.
		/// </summary>
		public Guid LeagueUnitId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The league unit associated with this historical record.
		/// </summary>
		public LeagueUnit LeagueUnit { get; set; } = null!;

		#endregion
	}
}