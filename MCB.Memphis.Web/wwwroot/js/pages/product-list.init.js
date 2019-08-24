/*
MCB
File: Product list
*/

jQuery(document).ready(function () {
    // Summernote
    $('.page-actions .translation').on('click', '.dropdown-item', function (e) {
        e.preventDefault();
        var $this = $(this),
            $parent = $this.closest('.translation'),
            $activeItem = $parent.find('.translation__selected-item');

        $activeItem.html($this.text());
        $parent.find('.dropdown-item').removeClass('active');
        $this.addClass('active');
    })
});