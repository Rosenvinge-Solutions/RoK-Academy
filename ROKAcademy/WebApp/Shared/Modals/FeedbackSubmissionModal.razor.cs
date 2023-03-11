using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using WebApp.Shared.DataModels;

namespace WebApp.Shared.Modals
{
    public partial class FeedbackSubmissionModal
    {
        [Inject]
        public HttpClient Client { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        private EditContext context;
        private FeedbackFormModel model = new();
        private Guid submissionId = Guid.Empty;
        private bool feedbackSubmitSuccess = false;
        private string feedbackSubmitMessage = string.Empty;
        private string submissionAction = string.Empty;

        protected override void OnInitialized()
        {
            MakeContext();

            base.OnInitialized();
        }

        private void MakeContext()
        {
            context = new(model);
            context.EnableDataAnnotationsValidation();
        }

        private void CloseFeedback()
        {
            submissionId = Guid.Empty;
            submissionAction = $"/feedback/submission";
            feedbackSubmitMessage = string.Empty;
            feedbackSubmitSuccess = false;

            MakeContext();
        }

        private async Task HandleValidFeedbackSubmitAsync()
        {
            feedbackSubmitMessage = string.Empty;

            try
            {
                var encodedData = new FormUrlEncodedContent(model.FormData);

                HttpRequestMessage request = new(HttpMethod.Post, "")
                {
                    Content = encodedData
                };
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var response = await Client.SendAsync(request);

                feedbackSubmitSuccess = response.IsSuccessStatusCode;

                if (feedbackSubmitSuccess)
                {
                    feedbackSubmitMessage = "Your request was sent successfully.";
                    return;
                }

                feedbackSubmitMessage = "Something went wrong while making the feedback request.";
            }
            finally
            {
                
            }
        }

        private void HandleFeedbackSubmission()
        {
            try
            {
                submissionId = Guid.NewGuid();

                feedbackSubmitSuccess = true;
                feedbackSubmitMessage = "Your request was sent successfully.";
                submissionAction = $"/feedback/submission?guid={submissionId}";
            }
            finally
            {
                context.MarkAsUnmodified();
                model = new();
            }
        }
    }
}
