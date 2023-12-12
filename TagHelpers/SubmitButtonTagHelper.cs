using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TicketToDo.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "is-submit-button")]
    public class SubmitButtonTagHelper : TagHelper
    {
        public bool IsSubmitButton { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsSubmitButton)
            {
                output.Attributes.SetAttribute("class", "btn btn-primary"); // Add your desired CSS classes
            }
        }
    }
}



