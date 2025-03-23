namespace TravelAgency_WebApp.Models
{
	sealed public class Residence
	{
		public int BookTour_Id { get; set; }
		public int Number_Id { get; set; }
		public DateTime DateArrival { get; set; }
		public int TimeArrival { get; set; }
	}
}
