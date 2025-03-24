using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Agency_worker")]
  public sealed class AgencyWorker
	{
		[Key]
		public int Id { get; set; }

		[Column("SecondName")]
		public string SecondName { get; set; }

    [Column("FirstName")]
    public string FirstName { get; set; }

		[Column("SurName")]
		public string SurName { get; set; }
	}
}
