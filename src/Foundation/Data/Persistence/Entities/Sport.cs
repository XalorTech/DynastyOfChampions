using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a sport within the Dynasty of Champions platform.
	/// A sport is the highest-level organizational concept and serves
	/// as the parent for one or more leagues (e.g., NFL for Football,
	/// NBA for Basketball, Premier League for Soccer).
	/// </summary>
	public class Sport
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the sport.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The human-readable name of the sport (e.g., "Football", "Basketball").
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// An optional description providing additional context or details
		/// about the sport. Useful for administrative interfaces or documentation.
		/// </summary>
		public string? Description { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The collection of leagues associated with this sport.
		/// Each sport may contain multiple leagues (e.g., NFL, NCAA Football).
		/// </summary>
		public ICollection<League> Leagues { get; set; } = new List<League>();

		/// <summary>
		/// The collection of role types associated with this sport.
		/// Each sport may contain multiple role types (e.g., Player, Coach).
		/// </summary>
		public ICollection<RoleType> RoleTypes { get; set; } = new List<RoleType>();

		/// <summary>
		/// The collection of career phases associated with this sport.
		/// Each sport may contain multiple career phases (e.g., Rookie, Veteran).
		/// </summary>
		public ICollection<CareerPhase> CareerPhases { get; set; } = new List<CareerPhase>();

		#endregion
	}
}