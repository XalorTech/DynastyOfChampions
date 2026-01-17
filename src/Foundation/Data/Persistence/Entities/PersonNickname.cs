using System;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a nickname associated with a specific historical identity record
	/// for a person.
	/// </summary>
	public class PersonNickname
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this nickname record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The nickname value.
		/// </summary>
		public string Nickname { get; set; } = null!;

		#endregion

		#region Foreign Key Properties

		/// <summary>
		/// The identifier of the person history record this nickname belongs to.
		/// </summary>
		public Guid PersonHistoryId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the person history record associated with this nickname.
		/// </summary>
		public PersonHistory PersonHistory { get; set; } = null!;

		#endregion
	}
}