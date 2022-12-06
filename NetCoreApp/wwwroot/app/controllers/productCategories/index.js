var productCategoryController = function () {

    this.initialize = function () {
              
        registerEvents();
    }

    var registerEvents = function () {
        loadCategories();
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            data: {
                parentId: 0
            },
            url: '/admin/productcategory/GetByParent',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                console.log(response);
                //var data = [];
                //$.each(response, function (i, item) {
                //    data.push({
                //        id: item.id,
                //        text: item.name,
                //        parentId: item.parentId,
                //        SortOrder: item.sortOrder,
                //        status: item.status
                //    })
                //});
                //console.log(data);

                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }
}