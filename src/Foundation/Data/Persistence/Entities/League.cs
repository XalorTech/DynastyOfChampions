using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a league within a specific sport. The base model stores only
	/// stable identity and structural relationships. All time-variant attributes
	/// such as name or abbreviation are stored in <see cref="LeagueHistory"/>.
	/// </summary>
	public class League
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the league.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the sport to which this league belongs.
		/// </summary>
		public Guid SportId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// The parent sport associated with this league.
		/// </summary>
		public Sport Sport { get; set; } = null!;

		/// <summary>
		/// The hierarchical structural units associated with this league.
		/// </summary>
		public ICollection<LeagueUnit> LeagueUnits { get; set; } = new List<LeagueUnit>();

		/// <summary>
		/// The seasons associated with this league.
		/// </summary>
		public ICollection<Season> Seasons { get; set; } = new List<Season>();

		/// <summary>
		/// Historical records describing time-variant attributes of this league.
		/// </summary>
		public ICollection<LeagueHistory> History { get; set; } = new List<LeagueHistory>();

		#endregion
	}
}