namespace TravelAgency_WebApp.Models
{
	sealed public class BookTour
	{
		public int Id { get; set; }
		public int Client_Id { get; set; }
		public int AgencyWorker_Id { get; set; }
		public decimal PriceTour { get; set; }
		public DateTime DateBook { get; set; }
		public DateTime DatePayment { get; set; }
	}
}
