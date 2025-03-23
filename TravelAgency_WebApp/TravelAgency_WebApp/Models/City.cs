namespace TravelAgency_WebApp.Models
{
	sealed public class City
	{
		public int Id { get; set; }
		public int Country_Id { get; set; }
		public string Name_city { get; set; }
		public string Attractions { get; set; }
	}
}
