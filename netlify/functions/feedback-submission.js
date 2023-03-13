exports.handler = async function(event, context) {
    console.log(event.body);
    const { r, q, a } = JSON.parse(event.body);

    const data = {
        r,
        q,
        a
      };

    console.log(data);

    try {
        const response = await fetch('https://www.rokacademy.com/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
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