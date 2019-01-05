namespace TravelDream.Data.Models
{
	using Common;

	public class Location : BaseModel<int>
	{
		public string City { get; set; }
		public Country Country { get; set; }
		public bool HasPort { get; set; }
		public bool HasAirport { get; set; }
		public bool HasTrainStation { get; set; }
	}
}
