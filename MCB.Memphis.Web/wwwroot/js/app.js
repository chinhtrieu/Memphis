/*
Template Name: Ubold - Responsive Bootstrap 4 Admin Dashboard
Author: CoderThemes
Version: 3.0.0
Website: https://coderthemes.com/
Contact: support@coderthemes.com
File: Main Js File
*/

// Components
!function ($) {
    "use strict";

    var Components = function () { };

    //initializing tooltip
    Components.prototype.initTooltipPlugin = function () {
        $.fn.tooltip && $('[data-toggle="tooltip"]').tooltip()
    },

    //initializing popover
    Components.prototype.initPopoverPlugin = function () {
        $.fn.popover && $('[data-toggle="popover"]').popover()
    },

    //initializing toast
    Components.prototype.initToastPlugin = function() {
        $.fn.toast && $('[data-toggle="toast"]').toast()
    },

    //initializing Slimscroll
    Components.prototype.initSlimScrollPlugin = function () {
        //You can change the color of scroll bar here
        $.fn.slimScroll && $(".slimscroll").slimScroll({
            height: 'auto',
            position: 'right',
            size: "8px",
            touchScrollStep: 20,
            color: '#9ea5ab'
        });
    },

    //initializing form validation
    Components.prototype.initFormValidation = function () {
        $(".needs-validation").on('submit', function (event) {
            event.preventDefault();

            var form = event.target;
            form.classList.add('was-validated');

            if (!form.checkValidity()) {
                event.stopPropagation();

            } else if (window.devmode) {
                console.log($(this).attr('id'), $(this).serializeArray());
            }
        });
    },

    //initializing custom modal
    Components.prototype.initCustomModalPlugin = function() {
        $('[data-plugin="custommodal"]').on('click', function(e) {
            e.preventDefault();
            var modal = new Custombox.modal({
                content: {
                    target: $(this).attr("href"),
                    effect: $(this).attr("data-animation")
                },
                overlay: {
                    color: $(this).attr("data-overlayColor")
                }
            });
            // Open
            modal.open();
        });
    },

    // Counterup
    // Components.prototype.initCounterUp = function() {
    //     var delay = $(this).attr('data-delay')?$(this).attr('data-delay'):100; //default is 100
    //     var time = $(this).attr('data-time')?$(this).attr('data-time'):1200; //default is 1200
    //      $('[data-plugin="counterup"]').each(function(idx, obj) {
    //         $(this).counterUp({
    //             delay: 100,
    //             time: 1200
    //         });
    //      });
    // },

    //peity charts
    // Components.prototype.initPeityCharts = function() {
    //     $('[data-plugin="peity-pie"]').each(function(idx, obj) {
    //         var colors = $(this).attr('data-colors')?$(this).attr('data-colors').split(","):[];
    //         var width = $(this).attr('data-width')?$(this).attr('data-width'):20; //default is 20
    //         var height = $(this).attr('data-height')?$(this).attr('data-height'):20; //default is 20
    //         $(this).peity("pie", {
    //             fill: colors,
    //             width: width,
    //             height: height
    //         });
    //     });
    //     //donut
    //      $('[data-plugin="peity-donut"]').each(function(idx, obj) {
    //         var colors = $(this).attr('data-colors')?$(this).attr('data-colors').split(","):[];
    //         var width = $(this).attr('data-width')?$(this).attr('data-width'):20; //default is 20
    //         var height = $(this).attr('data-height')?$(this).attr('data-height'):20; //default is 20
    //         $(this).peity("donut", {
    //             fill: colors,
    //             width: width,
    //             height: height
    //         });
    //     });

    //     $('[data-plugin="peity-donut-alt"]').each(function(idx, obj) {
    //         $(this).peity("donut");
    //     });

    //     // line
    //     $('[data-plugin="peity-line"]').each(function(idx, obj) {
    //         $(this).peity("line", $(this).data());
    //     });

    //     // bar
    //     $('[data-plugin="peity-bar"]').each(function(idx, obj) {
    //         var colors = $(this).attr('data-colors')?$(this).attr('data-colors').split(","):[];
    //         var width = $(this).attr('data-width')?$(this).attr('data-width'):20; //default is 20
    //         var height = $(this).attr('data-height')?$(this).attr('data-height'):20; //default is 20
    //         $(this).peity("bar", {
    //             fill: colors,
    //             width: width,
    //             height: height
    //         });
    //      });
    // },

    // Components.prototype.initKnob = function() {
    //     $('[data-plugin="knob"]').each(function(idx, obj) {
    //        $(this).knob();
    //     });
    // },

    Components.prototype.initTippyTooltips = function () {
        if($('[data-plugin="tippy"]').length > 0)
        tippy('[data-plugin="tippy"]');
    },

    //initilizing
    Components.prototype.init = function () {
        var $this = this;
        this.initTooltipPlugin(),
        this.initPopoverPlugin(),
        this.initToastPlugin(),
        this.initSlimScrollPlugin(),
        this.initFormValidation(),
        this.initCustomModalPlugin(),
        // this.initCounterUp(),
        // this.initPeityCharts(),
        // this.initKnob();
        this.initTippyTooltips();
    },

    $.Components = new Components, $.Components.Constructor = Components

}(window.jQuery),


