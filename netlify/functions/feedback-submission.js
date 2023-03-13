exports.handler = function(event, context, callback) {
    console.log(event.body);
    const formData = new FormData(event.body);
    console.log(formData);
  
    $.ajax({
      url: '/',
      type: 'POST',
      data: formData,
      processData: false,
      contentType: false,
      success: function(result) {
        callback(null, {
          statusCode: 200,
          body: JSON.stringify({ message: 'Form submission successful' })
        });
      },
      error: function(error) {
        console.error(error);
        callback(null, {
          statusCode: 500,
          body: JSON.stringify({ message: 'Form submission failed' })
        });
      }
    });
  };
  