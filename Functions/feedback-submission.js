const axios = require('axios');

exports.handler = async function(event, context) {
    try {
        const formData = JSON.parse(event.body);
        const response = await axios.post('https://example.com/submit-form', formData);

        return {
            statusCode: 200,
            body: JSON.stringify({
                message: 'Form submission successful'
            })
        }
    } catch (error) {
        console.error(error);
        return {
            statusCode: 500,
            body: JSON.stringify({
                message: 'Form submission failed'
            })
        }
    }
};