// Portlet
function($) {
    "use strict";

    /**
    Portlet Widget
    */
    var Portlet = function() {
        this.$body = $("body"),
        this.$portletIdentifier = ".card",
        this.$portletCloser = '.card a[data-toggle="remove"]',
        this.$portletRefresher = '.card a[data-toggle="reload"]'
    };

    //on init
    Portlet.prototype.init = function() {
        // Panel closest
        var $this = this;
        $(document).on("click",this.$portletCloser, function (ev) {
            ev.preventDefault();
            var $portlet = $(this).closest($this.$portletIdentifier);
                var $portlet_parent = $portlet.parent();
            $portlet.remove();
            if ($portlet_parent.children().length == 0) {
                $portlet_parent.remove();
            }
        });

        // Panel Reload
        $(document).on("click",this.$portletRefresher, function (ev) {
            ev.preventDefault();
            var $portlet = $(this).closest($this.$portletIdentifier);
            // This is just a simulation, nothing is going to be reloaded
            $portlet.append('<div class="card-disabled"><div class="card-portlets-loader"></div></div>');
            var $pd = $portlet.find('.card-disabled');
            setTimeout(function () {
                $pd.fadeOut('fast', function () {
                    $pd.remove();
                });
            }, 500 + 300 * (Math.random() * 5));
        });
    },
    //
    $.Portlet = new Portlet, $.Portlet.Constructor = Portlet

}(window.jQuery),


