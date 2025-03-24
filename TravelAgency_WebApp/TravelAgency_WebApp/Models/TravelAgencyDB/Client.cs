using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Client")]
	public sealed class Client
	{
		[Key]
		public int Id { get; set; }

		[Column("SecondName")]
		public string SecondName { get; set; }

		[Column("FirstName")]
		public string FirstName { get; set; }

		[Column("SurName")]
		public string SurName { get; set; }

		[Column("Date_of_birth")]
		public DateTime Date_of_birth { get; set; }

		[Column("Address")]
		public string Address { get; set; }

		[Column("NumberPhone")]
		public string NumberPhone { get; set; }

		[Column("Seria_passport")]
		public int Seria_passport { get; set; }

		[Column("Number_passport")]
		public int Number_passport { get; set; }
	}
}
