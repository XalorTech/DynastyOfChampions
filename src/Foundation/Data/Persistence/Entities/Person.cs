using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a real-world person who may serve in one or more roles
	/// within the sports domain (e.g., player, coach).
	/// </summary>
	public class Person
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this person.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The date on which this person was born, if known.
		/// </summary>
		public DateTime? BirthDate { get; set; }

		/// <summary>
		/// The date on which this person died, if applicable.
		/// </summary>
		public DateTime? DeathDate { get; set; }

		/// <summary>
		/// The city in which this person was born, if known.
		/// </summary>
		public string? BirthCity { get; set; }

		/// <summary>
		/// The region, state, or province in which this person was born, if known.
		/// </summary>
		public string? BirthRegion { get; set; }

		/// <summary>
		/// The country in which this person was born, if known.
		/// </summary>
		public string? BirthCountry { get; set; }

		/// <summary>
		/// The city in which this person died, if applicable.
		/// </summary>
		public string? DeathCity { get; set; }

		/// <summary>
		/// The region, state, or province in which this person died, if applicable.
		/// </summary>
		public string? DeathRegion { get; set; }

		/// <summary>
		/// The country in which this person died, if applicable.
		/// </summary>
		public string? DeathCountry { get; set; }

		/// <summary>
		/// The currently active nickname for this person, if any.
		/// </summary>
		public string? ActiveNickname { get; set; }

		/// <summary>
		/// The current display name for this person, which may differ from their legal name.
		/// </summary>
		public string? DisplayName { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the collection of historical identity records for this person.
		/// </summary>
		public ICollection<PersonHistory> History { get; set; } = new List<PersonHistory>();

		/// <summary>
		/// Navigation to the collection of player roles associated with this person.
		/// </summary>
		public ICollection<Player> PlayerRoles { get; set; } = new List<Player>();

		/// <summary>
		/// Navigation to the collection of coach roles associated with this person.
		/// </summary>
		public ICollection<Coach> CoachRoles { get; set; } = new List<Coach>();

		/// <summary>
		/// Navigation to the collection of career phases associated with this person.
		/// </summary>
		public ICollection<CareerPhase> CareerPhases { get; set; } = new List<CareerPhase>();

		#endregion
	}
}