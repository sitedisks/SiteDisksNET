$(function () {
    $.validator.messages.required = "*";
    $('#contact-form').validate(
    {
        rules: {
            name: {
                minlength: 2,
                required: true
            },
            email: {
                required: true,
                email: true
            },
            subject: {
                minlength: 2,
                required: true
            },
            message: {
                minlength: 5,
                required: true
            }
        },
        errorPlacement: function (error, element) {
            if (element.attr('name') != 'email') {
                element.before(error);
            } else {
                error.insertBefore($('.input-group'));
            }
        },
        highlight: function (element) {
            $(element).closest('.has-success').removeClass('has-success').addClass('has-error');
        },
        success: function (element) {
            $(element).closest('.has-error').removeClass('has-error').addClass('has-success');
        }
    });
});