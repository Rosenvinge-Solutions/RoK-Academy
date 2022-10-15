const feedbackBtn = document.getElementById('submitFeedback');
const feedbackForm = document.getElementById('feedback');
var dotnetRef = null;

const handleFeedbackSubmit = (event) => {
    event.preventDefault();

    const feedbackForm = document.getElementById('feedback');
    const formData = new FormData(feedbackForm);

    fetch("/", {
        method: "POST",
        headers: { "Content-Type": "application/x-www-form-urlencoded" },
        body: new URLSearchParams(formData).toString(),
    })
        .then(() => dotnetRef.invokeMethodAsync("FeedbackSubmittedSuccessfully"))
        .catch((error) => alert(error));
};

export function setupEventListeners() {
    /* Setup Events */
    feedbackBtn.addEventListener('click', () => {
        console.log('Event fired from submit feedback.');

        feedbackForm.submit();
    });

    feedbackForm.addEventListener('submit', handleFeedbackSubmit);
}

export function setRef(ref) {
    dotnetRef = ref;

    console.log("Ref was set.")
}