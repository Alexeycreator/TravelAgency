namespace TravelAgency_WebApp.Models
{
	sealed public class Number
	{
		public int Id { get; set; }
		public int Hotel_Id { get; set; }
		public string Type { get; set; }
		public string Peculiarities { get; set; }
		public decimal Price_per_day { get; set; }
	}
}
