﻿let productController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadData(true);
        //loadCategoriesTotree();
        loadCategoryType();
    }

    let registerEvents = function () { 
        
        $('#slChangPage').on('change', function () {          
            until.configs.pageSize = $(this).val();
            until.configs.pageIndex = 1;
            loadData(true);
        });

        $("#txtName").on('keypress', function (e) {
            let title = until.removeVietnamese($("#txtName").val());
            $("#txtSeoAlias").val(title);
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
        $('body').on('click', '#addProduct', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            loadCategoriesTotree();
        });

        $('body').on('click', '#btnDeleteAll', function (e) {
            e.preventDefault();
            let listId = new Array();
            bootbox.confirm('Bạn có muốn xóa các hàng được chọn không?', function (result) {
                if (result) {
                    $("#tblList tbody tr").each(function () {

                        let checkItem = $(this).find("input:checked");
                        if (checkItem.is(":checked")) {
                            listId.push($(this).find('a').last().attr('data-id'));
                        }

                    });

                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Product/DeleteByListId",
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

        // validator add and Edit
        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {
                    AddEditAction();
                }
            });
            $('#frmMaintainance').validate({
                rules: {
                    txtName: {
                        required: true
                    },
                    txtSeoPageTitle: {
                        required: true
                    },
                    txtSeoAlias: {
                        required: true
                    },
                    txtSeoKeyword: {
                        required: true
                    },
                    txtSeoDescription: {
                        required: true
                    },
                    txtOrder: {
                        required: true,
                        digits: true
                    },
                    txtHomeOrder: {
                        required: true,
                        digits: true
                    },
                    txtPrice: {
                        required: true,
                        digits: true
                    },
                    txtPromotionPrice: {
                        required: true,
                        digits: true
                    },
                    txtOriginalPrice: {
                        required: true,
                        digits: true
                    },
                    txtUnit: {
                        required: true
                    },
                    txtDescription: {
                        required: true
                    },
                    txtContent: {
                        required: true
                    },
                    txtCreateDate: {
                        required: true
                    }
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

    function loadCategoryType() {
        let typeId = $("#hidCategoryType").val();
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/admin/category/index/' + typeId,
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let render = "<option value='0'>Chọn loại danh mục</option>";
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

    function loadCategoriesTotree(selectID) {
        let typeId = $("#hidCategoryType").val();
        $.ajax({
            type: 'GET',
            dataType: 'json',
            cache: false,
            url: '/admin/category/index/' + typeId,
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                comboTree1 = $('#ddlCategory').comboTree({ isMultiple: false });
                comboTree1.clearSelection();
                comboTree1.setSource(until.createTreeSub(response));
                if (selectID !== undefined) {
                    comboTree1.setSelection([selectID]);
                }
                comboTree1.onChange(function () {
                    $('#hidCategoryId').val(comboTree1.getSelectedIds());
                });

                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }


    let loadData = function (isPageChanged) {
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
                let templateWithData = Mustache.render($("#mp_template").html(), {
                    productTag: response.results,
                    dateFormat: function () {
                        return function (timestamp, render) {
                            return new Date(render(timestamp).trim()).toLocaleString('en-GB', { timeZone: 'UTC' });
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

    function resetFormMaintainance() {      
        loadCategoriesTotree();       
        $("#hidId").val(0);
        $("#txtName").val('');
        $("#hidCategoryId").val(0);
        $("#hidImage").val('');
        $("#txtPrice").val(0);
        $("#txtPromotionPrice").val(0);
        $("#txtOriginalPrice").val(0);
        $("#txtDescription").summernote('code','');
        $('#txtContent').summernote('code','');
        $('#ckHomeFlag').prop('checked', false);
        $('#ckHotFlag').prop('checked', false);
        $("hidViewCount").val(0);
        $("#txtOrder").val(0);
        $("#txtHomeOrder").val(0);
        $("#txtTags").val('');
        $("#txtUnit").val('');
        $("#txtSeoPageTitle").val('');
        $("#txtSeoAlias").val('');
        $("#txtSeoKeyword").val('');
        $("#txtSeoDescription").val('');
        $("#txtCreateDate").val('');
        $("#ckStatus").prop('checked', false);
        $("#hidCreateById").val('');
        $("#hidEditById").val('');
    }

    let AddEditAction = function () {
        //let status = $('#ckStatus').prop('checked') === true ? 1 : 0;

        let formData = new FormData();
        formData.append("Id", $("#hidId").val());
        formData.append("Name", $("#txtName").val());
        formData.append("CategoryId", $("#hidCategoryId").val());
        formData.append("Image", $("#hidImage").val());
        formData.append("Price", $("#txtPrice").val());
        formData.append("PromotionPrice", $("#txtPromotionPrice").val());
        formData.append("OriginalPrice", $("#txtOriginalPrice").val());
        formData.append("Description", $("#txtDescription").summernote('code'));
        formData.append("Content", $('#txtContent').summernote('code'));
        formData.append("HomeFlag", $('#ckHomeFlag').prop('checked'));
        formData.append("HotFlag", $('#ckHotFlag').prop('checked'));
        formData.append("ViewCount", $("hidViewCount").val());
        formData.append("Order", $("#txtOrder").val());
        formData.append("HomeOrder", $("#txtHomeOrder").val());
        formData.append("Tags", $("#txtTags").val());
        formData.append("Unit", $("#txtUnit").val());
        formData.append("SeoPageTitle", $("#txtSeoPageTitle").val());
        formData.append("SeoAlias", $("#txtSeoAlias").val());
        formData.append("SeoKeywords", $("#txtSeoKeyword").val());
        formData.append("SeoDescription", $("#txtSeoDescription").val());       
        formData.append("DateCreated", $("#txtCreateDate").val());        
        formData.append("Status", $("#ckStatus").prop('checked'));
        formData.append("CreateById", $("#hidCreateById").val());
        formData.append("EditById", $("#hidEditById").val());
        formData.append("file", $("#fuImage")[0].files[0]);

        let totalFiles = document.getElementById("fuImageList").files.length;
        for (let i = 0; i < totalFiles; i++) {
            let file = document.getElementById("fuImageList").files[i];
            formData.append("files", file);
        }

        let id = $("#hidId").val();

        $.ajax({
            type: "POST",
            url: "/admin/Product/SaveEntity",
            data: formData,
            processData: false,
            contentType: false,
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
                loadData();
            },
            error: function (err) {
                console.log(err);
                until.notify('Lỗi không cập nhập hoặc thêm mới được!' + JSON.stringify(err), 'error');
                until.stopLoading();
            }
        });
    }
}

$(document).ready(function () {    

    $("#checkAll").change(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });

    $.datetimepicker.setLocale('vi');
    $('#txtCreateDate').datetimepicker({
        format: 'd/m/Y h:m',
        mask: true
    });
});