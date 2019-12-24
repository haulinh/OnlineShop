var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        jQuery("#txtKeyWord").autocomplete({
            minLength: 0,
            source: function (request, response) {
                jQuery.ajax({
                    url: "/Product/ListName",
                    dataType: "json",
                    data: {
                        q: request.term
                        
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                jQuery("#txtKeyWord").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                jQuery("#txtKeyWord").val(ui.item.label);
                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return jQuery("<li>")
                    .append("<a>" + item.label+ "</a>")
                    .appendTo(ul);
            };
    }
}
common.init();