const ignoreParams = ['pageNumber']

document.querySelectorAll('#save-query-form').forEach(function (form) {
            form.addEventListener('submit', function (e) {
                e.preventDefault();
                var urlParams = new URLSearchParams(window.location.search);
                urlParams.forEach(function (value, key) {
                    if (!document.querySelector('input[name="' + key + '"]') && !ignoreParams.includes(key)) {
                        var hiddenField = document.createElement('input');
                        hiddenField.type = 'hidden';
                        hiddenField.name = key;
                        hiddenField.value = value;
                        this.appendChild(hiddenField);
                    }
                }, this);
                this.submit();
            });
        });