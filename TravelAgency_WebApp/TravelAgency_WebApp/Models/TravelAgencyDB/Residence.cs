using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Residence")]
	public sealed class Residence
	{
		[Key]
		public int BookTour_Id { get; set; }

		public int Number_Id { get; set; }

		[Column("Date_arrival")]
		public DateTime DateArrival { get; set; }

		[Column("Time_arrival")]
		public int TimeArrival { get; set; }
	}
}
