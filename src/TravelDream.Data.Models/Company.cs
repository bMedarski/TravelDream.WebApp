namespace TravelDream.Data.Models
{
	using Common;

	public class Company:BaseModel<int>
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public int PhoneNumber { get; set; }
		public Country Country { get; set; }
	}
}
