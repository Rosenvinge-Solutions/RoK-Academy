using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using WebApp.Shared.DataModels;

namespace WebApp.Shared.Modals
{
    public partial class FeedbackSubmissionModal
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        private EditContext context;
        private FeedbackFormModel model = new();
        private Guid submissionId = Guid.Empty;
        private bool feedbackSubmitSuccess = false;
        private string feedbackSubmitMessage = string.Empty;
        private string submissionAction = string.Empty;
        private string feedbackModule = "./js/feedback.js";

        protected override async Task OnInitializedAsync()
        {
            MakeContext();

            IJSObjectReference module = await ImportModuleReferenceAsync(feedbackModule);
            await module.InvokeVoidAsync("setRef", DotNetObjectReference.Create(this));

            await base.OnInitializedAsync();
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

                //var response = await Client.SendAsync(request);

                //feedbackSubmitSuccess = response.IsSuccessStatusCode;

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

        private async Task HandleFeedbackSubmissionAsync()
        {
            try
            {
                IJSObjectReference module = await ImportModuleReferenceAsync(feedbackModule);
                await module.InvokeVoidAsync("handleFeedbackSubmission");
            }
            finally
            {
                context.MarkAsUnmodified();
                model = new();
            }
        }

        [JSInvokable]
        public void FeedbackSubmittedSuccessfully()
        {
            Console.WriteLine("Response from JS");
        }

        [JSInvokable]
        public void HandleError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
