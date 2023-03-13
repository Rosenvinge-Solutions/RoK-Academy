//const feedbackBtn = document.getElementById('submitFeedback');
const feedbackForm = document.getElementById('feedback');
var dotnetRef = null;

//const handleFeedbackSubmit = (event) => {
//    event.preventDefault();

//    const feedbackForm = event.target;
//    const formData = new FormData(feedbackForm);

//    fetch("/", {
//        method: "POST",
//        headers: { "Content-Type": "application/x-www-form-urlencoded" },
//        body: new URLSearchParams(formData).toString(),
//    })
//        .then(() => dotnetRef.invokeMethodAsync("FeedbackSubmittedSuccessfully"))
//        .catch((error) => dotnetRef.invokeMethodAsync("HandleError", error));
//};

export function handleFeedbackSubmission() {
    const formData = new FormData(feedbackForm);

    fetch("/", {
        method: "POST",
        headers: { "Content-Type": "application/x-www-form-urlencoded" },
        body: new URLSearchParams(formData).toString(),
    })
        .then(() => dotnetRef.invokeMethodAsync("FeedbackSubmittedSuccessfully"))
        .catch((error) => dotnetRef.invokeMethodAsync("HandleError", error));
}

export function setupEventListeners() {
    /* Setup Events */
    feedbackBtn.addEventListener('click', () => {
        feedbackForm.submit();
    });

    feedbackForm.addEventListener('submit', handleFeedbackSubmit);
}

export function setRef(ref) {
    dotnetRef = ref;
}

export function setFeedbackLanguage(texts) {
    const feedbackModal = document.getElementById('feedbackModal');

    const title = feedbackModal.querySelector('.modal-title');
    const cancelFeedbackBtn = feedbackModal.querySelector('#cancelFeedback');
    const submitFeedbackBtn = feedbackModal.querySelector('#submitFeedback');

    const oldQTextarea = feedbackModal.querySelector('#oldQuestion');
    const oldQLabel = feedbackModal.querySelector('label[for="oldQuestion"]');
    const questionHelp = feedbackModal.querySelector('#oldQuestionHelp');

    const newQTextarea = feedbackModal.querySelector('#newQuestion');
    const newQLabel = feedbackModal.querySelector('label[for="newQuestion"]');
    const newQuestionHelp = feedbackModal.querySelector('#newQuestionHelp');

    const newATextarea = feedbackModal.querySelector('#newAnswer');
    const newALabel = feedbackModal.querySelector('label[for="newAnswer"]');
    const newAnswerHelp = feedbackModal.querySelector('#newAnswerHelp');

    title.textContent = texts[0];
    cancelFeedbackBtn.textContent = texts[1];
    submitFeedbackBtn.textContent = texts[2];
    oldQTextarea.placeholder = texts[3];
    oldQLabel.textContent = texts[4];
    questionHelp.textContent = texts[5];
    newQTextarea.placeholder = texts[6];
    newQLabel.textContent = texts[7];
    newQuestionHelp.textContent = texts[8];
    newATextarea.placeholder = texts[9];
    newALabel.textContent = texts[10];
    newAnswerHelp.textContent = texts[11];
}