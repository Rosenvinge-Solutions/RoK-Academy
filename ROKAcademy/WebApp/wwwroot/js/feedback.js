var dotnetRef = null;

const handleFeedbackSubmit = (event) => {
    event.preventDefault();

    const feedbackForm = event.target;
    const formData = new FormData(feedbackForm);

    fetch("/", {
        method: "POST",
        headers: { "Content-Type": "application/x-www-form-urlencoded" },
        body: new URLSearchParams(formData).toString(),
    })
        .then(() => dotnetRef.invokeMethodAsync("FeedbackSubmittedSuccessfully"))
        .catch((error) => alert(error));
};

export function setRef(ref) {
    dotnetRef = ref;
}

export function addFeedbackEventListener() {
    document
        .querySelector("form#feedback")
        .addEventListener("submit", handleFeedbackSubmit);
}