// FormAdvanced
!function($) {
    "use strict";

    var FormAdvanced = function() {};

    //initializing tooltip
    FormAdvanced.prototype.initSelect2 = function () {
        // Select2
        if ($.fn.select2) {
            $('[data-plugin="select2"]').select2();
        }
    },

    //initializing popover
    //Max Length
    FormAdvanced.prototype.initMaxLength = function () {
        //Bootstrap-MaxLength
        if ($.fn.maxlength) {
            $('textarea[maxlength]').maxlength({
                alwaysShow: true,
                placement: 'top-right-inside',
                warningClass: "badge badge-dark",
                limitReachedClass: "badge badge-warning",
                appendToParent: true
            });
        }
    },

    // summernote - html editor
    FormAdvanced.prototype.initSummernote = function () {
        if ($.fn.summernote) {
            $('[data-plugin="summernote"]').each(function (idx, obj) {
                var $this = $(this),
                    _height = $this.attr('data-height');

                $(this).summernote({
                    height: _height,
                    minHeight: 180, // set minimum height of editor
                    maxHeight: 800, // set maximum height of editor
                    focus: false, // set focus to editable area after initializing summernote
                    followingToolbar: false, // solve the problem page tremble when scrolling slowly
                    callbacks: {
                        onChange: function(contents, $editable) {
                            // console.log('onChange:', contents, $editable);
                            $.App.handleFormChange(true);
                        }
                    }
                });
            });
        }
    },

    FormAdvanced.prototype.initDropzone = function () {
        if ($.fn.dropzone) {
            $('[data-plugin="dropzone"]').each(function (idx, obj) {
                var _maxFilesize = obj.getAttribute('dz-max-filesize'),
                    _maxFiles = obj.getAttribute('dz-max-files'),
                    _acceptedFiles = obj.getAttribute('dz-accepted-files');

                // can pass option url to replace form action

                $(this).dropzone({
                    maxFilesize: parseFloat(_maxFilesize), // MB
                    maxFiles: parseInt(_maxFiles),
                    acceptedFiles: _acceptedFiles,
                    addRemoveLinks: true,
                    dictRemoveFile: 'Remove',
                    accept: function (file, done) {
                        if (file.name == "justinbieber.jpg") {
                            done("Naha, you don't.");
                        } else { done(); }
                    }
                }).addClass('dropzone');
            });
        }
    },

    // //initializing Custom Select
    // FormAdvanced.prototype.initCustomSelect = function() {
    //     $('[data-plugin="customselect"]').niceSelect();
    // },

    // //initializing Slimscroll
    // FormAdvanced.prototype.initSwitchery = function() {
    //     $('[data-plugin="switchery"]').each(function (idx, obj) {
    //         new Switchery($(this)[0], $(this).data());
    //     });
    // },

    // //initializing form validation
    // FormAdvanced.prototype.initMultiSelect = function() {
    //     if($('[data-plugin="multiselect"]').length > 0)
    //         $('[data-plugin="multiselect"]').multiSelect($(this).data());
    // },

    // // touchspin
    // FormAdvanced.prototype.initTouchspin = function() {
    //     var defaultOptions = {
    //     };

    //     // touchspin
    //     $('[data-toggle="touchspin"]').each(function (idx, obj) {
    //         var objOptions = $.extend({}, defaultOptions, $(obj).data());
    //         $(obj).TouchSpin(objOptions);
    //     });
    // },


    //initilizing
    FormAdvanced.prototype.init = function() {
        var $this = this;
        this.initSelect2(),
        this.initMaxLength(),
        this.initSummernote(),
        this.initDropzone()
        // this.initCustomSelect(),
        // this.initSwitchery(),
        // this.initMultiSelect(),
        // this.initTouchspin();
    },

    $.FormAdvanced = new FormAdvanced, $.FormAdvanced.Constructor = FormAdvanced

}(window.jQuery),


// FormPickers
! function ($) {
    "use strict";

    var FormPickers = function () {};

    FormPickers.prototype.init = function () {
        if ($.fn.flatpickr) {

            $('[data-plugin="flatpickr"]').flatpickr({
                altInput: true,
                altFormat: "F j, Y",        // Human-friendly Dates
                dateFormat: "Y-m-d",
                // defaultDate: '01/01/2019',
                minDate: new Date(),
                // maxDate: '24/12/2029'
            });
        }
    },

    $.FormPickers = new FormPickers, $.FormPickers.Constructor = FormPickers

}(window.jQuery),


