using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Number")]
	public sealed class Number
	{
		[Key]
		public int Id { get; set; }

		[Column("Hotel_Id")]
		public int Hotel_Id { get; set; }

		[Column("Type")]
		public string Type { get; set; }

		[Column("Peculiarities")]
		public string Peculiarities { get; set; }

		[Column("Price_per_day")]
		public decimal Price_per_day { get; set; }
	}
}
