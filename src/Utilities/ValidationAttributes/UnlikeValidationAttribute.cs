namespace TravelDream.Services.Utilities.ValidationAttributes
{
	using System.ComponentModel.DataAnnotations;

	public class UnlikeValidationAttribute : ValidationAttribute
	{
		private readonly string _otherLocation;


		public UnlikeValidationAttribute(string otherLocation)
		{
			this._otherLocation = otherLocation;
		}

		protected override ValidationResult IsValid(object value,
			ValidationContext validationContext)
		{
			var otherProperty = validationContext.ObjectInstance.GetType()
				.GetProperty(this._otherLocation);

			var otherPropertyValue = otherProperty
				.GetValue(validationContext.ObjectInstance, null);
			if (value != null && (otherPropertyValue != null && value.ToString()==otherPropertyValue.ToString()))
			{
				return new ValidationResult("Second location must be different than the first");
			}
			return ValidationResult.Success;
		}
	}
}
