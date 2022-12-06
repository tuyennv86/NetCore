var productController = function () {

    this.initialize = function () {        

        loadData(true);
        registerEvents();
    }

    var registerEvents = function () {        

        //CheckBoxAll();

        $('input[name="checkAll"]').change(function () {
            if ($('input[name="checkAll"]').attr('checked') === 'checked') {
                $('input[name="checkItem"]').attr('checked', true);
            } else {
                $('input[name="checkItem"]').attr('checked', false);
            }
        });

        loadCategories();

        $('#slChangPage').on('change', function () {
            until.configs.pageSize = $(this).val();
            until.configs.pageIndex = 1;
            loadData(true);
        });
        $("#btnSearch").on('click', function () {
            loadData();
        });
        $("#txtSearch").on('keypress', function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadData();
            }
        });
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',           
            url: '/admin/productcategory/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                var render = "<option value=''>--Chọn danh mục--</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.id + "'>" + item.name + "</option>"
                });
                $('#slCategory').html(render);                
                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }

    var loadData = function (isPageChanged) {
        $.ajax({
            type: 'GET',           
            dataType: 'json',
            data: {
                categoryId: $('#slCategory').val(),
                keyword: $('#txtSearch').val(),
                page: until.configs.pageIndex,
                pageSize: until.configs.pageSize
            },
            url: '/admin/product/GetPaging',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {               
                var templateWithData = Mustache.render($("#mp_template").html(), {
                    productTag: response.results,
                    dateFormat: function () {
                        return function (timestamp, render) {
                            return new Date(render(timestamp).trim()).toLocaleString();
                        };
                    },
                    formatCurrency: function () {                        
                        return function (variable, render) {                           
                            return render(variable).toString().replace(/\B(?=(\d{3})+(?!\d))/g, "$&,");
                        }
                    }
                });                
                $("#tpl_content").empty().html(templateWithData);
               
                wrapPaging(response.rowCount, function () {
                    loadData();
                }, isPageChanged);
                
                until.stopLoading();

            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }

    function wrapPaging(recordCount, callBack, changePageSize) {        
        var totalsize = Math.ceil(recordCount / until.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        //Bind Pagination Event
        $('#pagination').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: '<i class="angle double left icon"></i>',
            prev: '<i class="angle left icon"></i>',
            next: '<i class="angle right icon"></i>',
            last: '<i class="angle double right icon"></i>',
            onPageClick: function (event, page) {                
                until.configs.pageIndex = page;
                setTimeout(callBack(), 200);
            }
        });
    }


    //function CheckBoxAll () {
    //    // ID selector on Master Checkbox
    //    var masterCheck = $("#checkall");
    //    // ID selector on Items Container
    //    var listCheckItems = $("#tpl_content :checkbox");

    //    // Click Event on Master Check
    //    masterCheck.on("click", function () {
    //        var isMasterChecked = $(this).is(":checked");
    //        listCheckItems.prop("checked", isMasterChecked);
    //        //getSelectedItems();
    //    });

    //    // Change Event on each item checkbox
    //    listCheckItems.on("change", function () {
    //        // Total Checkboxes in list
    //        var totalItems = listCheckItems.length;
    //        // Total Checked Checkboxes in list
    //        var checkedItems = listCheckItems.filter(":checked").length;

    //        //If all are checked
    //        if (totalItems == checkedItems) {
    //            masterCheck.prop("indeterminate", false);
    //            masterCheck.prop("checked", true);
    //        }
    //        // Not all but only some are checked
    //        else if (checkedItems > 0 && checkedItems < totalItems) {
    //            masterCheck.prop("indeterminate", true);
    //        }
    //        //If none is checked
    //        else {
    //            masterCheck.prop("indeterminate", false);
    //            masterCheck.prop("checked", false);
    //        }            
    //    });                
    //};
    
}