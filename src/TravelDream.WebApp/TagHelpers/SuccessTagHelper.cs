namespace TravelDream.WebApp.TagHelpers
{
	using Microsoft.AspNetCore.Razor.TagHelpers;

	[HtmlTargetElement("success")]
	public class SuccessTagHelper:TagHelper
	{
		public string Message { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";

			if (!string.IsNullOrEmpty(this.Message))
			{
				output.Attributes.SetAttribute("class", "success");
				output.Content.SetContent(this.Message);
			}
		}
	}
}