// App
function ($) {
    'use strict';

    const VIEWPORT_WIDTH_MD = 768;

    var App = function () {
        this.$el = {
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
        this.sticky = {
            forceUpdate: false
        };
        this.form = {
            hasChanged: false
        };
        this.$window = $(window);
    };

    /**
    Resets the scroll
    */
    App.prototype._resetSidebarScroll = function () {
        // sidebar - scroll container
        $('.slimscroll-menu').slimscroll({
            height: 'auto',
            position: 'right',
            size: "6px",
            color: '#9ea5ab',
            wheelStep: 5,
            touchScrollStep: 20
        });
    },

    /**
     * Initlizes the menu - top and sidebar
    */
    App.prototype.initMenu = function () {
        var $this = this;

        // Left menu collapse
        $('.button-menu-mobile').on('click', function (event) {
            event.preventDefault();
            $this.$el.body.toggleClass('sidebar-enable');

            if ($this.$window.width() >= VIEWPORT_WIDTH_MD) {
                $this.$el.body.toggleClass('enlarged');
            } else {
                $this.$el.body.removeClass('enlarged');
            }

            // sidebar - scroll container
            $this._resetSidebarScroll();
        });

        // sidebar - main menu
        $("#side-menu").metisMenu({activeClass: 'menu-root--hovering'});

        $this.adjustLayout();

        // sidebar - scroll container
        $this._resetSidebarScroll();

        // right side-bar toggle
        $('.right-bar-toggle').on('click', function (e) {
            $('body').toggleClass('right-bar-enabled');
        });

        $('.metismenu .menu-root').on('mouseenter', function (e) {
            $(this).addClass('menu-root--hovering');

            var menuWidth = $this.$el.leftSideMenu[0].getBoundingClientRect().width,
                $menuPopover = $(this).find('.nav-second-level').first();
            if ($menuPopover.length) {
                if ($this.$el.body.is('.enlarged')) {

                    $menuPopover.css('left', menuWidth);
                } else {
                    $menuPopover.css('left', '');
                }
            }

            // hide opening boostrap select on top bar
            var $bsSitepicker = $this.$el.sitesPicker.find('.bootstrap-select');

            if ($bsSitepicker.is('.show')){
                $bsSitepicker.find('input.form-control').blur();
                $bsSitepicker.find('select').selectpicker('toggle');
            }

        }).on('mouseleave', function (e) {
            $(this).removeClass('menu-root--hovering');
        });

        $(document).on('click', 'body', function (e) {
            if ($(e.target).closest('.right-bar-toggle, .right-bar').length > 0) {
                return;
            }

            if ($(e.target).closest('.left-side-menu, .side-nav').length > 0 || $(e.target).hasClass('button-menu-mobile')
                || $(e.target).closest('.button-menu-mobile').length > 0) {
                return;
            }

            $('body').removeClass('right-bar-enabled');
            $('body').removeClass('sidebar-enable');
            return;
        });

        // activate the menu in left side bar based on url
        $("#side-menu a").each(function () {
            var pageUrl = window.location.href.split(/[?#]/)[0];
            if (this.href == pageUrl) {
                $(this).addClass("active");
                $(this).parent().addClass("active"); // add active to li of the current link
                $(this).parent().parent().addClass("in");
                $(this).parent().parent().prev().addClass("active"); // add active class to an anchor
                $(this).parent().parent().parent().addClass("active");
                $(this).parent().parent().parent().parent().addClass("in"); // add active to li of the current link
                $(this).parent().parent().parent().parent().parent().addClass("active");
            }
        });

        // Topbar - main menu
        $('.navbar-toggle').on('click', function (event) {
            $(this).toggleClass('open');
            $('#navigation').slideToggle(400);
        });

        // Preloader
        $(window).on('load', function () {
            $('#status').fadeOut();
            $('#preloader').delay(350).fadeOut('slow');
        });
    },

    /**
     * Init the layout - with broad sidebar or compact side bar
    */
    App.prototype.initLayout = function () {
        var $this = this;
        // in case of small size, add class enlarge to have minimal menu

        // Removed by MCB to keep left menu always collapse
        // if (this.$window.width() >= VIEWPORT_WIDTH_MD && this.$window.width() <= 1028) {
        //     this.$el.body.addClass('enlarged');
        // } else {
        //     if (this.$el.body.data('keep-enlarged') != true) {
        //         this.$el.body.removeClass('enlarged');
        //     }
        // }

        this.$el.body.addClass('enlarged');

        if (this.$el.contentStickableTop.length > 0) {
            var _timestamp = (new Date()).getTime();

            // this.$el.body.append(`<div class="sticky-proxy" id="${_timestamp}"></div>`);
            // this.$el.contentStickableTop.data('aria-labelledby', `#${_timestamp}`);

            this.$el.body.append('<div class="sticky-proxy" id="' + _timestamp + '"></div>');
            this.$el.contentStickableTop.data('aria-labelledby', '#' + _timestamp);
        }

        $('form.needs-validation').on('change', 'input, select, textarea', function (e) {
            $this.handleFormChange(true);
        });
    },

    App.prototype.handleFormChange = function (formChanged) {
        formChanged = formChanged == undefined ? false : formChanged;
        this.form.hasChanged = formChanged;

        if (formChanged) {
            // enable Save button
            $('.page-actions--bottom .btn-fn-submit').removeAttr('disabled');
        } else {
            $('.page-actions--bottom .btn-fn-submit').attr('disabled', 'disabled');
        }
    },

    App.prototype.handleStickyActions = function () {
        var $this = this,
            $stickyTop = this.$el.contentStickableTop,
            $stickyBottom = this.$el.contentStickableBottom,
            $contentMain = this.$el.contentMain,
            $footer = this.$el.footer;
        var _currentScroll, _currentOffset, _currentHeight;

        $(window).off('on').on('scroll', function (e) {

            _currentScroll = $('html, body').scrollTop();

            if ($stickyTop.length > 0) {

                if (_currentScroll > 0) {
                    if ($this.sticky.forceUpdate) {
                        $stickyTop.removeClass('sticky').css({ left: 'auto', top: 0 });
                    }

                    _currentOffset = $stickyTop.offset();

                    if (!$stickyTop.hasClass('sticky')) {
                        $stickyTop.addClass('sticky').css(_currentOffset);
                    }

                    // keep sticky height status, up to date
                    $($stickyTop.data('aria-labelledby')).height($stickyTop.outerHeight());

                } else {
                    $stickyTop.removeClass('sticky').css({ left: 'auto', top: 0 });
                }
            }

            if ($stickyBottom.length > 0) {
                _currentHeight = $stickyBottom.outerHeight();
                var _isValidScroll = window.innerHeight + _currentScroll < $(document).outerHeight() - $footer.outerHeight() - _currentHeight;

                if (_isValidScroll && $this.form.hasChanged) {
                    if ($this.sticky.forceUpdate) {
                        $stickyBottom.removeClass('sticky').css({});
                    }
                    _currentOffset = $stickyBottom.offset();

                    $contentMain.css({ marginBottom: _currentHeight });
                    $stickyBottom.addClass('sticky').css({ left: _currentOffset.left });
                } else {
                    $contentMain.css({ marginBottom: 0 });
                    $stickyBottom.removeClass('sticky').css({});
                }
            }

            $this.sticky.forceUpdate = false;
        });
    },

    App.prototype.adjustLayout = function () {
        var menuWidth = this.$el.leftSideMenu[0].getBoundingClientRect().width,
            marginLeft = window.innerWidth < VIEWPORT_WIDTH_MD ? '' : menuWidth;

        this.$el.logoBox.css('width', marginLeft);
        this.$el.contentPage.css('margin-left', marginLeft);
        this.$el.footer.css('left', marginLeft);
    },

    App.prototype.scrollToElement = function (elToScroll, elToFocus) {
        if ($(elToScroll) === undefined) return;

        var _offset = $(elToScroll).offset(),
            _currentTop = $('html, body').scrollTop(),
            _topbarHeight = this.$el.navbarCustom.outerHeight(),
            _stickyTopHeight;

        var _newTop = _offset.top <= _topbarHeight ? _topbarHeight : _offset.top - _topbarHeight;

        if (this.$el.contentStickableTop.length > 0) {
            _stickyTopHeight = $(this.$el.contentStickableTop.data('aria-labelledby')).height();

            if (this.$el.contentStickableTop.hasClass('sticky')) {
                _newTop -= this.$el.contentStickableTop.outerHeight();
            } else {
                if (_offset.top - _stickyTopHeight <= _topbarHeight + this.$el.contentStickableTop.outerHeight()) {
                    _newTop = 0;
                } else {
                    _newTop -= this.$el.contentStickableTop.outerHeight() + _stickyTopHeight;
                }
            }
        }

        $('html, body').animate({
                scrollTop: _newTop
            },
            400,
            function () {
                $(elToFocus).focus();
            });
    },

    //initilizing
    App.prototype.init = function () {
        var $this = this;
        this.initLayout();
        this.initMenu();
        this.handleStickyActions();
        $.Portlet.init();
        $.Components.init();
        $.FormAdvanced.init();
        $.FormPickers.init();

        // on window resize, make menu flipped automatically
        $this.$window.off('resize').on('resize', function (e) {
            e.preventDefault();

            $this.adjustLayout();
            $this._resetSidebarScroll();

            setTimeout(function(){
                $this.sticky.forceUpdate = true;
                $('html,body').scroll();
            }, 400)
        });
    },

    $.App = new App, $.App.Constructor = App


}(window.jQuery)
//initializing main application module

// * !!! IMPORTANT: Removed here because async loading partial views
// * We will call again when rendering done, in temp.js
// * TODO: Please INCLUDE this in backend

 ,function ($) {
     "use strict";
     $.App.init();
 }(window.jQuery);







// TODO: Confirm again if DK want to use this effect
// Waves Effect
// Waves.init();