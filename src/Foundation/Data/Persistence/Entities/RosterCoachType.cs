using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents the assignment of a specific coach type to a roster coach entry.
	/// Supports multiple roles per roster assignment (e.g., co-coordinators).
	/// </summary>
	public class RosterCoachType
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this roster coach type assignment.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the roster coach associated with this type assignment.
		/// </summary>
		public Guid RosterCoachId { get; set; }

		/// <summary>
		/// The identifier of the coach type assigned to this roster coach.
		/// </summary>
		public Guid CoachTypeId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the roster coach associated with this type assignment.
		/// </summary>
		public RosterCoach RosterCoach { get; set; } = null!;

		/// <summary>
		/// Navigation to the coach type assigned to this roster coach.
		/// </summary>
		public CoachType CoachType { get; set; } = null!;

		#endregion
	}
}