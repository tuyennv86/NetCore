var categoryTypeController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadData(true);
        updateOrder();
    }

    var registerEvents = function () { 
       

        $('#slChangPage').on('change', function () {          
            until.configs.pageSize = $(this).val();
            until.configs.pageIndex = 1;
            loadData(true);
        });

        $("#btnSearch").on('click', function () {
            loadData(true);
        });
        $("#txtSearch").on('keypress', function (e) {          
            if (e.which === 13) {
                e.preventDefault();
                loadData(true);
            }
        });       

    }
    

    var loadData = function (isPageChanged) {
        $.ajax({
            type: 'GET',           
            dataType: 'json',
            data: {             
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
                    categoryTypeTag: response.results,
                    dateFormat: function () {
                        return function (timestamp, render) {
                            return new Date(render(timestamp).trim()).toLocaleString('en-GB', { timeZone: 'UTC' });
                        };
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
            first: '<i class="fa fa-fast-backward"></i>',
            prev: '<i class="fa fa-angle-double-left"></i>',
            next: '<i class="fa fa-angle-double-right"></i>',
            last: '<i class="fa fa-fast-forward"></i>',
            onPageClick: function (event, page) {                
                until.configs.pageIndex = page;
                setTimeout(callBack(), 200);
            }
        });
    }

    $('body').on('click', '#lbtEdit', function (e) {
        e.preventDefault();
        $('#modalAddEdit').modal('show');
        var id = $(this).attr('data-id');


        $.ajax({
            type: "POST",
            url: "/admin/productcategory/GetByID",
            cache: false,
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                until.stopLoading();
                console.log(response);

                $("#hidCategoryId").val(response.parentId);
                loadCategoriesTotreeBySelectID(response.parentId);

                $("#hidId").val(response.id);
                $("#txtName").val(response.name);
                $("#txtAlias").val(response.seoAlias);
                $("#txtDesc").val(response.description);
                $("#txtSeoKeyword").val(response.seoKeywords);
                $("#txtOrder").val(response.sortOrder);
                $("#txtHomeOrder").val(response.homeOrder);
                $("#hidImage").val(response.image);
                $("#imgImage").attr("src", response.image);
                $("#txtSeoPageTitle").val(response.seoPageTitle);
                $("#txtSeoAlias").val(response.seoAlias);
                $("#txtSeoKeyword").val(response.seoKeywords);
                $("#txtSeoDescription").val(response.seoDescription);
                $("#ckStatus").prop("checked", response.status);
                $("#ckShowHome").prop("checked", response.homeFlag);
            },
            error: function (status) {
                until.notify('Lỗi không xóa được', 'error' + status);
                until.stopLoading();
            }
        });
    });

    $('body').on('click', '#lbtDelete', function (e) {
        e.preventDefault();
        var id = $(this).attr('data-id');
        bootbox.confirm('Bạn có muốn xóa không?', function (result) {
            if (result) {
                $.ajax({
                    type: "POST",
                    url: "/admin/productcategory/DeleteCategoryByID",
                    cache: false,
                    data: { id: id },
                    dataType: "json",
                    beforeSend: function () {
                        until.startLoading();
                    },
                    success: function (response) {
                        until.notify('Xóa thành công', 'success');
                        until.stopLoading();
                        loadCategories();
                    },
                    error: function (status) {
                        until.notify('Lỗi không xóa được', 'error' + status);
                        until.stopLoading();
                    }
                });
            }
        });
    });

    $('body').on('click', '#btnDeleteAll', function (e) {
        e.preventDefault();
        var id = $(this).attr('data-id');
        bootbox.confirm('Bạn có muốn xóa các hàng được chọn không?', function (result) {
            if (result) {
                $("#tblList tbody tr").each(function () {
                    var checkItem = $(this).find("input:checked");
                    var id = $(this).find('a').last().attr('data-id');

                    if (checkItem.is(":checked")) {
                        $.ajax({
                            type: "POST",
                            url: "/admin/productcategory/DeleteCategoryByID",
                            cache: false,
                            data: { id: id },
                            dataType: "json",
                            beforeSend: function () {
                                until.startLoading();
                            },
                            success: function (response) {
                                until.notify('Xóa thành công', 'success');
                                until.stopLoading();
                                loadCategories();
                            },
                            error: function (status) {
                                until.notify('Lỗi không xóa được', 'error' + status);
                                until.stopLoading();
                            }
                        });
                    }

                });
            }
        });
    });

    $('body').on('click', '#btnStatus', function (e) {
        e.preventDefault();
        var id = $(this).attr('data-id');
        $.ajax({
            type: "POST",
            url: "/admin/productcategory/UpdateStatus",
            cache: false,
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                until.notify('Cập nhật trạng thái thành công', 'success');
                until.stopLoading();
                loadCategories();
            },
            error: function (status) {
                until.notify('Lỗi không cập nhật được', 'error' + status);
                until.stopLoading();
            }
        });
    });

    $('body').on('click', '#btnHome', function (e) {
        e.preventDefault();
        var id = $(this).attr('data-id');
        $.ajax({
            type: "POST",
            url: "/admin/productcategory/UpdateHomeFalg",
            cache: false,
            data: { id: id },
            dataType: "json",
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                until.notify('Cập nhật thành công', 'success');
                until.stopLoading();
                loadCategories();
            },
            error: function (status) {
                until.notify('Lỗi không cập nhật được', 'error' + status);
                until.stopLoading();
            }
        });
    });

    function updateOrder() {

        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {

                    $("#tblList tbody tr").each(function () {
                        var sortorder = $(this).find("input").eq(1).val();                     
                        var id = $(this).find('a').last().attr('data-id');

                        $.ajax({
                            type: "POST",
                            url: "/admin/productcategory/UpdateOrder",
                            cache: false,
                            data: { Id: id, sortOrder: sortorder },
                            dataType: "json",
                            beforeSend: function () {
                                until.startLoading();
                            },
                            success: function (response) {
                                until.notify('Cập nhật thành công', 'success');
                                until.stopLoading();
                                loadCategories();
                            },
                            error: function (status) {
                                until.notify('Lỗi cập nhật được được', 'error' + status);
                                until.stopLoading();
                            }
                        });

                    })

                }
            });
            $('#myform').validate({

                errorElement: 'span',
                errorPlacement: function (error, element) {
                    error.addClass('invalid-feedback');
                    element.closest('td').append(error);
                },
                highlight: function (element, errorClass, validClass) {
                    $(element).addClass('is-invalid');
                },
                unhighlight: function (element, errorClass, validClass) {
                    $(element).removeClass('is-invalid');
                }

            });
        });
    }
}

$(document).ready(function () {    

    $("#checkAll").change(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });

});