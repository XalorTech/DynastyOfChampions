using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a continuous period during which a person is active in a specific
	/// role, league, and sport. Supports retirement, un-retirement, and multi-role,
	/// multi-league, multi-sport careers.
	/// </summary>
	public class CareerPhase
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this career phase.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The date on which this career phase began.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// The date on which this career phase ended, if applicable.
		/// </summary>
		public DateTime? EndDate { get; set; }

		/// <summary>
		/// Optional description of why this career phase ended.
		/// </summary>
		public string? EndReason { get; set; }

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the person associated with this career phase.
		/// </summary>
		public Guid PersonId { get; set; }

		/// <summary>
		/// The identifier of the role type associated with this career phase.
		/// </summary>
		public Guid RoleTypeId { get; set; }

		/// <summary>
		/// The identifier of the league associated with this career phase.
		/// </summary>
		public Guid LeagueId { get; set; }

		/// <summary>
		/// The identifier of the sport associated with this career phase.
		/// </summary>
		public Guid SportId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the person associated with this career phase.
		/// </summary>
		public Person Person { get; set; } = null!;

		/// <summary>
		/// Navigation to the role type associated with this career phase.
		/// </summary>
		public RoleType RoleType { get; set; } = null!;

		/// <summary>
		/// Navigation to the league associated with this career phase.
		/// </summary>
		public League League { get; set; } = null!;

		/// <summary>
		/// Navigation to the sport associated with this career phase.
		/// </summary>
		public Sport Sport { get; set; } = null!;

		#endregion
	}
}