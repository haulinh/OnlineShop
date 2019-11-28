var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
   
        jQuery('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        jQuery('#btnUpdate').off('click').on('click', function () {
            var listProduct = jQuery('.txtQuantity');
            var cartList = [];
            jQuery.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: jQuery(item).val(),
                    Product: {
                        ID: jQuery(item).data('id')
                    }
                });
            });

            jQuery.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        jQuery('#btnDeleteAll').off('click').on('click', function () {


            jQuery.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        jQuery('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            jQuery.ajax({
                data: { id: jQuery(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
    }
}
cart.init();