using System.ComponentModel.DataAnnotations;

namespace WebApp.Shared.DataModels
{
    public class FeedbackFormModel
    {
        [Required(AllowEmptyStrings = true)]
        [StringLength(0, ErrorMessage = "This form was submitted by a robot.")]
        public string BotField { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid question.")]
        [StringLength(250, ErrorMessage = "The field {0} cannot exceed 250 characters.")]
        public string Question { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = true, ErrorMessage = "Please enter a valid replacement question.")]
        [StringLength(250, ErrorMessage = "The field {0} cannot exceed 250 characters.")]
        public string ReplacementQuestion { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a valid answer.")]
        [StringLength(250, ErrorMessage = "The field {0} cannot exceed 250 characters.")]
        public string Answer { get; set; } = string.Empty;

        public IDictionary<string, string> FormData
        {
            get => new Dictionary<string, string>()
            {
                { "ReplacementQuestion", ReplacementQuestion },
                { "Question", Question },
                { "Answer", Answer }
            };
        }
    }
}
