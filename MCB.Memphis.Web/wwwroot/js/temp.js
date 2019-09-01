var layout = $.extend(true, {}, layout || {}, {
    touch: {},
    sitelist: function () {},
    grouplist: function () {},
    productgrouplist: function () {},
});

const PATHS = {
    sitelist: 'assets/data/jssites.json',
    grouplist: 'assets/data/jsgroups.json',
    productgrouplist: 'assets/data/jsproductgroups.json'
};


const INCLUDE_HTML_DURATION = 25;
var includeHtmlUnwrapCount = 0,
    myUnwrap;

window.devmode = true;

function includeHtmlUnwrap() {
    includeHtmlUnwrapCount++;

    if ($('[data-include-html]').length == 0) {
        clearInterval(myUnwrap);

        $('[data-js-unwrap]').unwrap().removeAttr('data-js-unwrap');

        // !IMPORTANT
        // Create and dispatch the EVENT.
        var event = new CustomEvent('mcbready');
        document.dispatchEvent(event);
    }
};
myUnwrap = setInterval(includeHtmlUnwrap, INCLUDE_HTML_DURATION);



layout.sitelist = function (el) {
    if ($(el).length == 0) return;

    $.get(PATHS.sitelist, function (responseJSON) {

        var options = responseJSON.map(function (n, index) {
                return '<option value="' + index + '"' + (n.Selected ? " selected " : "") + ' >' + n.Name + '</option>';
            })
            .join('');

        var urlParams = new URLSearchParams(window.location.search)
        siteGuid = urlParams.get('siteGuid');

        $(el).html(options);
        $(el).selectpicker();

        // Set selected site
        if (siteGuid != undefined) {
            $(el).selectpicker('val', siteGuid);
        }

        // Hide side menu if opening on narrow view
        $(el).on('show.bs.select', function (e) {
            $.App.$el.body.removeClass('sidebar-enable');
        }).on('changed.bs.select', function (e, clickedIndex, isSelected, previousValue) {
            window.location = window.location.origin + '/?siteGuid=' + this.value;
        });
    });
};

layout.grouplist = function (el) {
    if ($(el).length == 0) return;

    $.get(PATHS.grouplist, function (responseJSON) {

        var options = responseJSON.map(function (n, index) {
                return '<option value="' + index + '"' + (n.Selected ? " selected " : "") + ' >' + n.Name + '</option>';
            })
            .join('');

        $(el).html(options);
        $(el).selectpicker();
    });
};

layout.productgrouplist = function (el) {
    if ($(el).length == 0) return;

    $.get(PATHS.productgrouplist, function (responseJSON) {

        var options = responseJSON.map(function (n, index) {
                return '<option value="' + index + '"' + (n.Selected ? " selected " : "") + ' >' + n.Name + '</option>';
            })
            .join('');

        $(el).html(options);
        $(el).selectpicker();
    });
};


$(document).on('mcbready', function () {
    $('#status').fadeOut();
    $('#preloader').delay(200).fadeOut('slow');

    $.App.init();

    layout.sitelist('.sites-picker select');
    layout.grouplist('.filterbar__compact .form-group--f-groups select');
    layout.productgrouplist('.filterbar__expand .form-group--f-groups select');

    $('form.needs-validation').on('submit', function (e) {
        e.preventDefault();
    })

    $('[data-mcb-js-submit]').on('click', function (e) {
        var forms = $(this).attr('data-mcb-js-submit');

        $(forms).submit();
    });
});