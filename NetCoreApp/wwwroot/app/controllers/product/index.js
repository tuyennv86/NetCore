let productController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadData(true);        
        loadCategoryType();
        updateOrder();
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
        $('body').on('click', '#btnStatus', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/Product/UpdateStatus",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.notify('Cập nhật trạng thái thành công', 'success');
                    until.stopLoading();
                    loadData();
                },
                error: function (status) {
                    until.notify('Lỗi không cập nhật được', 'error' + status);
                    until.stopLoading();
                }
            });
        });

        $('body').on('click', '#btnHomeFlag', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/Product/UpdateHomeFlag",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.notify('Cập nhật trạng thái thành công', 'success');
                    until.stopLoading();
                    loadData();
                },
                error: function (status) {
                    until.notify('Lỗi không cập nhật được', 'error' + status);
                    until.stopLoading();
                }
            });
        });

        $('body').on('click', '#btnHotFlag', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/Product/UpdateHotFlag",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.notify('Cập nhật trạng thái thành công', 'success');
                    until.stopLoading();
                    loadData();
                },
                error: function (status) {
                    until.notify('Lỗi không cập nhật được', 'error' + status);
                    until.stopLoading();
                }
            });
        });

        $('body').on('click', '#addProduct', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            loadCategoriesTotree();
        });
        $('body').on('click', '#lbtView', function (e) {
            e.preventDefault();
            $('#modalAddEditExten').modal('show');
            let id = $(this).attr('data-id');
            $.ajax({
                type: "GET",
                url: "/admin/Product/GetById",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.stopLoading();
                    $("#hidId").val(response.id);
                    $("#spName").html(response.name);
                },
                error: function (status) {
                    until.notify('Lỗi không xem được' + status, 'error');
                    until.stopLoading();
                }
            });                        

            LoadDataColor();
            LoadDataSize();
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

        $('body').on('click', '#lbtDelete', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Product/Delete",
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
        // xoa anh đại diện Edit
        $('body').on('click', '#hplRemoveImg', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Product/DeleteImge",
                        cache: false,
                        data: { Id: id },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa ảnh thành công', 'success');
                            $("#image-holder").html('');
                            loadData();
                            until.stopLoading();
                        },
                        error: function (status) {
                            until.notify('Lỗi không xóa được', 'error' + status);
                        }
                    });
                }
            });
        });
        // xóa ảnh liên quan khi edit
        $('body').on('click', '#btnDeleteImgDetail', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Product/DeleteImageProduct",
                        cache: false,
                        data: { Id: id },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa ảnh thành công', 'success');
                            $('#li-' + id).remove();
                            until.stopLoading();
                        },
                        error: function (status) {
                            until.notify('Lỗi không xóa được', 'error' + status);
                        }
                    });
                }
            });
        });

        $('body').on('click', '#lbtEdit', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            let id = $(this).attr('data-id');

            $.ajax({
                type: "GET",
                url: "/admin/Product/GetById",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {

                    //console.log(response);

                    until.stopLoading();
                    $("#hidId").val(response.id);
                    $("#txtName").val(response.name);
                    loadCategoriesTotree(response.categoryId);
                    $("#hidCategoryId").val(response.categoryId);
                    $("#txtSeoPageTitle").val(response.seoPageTitle);
                    $("#txtSeoAlias").val(response.seoAlias);
                    $("#txtSeoKeyword").val(response.seoKeywords);
                    $("#txtSeoDescription").val(response.seoDescription);
                    $("#txtOrder").val(response.order);
                    $("#txtHomeOrder").val(response.homeOrder);
                    $("#txtPrice").val(response.price);
                    $("#txtPromotionPrice").val(response.promotionPrice);
                    $("#txtOriginalPrice").val(response.originalPrice);
                    $("#txtUnit").val(response.unit);                   
                    $("#hidImage").val(response.image);
                    if (response.image !== null) {
                        $("#image-holder").html('<img class="img-thumbnail-max400" src=' + response.image + '><br><a href="#" id="hplRemoveImg" data-id=' + response.id + '><i class="fa fa-trash" aria-hidden="true"></i> xóa ảnh</a>');
                    }              
                    $("#txtDescription").summernote('code', response.description);
                    $("#txtContent").summernote('code', response.content);
                    $("#txtTags").val(response.tags);                    
                    $("#txtCreateDate").val(moment(response.dateCreated).format("DD/MM/YYYY hh:mm"));

                    $("#ckStatus").prop("checked", response.status);
                    $("#ckHomeFlag").prop("checked", response.homeFlag);
                    $("#ckHotFlag").prop("checked", response.hotFlag);

                    $("#hidCreateById").val(response.createById);
                    $("#hidEditById").val(response.editById);

                    let templateWithData = Mustache.render($("#images-template").html(), {
                        imagesTag: response.productImages
                    });
                    $("#list-image").empty().html(templateWithData);

                },
                error: function (status) {
                    until.notify('Lỗi không xem được' + status, 'error');
                    until.stopLoading();
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

        $('body').on('click', '#lbtDeleteColor', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Product/DeleteColor",
                        cache: false,
                        data: { id: id },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa thành công', 'success');
                            until.stopLoading();
                            LoadDataColor();
                        },
                        error: function (status) {
                            until.notify('Lỗi không xóa được' + JSON.stringify(status), 'error');
                            until.stopLoading();
                        }
                    });
                }
            });
        });
        $('body').on('click', '#lbtEditColor', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id'); 
                $.ajax({
                    type: "GET",
                    url: "/admin/Product/GetByIdColor",
                    cache: false,
                    data: { id: id },
                    dataType: "json",
                    beforeSend: function () {
                        until.startLoading();
                    },
                    success: function (response) {                       
                        until.stopLoading();
                        $("#hidId").val(response.id);
                        $("#txtColorName").val(response.name);
                        $("#txtColorCode").val(response.code);
                        $('.my-colorpicker2 .fa-square').css('color', response.code);
                    },
                    error: function (status) {
                        until.notify('Lỗi edit' + JSON.stringify(status), 'error');
                        until.stopLoading();
                    }
                });               
        });

        $('body').on('click', '#lbtDeleteSize', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Product/DeleteSize",
                        cache: false,
                        data: { id: id },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa thành công', 'success');
                            until.stopLoading();
                            LoadDataSize();
                        },
                        error: function (status) {
                            until.notify('Lỗi không xóa được' + JSON.stringify(status), 'error');
                            until.stopLoading();
                        }
                    });
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
        $("#fuImageList").val('');
        $("#fuImage").val('');
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

    //update order
    function updateOrder() {
        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {

                    $("#tblList tbody tr").each(function () {
                        let order = $(this).find("input").eq(1).val();
                        let homeorder = $(this).find("input").eq(2).val();
                        let id = $(this).find('a').last().attr('data-id');

                        $.ajax({
                            type: "POST",
                            url: "/admin/Product/UpdateOrder",
                            cache: false,
                            data: { id: id, order: order, homeOrder: homeorder },
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

    function LoadDataColor() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/admin/product/GetAllColor',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let templateWithData = Mustache.render($("#color-template").html(), {
                    colorsTag: response
                });
                $("#list-color").empty().html(templateWithData);
                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu" + status, status);
            }
        });
    }
    function LoadDataSize() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/admin/product/GetAllSize',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let templateWithData = Mustache.render($("#size-template").html(), {
                    sizesTag: response
                });
                $("#list-size").empty().html(templateWithData);
                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu" + status, status);
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