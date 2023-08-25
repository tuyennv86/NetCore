let categoryTypeController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadData(true);
        updateOrder();
    }

    let registerEvents = function () {
       
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
        
        $('body').on('click', '#lbtEdit', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            let id = $(this).attr('data-id');

            $.ajax({
                type: "POST",
                url: "/admin/categoryType/GetById",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.stopLoading();
                    $("#hiId").val(response.id);
                    $("#txtName").val(response.name);
                    $("#txtOrder").val(response.sortOrder);
                    $("#ckStatus").prop("checked", response.status);
                },
                error: function (status) {
                    until.notify('Lỗi không xem được', 'error' + status);
                    until.stopLoading();
                }
            });
        });

        $('body').on('click', '#lbtDelete', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "POST",
                        url: "/admin/categoryType/Delete",
                        cache: false,
                        data: { id: id },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa thành công', 'success');
                            until.stopLoading();
                            loadData();
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
            let listId = new Array();
            bootbox.confirm('Bạn có muốn xóa các hàng được chọn không?', function (result) {
                if (result) {
                    $("#tblList tbody tr").each(function () {

                        var checkItem = $(this).find("input:checked");
                        if (checkItem.is(":checked")) {
                            listId.push($(this).find('a').last().attr('data-id'));
                        }

                    });

                    $.ajax({
                        type: "POST",
                        url: "/admin/categoryType/DeleteByListID",
                        cache: false,
                        data: { listId: listId },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa thành công', 'success');
                            until.stopLoading();
                            loadData();
                        },
                        error: function (status) {
                            until.notify('Lỗi không xóa được', 'error' + status);
                            until.stopLoading();
                        }
                    });
                }
            });
        });

        $('body').on('click', '#addCategory', function (e) {
            e.preventDefault();            
            $('#modalAddEdit').modal('show');
        });

        // validator add and Edit
        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {
                    AddEditType();
                }
            });
            $('#frmAddEdit').validate({
                rules: {
                    txtName: {
                        required: true                       
                    },
                    txtOrder: {
                        required: true,
                        digits: true
                    },
                },                
                errorElement: 'span',
                errorPlacement: function (error, element) {
                    error.addClass('invalid-feedback');
                    element.closest('.form-group .col-sm-10').append(error);
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
    

    let loadData = function (isPageChanged) {
        $.ajax({
            type: 'GET',           
            dataType: 'json',
            data: {             
                keyWord: $('#txtSearch').val(),
                page: until.configs.pageIndex,
                pageSize: until.configs.pageSize
            },
            url: '/admin/categoryType/GetByPageding',
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
        let totalsize = Math.ceil(recordCount / until.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }
        //$('#pagination').twbsPagination('destroy');
        //Bind Pagination Event
        $('#pagination').twbsPagination({            
            totalPages: (totalsize === 0) ? 1 : totalsize,
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
    

    function updateOrder() {

        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {

                    $("#tblList tbody tr").each(function () {
                        let sortorder = $(this).find("input").eq(1).val();                     
                        let id = $(this).find('a').last().attr('data-id');

                        $.ajax({
                            type: "POST",
                            url: "/admin/categoryType/UpdateOrder",
                            cache: false,
                            data: { Id: id, sortOrder: sortorder },
                            dataType: "json",
                            beforeSend: function () {
                                until.startLoading();
                            },
                            success: function (response) {
                                until.notify('Cập nhật thành công', 'success');
                                until.stopLoading();
                                loadData();
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

    let AddEditType = function () {
        let id = $("#hiId").val();
        let name = $("#txtName").val();
        let sortOrder = $("#txtOrder").val();
        let isDeleted = $('#ckStatus').prop('checked');

        let dataPost = {
            "Id": id,
            "Name": name,
            "SortOrder": sortOrder,
            "IsDeleted": isDeleted,
            "DateCreated": Date(),
            "DateModified": Date()
        };
        $.ajax({
            type: "POST",
            url: "/admin/categoryType/SaveEntity",
            data: dataPost,
            dataType: "json",
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                if (id > 0) {
                    until.notify('Cập nhật thành công', 'success');
                    resetFormMaintainance();
                    $('#modalAddEdit').modal('hide');
                } else {
                    until.notify('Thêm mới thành công', 'success');
                    resetFormMaintainance();                                       
                }
                until.stopLoading();
                loadData(true);
            },
            error: function () {
                until.notify('Lỗi không cập nhập hoặc thêm mới được!', 'error');
                until.stopLoading();
            }
        });
    }

    function resetFormMaintainance() {
        $('#hiId').val(0);
        $('#txtName').val('');
        $('#txtOrder').val('');
        $('#ckStatus').prop('checked', false);
    }
}

$(document).ready(function () {    

    $("#checkAll").change(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });    

});