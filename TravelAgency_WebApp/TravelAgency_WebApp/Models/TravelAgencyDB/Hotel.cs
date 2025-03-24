using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Hotel")]
	public sealed class Hotel
	{
		[Key]
		public int Id { get; set; }

		[Column("City_Id")]
		public int City_Id { get; set; }

		[Column("Name_hotel")]
		public string Name_hotel { get; set; }

		[Column("Class")]
		public string Class { get; set; }
	}
}
