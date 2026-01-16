using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents an individual athlete. The base model stores only stable identity.
	/// All time-variant attributes such as jersey number or position are stored in
	/// <see cref="PlayerHistory"/>.
	/// </summary>
	public class Player
	{
		#region Properties

		/// <summary>
		/// The unique identifier for the player.
		/// </summary>
		public Guid Id { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Historical records describing time-variant attributes of this player.
		/// </summary>
		public ICollection<PlayerHistory> History { get; set; } = new List<PlayerHistory>();

		/// <summary>
		/// The collection of roster entries representing the player's
		/// historical team memberships.
		/// </summary>
		public ICollection<RosterEntry> RosterEntries { get; set; } = new List<RosterEntry>();

		#endregion
	}
}