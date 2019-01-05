namespace TravelDream.Services.ViewModels.LocationModels
{
	public class InputLocationViewModel
	{
		public string Name { get; set; }
		public int CountryId { get; set; }
		public bool HasAirport { get; set; }
		public bool HasPort { get; set; }
		public bool HasTrainStation { get; set; }
	}
}
