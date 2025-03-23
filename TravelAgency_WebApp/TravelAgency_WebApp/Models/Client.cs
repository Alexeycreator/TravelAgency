namespace TravelAgency_WebApp.Models
{
	sealed public class Client
	{
		public int Id { get; set; }
		public string SecondName { get; set; }
		public string FirstName { get; set; }
		public string SurName { get; set; }
		public DateTime Date_of_birth { get; set; }
		public string Address { get; set; }
		public string NumberPhone { get; set; }
		public int Seria_passport { get; set; }
		public int Number_passport { get; set; }
	}
}
