using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a type of role a person can hold within the sports domain,
	/// such as Player or Coach. Can optionally be scoped to a specific sport
	/// and/or league.
	/// </summary>
	public class RoleType
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this role type.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The human-readable name of the role type (e.g., "Player", "Coach").
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// Optional descriptive text providing additional context about the role type.
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// A value used to control the display order of role types in UIs.
		/// </summary>
		public int SortOrder { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the sport this role type is associated with, if any.
		/// </summary>
		public Guid? SportId { get; set; }

		/// <summary>
		/// The identifier of the league this role type is associated with, if any.
		/// </summary>
		public Guid? LeagueId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the sport associated with this role type, if any.
		/// </summary>
		public Sport? Sport { get; set; }

		/// <summary>
		/// Navigation to the league associated with this role type, if any.
		/// </summary>
		public League? League { get; set; }

		/// <summary>
		/// Navigation to the collection of career phases that reference this role type.
		/// </summary>
		public ICollection<CareerPhase> CareerPhases { get; set; } = new List<CareerPhase>();

		#endregion
	}
}