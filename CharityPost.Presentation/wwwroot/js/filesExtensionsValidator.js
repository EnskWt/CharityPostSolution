$.validator.addMethod('filesextensions', function (value, element, params) {
    var extensions = params.split(',');
    var fileExtension = value.split('.').pop().toLowerCase();
    return extensions.includes(fileExtension);
});

$.validator.unobtrusive.adapters.add('filesextensions', ['extensions'], function (options) {
    options.rules['filesextensions'] = options.params.extensions;
    options.messages['filesextensions'] = options.message;
});
