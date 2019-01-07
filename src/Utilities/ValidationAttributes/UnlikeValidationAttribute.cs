namespace TravelDream.Services.Utilities.ValidationAttributes
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class UnlikeValidationAttribute : ValidationAttribute, IClientModelValidator
	{

		public string OtherLocation { get; private set; }

		public UnlikeValidationAttribute(string otherLocation)
		{
			this.OtherLocation = otherLocation;
		}

		protected override ValidationResult IsValid(object value,
			ValidationContext validationContext)
		{
			if (value != null)
			{
				var otherProperty = validationContext.ObjectInstance.GetType()
					.GetProperty(this.OtherLocation);

				var otherPropertyValue = otherProperty
					.GetValue(validationContext.ObjectInstance, null);

				if (value.Equals(otherPropertyValue))
				{
					return new ValidationResult("Second location must be different than the first");
				}
			}

			return ValidationResult.Success;
		}

		public void AddValidation(ClientModelValidationContext context)
		{
			this.MergeAttribute(context.Attributes, "data-val", "true");
			var errorMessage = this.FormatErrorMessage(context.ModelMetadata.GetDisplayName());
			this.MergeAttribute(context.Attributes, "data-val-unlike", errorMessage);
		}

		private bool MergeAttribute(
			IDictionary<string, string> attributes,
			string key,
			string value)
		{
			if (attributes.ContainsKey(key))
			{
				return false;
			}
			attributes.Add(key, value);
			return true;
		}
	}
}
