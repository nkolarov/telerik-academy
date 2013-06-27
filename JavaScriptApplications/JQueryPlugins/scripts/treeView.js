/*
01. Create a TreeView jQuery Plugin
Initially only the top items must be visible
On item click
If its children are hidden (collapsed), they must be made visible (expanded)
If its children are visible (expanded), they must be made hidden (collapsed)
Research about events
*/

(function ($) {
    $.fn.treeView = function (params) {
        if (!params) {
            var params = {};
        }

        if (!params.speed) {
            params.speed = 1000;
        }
        if (!params.collapsed) {
            params.collapsed = true;
        }

        $(this).click('a',
                      function (ev) {
                          ev.stopPropagation();
                          $(ev.target).find('>ul').toggle(params.speed);
                      });
        if (params.collapsed == true) {
            $(this).find('li>ul').hide();
        } else {
            $(this).find('li>ul').show();
        }
    };
})(jQuery);