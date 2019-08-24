layout.newsedit = function () {
    // #region form validation
    $("#form-general").on('submit', function (event) {
        event.preventDefault();

        var formData = $(this).serializeArray(),
            jsonData = serializeFormJSON(formData),
            form = event.target,
            isValid = form.checkValidity();

        // sample self validation
        // #region validate date

        var _start = new Date(jsonData.startdate),
            _end = new Date(jsonData.enddate);
        var $formgroup = $('[name="enddate"], [name="startdate"]').closest('.form-group');

        if (_start >= _end) {
            $formgroup.find('.form-control').removeClass('is-valid').addClass('is-invalid');
            isValid = false;
        } else {
            // $formgroup.find('.flatpickr-input[type="text"]')[0].setCustomValidity('');

            $formgroup.find('.form-control').addClass('is-valid').removeClass('is-invalid');
        }
        // #endregion

        if (!isValid) {
            event.stopPropagation();

            var $el = $(form).find(':invalid, .is-invalid').first(),
                $fg = $el.closest('.form-group');

            $.App.scrollToElement($fg.length > 0 ? $fg : $e, $el);
        } else {
            $.App.handleFormChange(false);

            alert('Save successfull');

            // TODO: submit data to ServiceWorkerRegistration
        }
    });
    // #endregion

    // #region toggle tabs
    $('[data-js-toggle-aria]').on('click', function (e) {
        var _id = $(this).attr('data-js-toggle-aria');
        $(this).siblings('.btn').removeClass('btn-dark').addClass('btn-default');
        $(this).removeClass('btn-default').addClass('btn-dark');

        $('[data-js-toggle]').hide();
        $('[data-js-toggle="' + _id + '"]').show();
    });
    // #endregion


    // #region table images/files
    $('.table-files').on('click', '.btn-edit', function (e) {
        alert('waiting for DK requirement.');

    }).on('click', '.btn-delete', function (e) {
        var $table = $(this).closest('.table-files'),
            $row = $(this).closest('tr'),
            $radio = $row.find('.col-select .radio input'),
            $firstRadio = $table.find('.col-select .radio input').first();

        // Default make the first item be favourite in alternative
        if ($table.find('.row-data').length > 1 && $radio.is(':checked')) {
            $firstRadio.prop('checked', true);
        }

        if ($table.find('.row-data').length > 1) {
            $row.fadeOut('fast', function () {
                $row.remove();
            });
        } else {
            // Remove entire the table if it's empty
            $table.remove();
        }

    });
    // #endregion


    // #region page top actions
    $('.page-actions').on('click', '.btn-fn-addnew', function (e) {
        if ($.App.form.hasChanged) {
            // TODO: modal info/confirm/alert
            if (window.confirm('You have some changes. Do you want to leave this page?')) {
                window.location = window.location.origin + '/news-edit.html';
            }

        } else {
            window.location = window.location.origin + '/news-edit.html';
        }
    }).on('click', '.btn-fn-delete', function(e){

        // TODO: modal info/confirm/alert
        alert('Delete successful.');

        window.location = window.location.origin + '/news-list.html';
    }).on('click', '.btn-fn-cancel', function(e) {

        window.location = window.location.origin + '/news-list.html';
    });
    // #endregion

}