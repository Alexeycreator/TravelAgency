using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Country")]
	public sealed class Country
	{
		[Key]
		public int Id { get; set; }

		[Column("Name_country")]
		public string Name_country { get; set; }

		[Column("Main_Language")]
		public string Main_Language { get; set; }
	}
}
