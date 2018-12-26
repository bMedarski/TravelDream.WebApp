namespace TravelDream.Data.Models
{
	using Common;

	public class Discount:BaseModel<int>
	{
		public string Name { get; set; }
		public decimal Percent { get; set; }
	}
}
