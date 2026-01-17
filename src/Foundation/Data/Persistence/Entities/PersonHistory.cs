using System;
using System.Collections.Generic;

namespace DynastyOfChampions.Foundation.Data.Persistence.Entities
{
	/// <summary>
	/// Represents a historical snapshot of a person's identity attributes that may
	/// change over time, such as names and suffix.
	/// </summary>
	public class PersonHistory
	{
		#region Properties

		/// <summary>
		/// The unique identifier for this historical record.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// The person's given names during this period.
		/// </summary>
		public string GivenNames { get; set; } = null!;

		/// <summary>
		/// The person's surname during this period.
		/// </summary>
		public string Surname { get; set; } = null!;

		/// <summary>
		/// Optional suffix associated with the person's name during this period.
		/// </summary>
		public string? Suffix { get; set; }

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
		/// The identifier of the person to which this historical record belongs.
		/// </summary>
		public Guid PersonId { get; set; }

		#endregion

		#region Navigation Properties

		/// <summary>
		/// Navigation to the person associated with this historical record.
		/// </summary>
		public Person Person { get; set; } = null!;

		/// <summary>
		/// Navigation to the collection of nicknames associated with this historical record.
		/// </summary>
		public ICollection<PersonNickname> Nicknames { get; set; } = new List<PersonNickname>();

		#endregion
	}
}