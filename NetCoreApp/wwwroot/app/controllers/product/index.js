var productController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        loadData();
    }

    var loadData = function () {
        $.ajax({
            type: 'GET',           
            dataType: 'json',
            url: '/admin/product/GetAll',
            success: function (response) {
                until.notify("thành công")
                var templateWithData = Mustache.to_html($("#mp_template").html(), { productTag: response });
                $("#tpl_content").empty().html(templateWithData);

            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }
}