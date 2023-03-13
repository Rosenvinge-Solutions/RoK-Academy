using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using WebApp.Shared.DataModels;

namespace WebApp.Shared.Modals
{
    public partial class FeedbackSubmissionModal
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public HttpClient HttpClient { get; set; }

        private EditContext context;
        private FeedbackFormModel model = new();
        private bool feedbackSubmitSuccess = false;
        private string feedbackSubmitMessage = string.Empty;
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
            feedbackSubmitMessage = string.Empty;
            feedbackSubmitSuccess = false;

            MakeContext();
        }

        private async Task HandleFeedbackSubmissionAsync()
        {
            try
            {
                var submitResponse = await HttpClient.PostAsJsonAsync("/feedback", model);
                feedbackSubmitSuccess = submitResponse.IsSuccessStatusCode;

                if (!feedbackSubmitSuccess)
                {
                    feedbackSubmitMessage = "Couldn't deliver message.";
                    return;
                }

                feedbackSubmitMessage = "Message was sent successfully.";
                //IJSObjectReference module = await ImportModuleReferenceAsync(feedbackModule);
                //await module.InvokeVoidAsync("handleFeedbackSubmission");
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

        }

        [JSInvokable]
        public void HandleError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
