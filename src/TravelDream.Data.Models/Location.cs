namespace TravelDream.Data.Models
{
	using Common;

	public class Location:BaseModel<int>
	{
		public string City { get; set; }
		public Country Country { get; set; }
	}
}
