exports.handler = async function(event, context) {
    try {
        const { r, q, a } = JSON.parse(event.body);

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