var layout = $.extend(true, {}, layout || {}, {
    touch: {},
    newsedit: function () {}
});

const PATHS = {
    sitelist: 'assets/data/jssites.json'
};


const INCLUDE_HTML_DURATION = 25;
var includeHtmlUnwrapCount = 0,
    myUnwrap;

window.devmode = true;


layout.sitelist = function (el) {
    $.get(PATHS.sitelist, function (responseJSON) {

        var options = responseJSON.map(function (n, index) {
                return '<option value="' + index + '"' + (n.Selected ? " selected " : "") + ' >' + n.Name + '</option>';
            })
            .join('');

        var selectedVal = responseJSON.filter(function (n) { return n.Selected; });

        $(el).html(options);

        $(el).selectpicker('destroy').selectpicker('render');

        // Hide side menu if opening on narrow view
        $(el).on('show.bs.select', function (e) {
            $.App.$el.body.removeClass('sidebar-enable');
        })

        // Redirect site
        $(el).on('change', function () {
            if (this.value != gup('SiteGuid')) {
                window.location = window.location.origin + '/?SiteGuid=' + this.value;
            }
        });

        // Set selected site
        if (window.location.search) {
            $(el).selectpicker('val', gup('SiteGuid'));
        }
    });
}

function gup(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}

function includeHtmlUnwrap() {
    includeHtmlUnwrapCount++;

    if ($('[data-include-html]').length == 0) {
        clearInterval(myUnwrap);

        $('[data-js-unwrap]').unwrap().removeAttr('data-js-unwrap');

        // Call here for this test project ONLY
        // Re-asign as delay of render html
        $.App.$el = {
            body: $('body'),
            logoBox: $('.logo-box'),
            navbarCustom: $('.navbar-custom'),
            sitesPicker: $('.sites-picker'),
            leftSideMenu: $('.left-side-menu'),
            contentPage: $('.content-page'),
            contentMain: $('.content-main'),
            contentStickableTop: $('.content-top.stickable'),
            contentStickableBottom: $('.content-bottom.stickable'),
            footer: $('.content-page > footer')
        };

        $.App.init();

        // Fix firefox
        $('.form-control.selectpicker').selectpicker();


        layout.newsedit();

        // call here cause partial view lazy load
        // it's already in app.js
        $('#status').fadeOut();
        $('#preloader').delay(200).fadeOut('slow');
    }
}

$(function () {

    myUnwrap = setInterval(includeHtmlUnwrap, INCLUDE_HTML_DURATION);

    layout.sitelist('[data-mcb-js-sitelist]');

    $('form.needs-validation').on('submit', function (e) {
        e.preventDefault();
    })

    $('[data-mcb-js-submit]').on('click', function (e) {
        var forms = $(this).attr('data-mcb-js-submit');

        $(forms).submit();
    });
})