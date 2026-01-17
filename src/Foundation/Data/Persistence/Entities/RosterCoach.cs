using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a coach's membership within a roster, including role types and
	/// the time period during which the coach was part of the roster.
	/// </summary>
	public class RosterCoach
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this roster coach entry.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The date on which this roster assignment became effective.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The date on which this roster assignment ended, if applicable.
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Optional freeform notes associated with this roster assignment.
		/// </summary>
		public string? Notes { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the roster to which this entry belongs.
		/// </summary>
		public Guid RosterId { get; set; }

		/// <summary>
		/// The identifier of the coach associated with this roster entry.
		/// </summary>
		public Guid CoachId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the roster associated with this entry.
		/// </summary>
		public Roster Roster { get; set; } = null!;

		/// <summary>
		/// Navigation to the coach associated with this entry.
		/// </summary>
		public Coach Coach { get; set; } = null!;

		/// <summary>
		/// Navigation to the collection of coach types assigned to this roster coach.
		/// </summary>
		public ICollection<RosterCoachType> CoachTypes { get; set; } = new List<RosterCoachType>();

		#endregion
	}
}