using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency_WebApp.Models
{
	[Table("Book_tour")]
	public sealed class BookTour
	{
		[Key]
		public int Id { get; set; }

		[Column("Client_Id")]
		public int Client_Id { get; set; }

		[Column("Agency_worker_Id")]
		public int AgencyWorker_Id { get; set; }

		[Column("Price_tour")]
		public decimal PriceTour { get; set; }

		[Column("Date_book")]
		public DateTime DateBook { get; set; }

		[Column("Date_payment")]
		public DateTime DatePayment { get; set; }
	}
}
