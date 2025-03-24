using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("City")]
	public sealed class City
	{
		[Key]
		public int Id { get; set; }

		[Column("Country_Id")]
		public int Country_Id { get; set; }

		[Column("Name_city")]
		public string Name_city { get; set; }

		[Column("Attractions")]
		public string Attractions { get; set; }
	}
}
