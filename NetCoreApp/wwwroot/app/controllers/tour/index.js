let tourController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadCategoryType();
        loadData(true);
        
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

        $('body').on('click', '#lbtEdit', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            let id = $(this).attr('data-id');

            $.ajax({
                type: "POST",
                url: "/admin/tour/GetById",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
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
                    $("#txtTimeTour").val(response.timeTour);
                    $("#txtDateStart").val(response.dateStart);
                    $("#hidImage").val(response.Image);
                    if (response.image !== null) {
                        $("#image-holder").html('<img class="img-thumbnail-max400" src=' + response.image + '><br><a href="#" id="hplRemoveImg" data-id=' + response.id + '><i class="fa fa-trash" aria-hidden="true"></i> xóa ảnh</a>');
                    }
                    $("#txtTransPort").val(response.transPort);
                    $("#txtGift").val(response.gift);
                    $("#txtPreview").summernote('code', response.preview);
                    $("#txtService").summernote('code', response.service);
                    $("#txtServiceConten").summernote('code', response.serviceConten);
                    $("#txtServiceNotConten").summernote('code', response.serviceNotConten);
                    $("#txtCreateDate").val(moment(response.dateCreated).format("DD/MM/YYYY hh:mm"));
                    $("#ckStatus").prop("checked", response.status);
                    $("#ckShowHome").prop("checked", response.homeStatus);
                    $("#hidCreateById").val(response.createById);
                    $("#hidEditById").val(response.editById);

                    let templateWithData = Mustache.render($("#images-template").html(),{
                        imagesTag: response.tourImages
                    });
                    $("#list-image").empty().html(templateWithData);
                   
                },
                error: function (status) {
                    until.notify('Lỗi không xem được', 'error' + status);
                    until.stopLoading();
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
                        url: "/admin/Tour/DeleteImge",
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
                        url: "/admin/Tour/DeleteImageTour",
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

        $('body').on('click', '#lbtDelete', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            bootbox.confirm('Bạn có muốn xóa không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Tour/Delete",
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

                        let checkItem = $(this).find("input:checked");
                        if (checkItem.is(":checked")) {
                            listId.push($(this).find('a').last().attr('data-id'));
                        }

                    });

                    $.ajax({
                        type: "DELETE",
                        url: "/admin/Tour/DeleteByListId",
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

        $('body').on('click', '#addTour', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            loadCategoriesTotree();
            
        });

        $('body').on('click', '#btnStatus', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/tour/UpdateStatus",
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
        $('body').on('click', '#btnHomeStatus', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/tour/UpdateHomeStatus",
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
                    txtTimeTour: {
                        required: true
                    },
                    txtService: {
                        required: true
                    },
                    txtServiceConten: {
                        required: true
                    },
                    txtServiceNotConten: {
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
    // láy danh sách các danh mục lên để tìm kiếm
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
            type: 'POST',           
            dataType: 'json',
            data: {                
                name: $('#txtSearch').val(),
                cateogryId: $('#slCategory').val(),
                pageIndex: until.configs.pageIndex,
                pageSize: until.configs.pageSize
            },
            url: '/admin/tour/GetAllPaging',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let templateWithData = Mustache.render($("#mp_template").html(), {
                    tourTag: response.results,
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

        $("#hidId").val(0);
        $("#txtName").val('');
        loadCategoriesTotree();
        $("#hidCategoryId").val(0);
        $("#txtSeoPageTitle").val('');
        $("#txtSeoAlias").val('');
        $("#txtSeoKeyword").val('');
        $("#txtSeoDescription").val('');
        $("#txtOrder").val(0);
        $("#txtHomeOrder").val(0);
        $("#txtPrice").val(0);
        $("#txtTimeTour").val('');
        $("#txtDateStart").val('');
        $("#txtTransPort").val('');
        $("#txtGift").val('');
        $("#txtPreview").summernote('code', '');
        $("#txtService").summernote('code', '');
        $("#txtServiceConten").summernote('code', '');
        $("#txtServiceNotConten").summernote('code', '');
        $("#ckStatus").prop("checked", false);
        $("#ckShowHome").prop("checked", false);
    }

    let AddEditAction = function () {

        let formData = new FormData();
        formData.append("Id", $("#hidId").val());
        formData.append("Name", $("#txtName").val());
        formData.append("Preview", $("#txtPreview").val());
        formData.append("CategoryId", $("#hidCategoryId").val());
        formData.append("Order", $("#txtOrder").val());
        formData.append("HomeOrder", $("#txtHomeOrder").val());        
        formData.append("HomeStatus", $('#ckShowHome').prop('checked'));
        formData.append("Price", $("#txtPrice").val());
        formData.append("TimeTour", $("#txtTimeTour").val());
        formData.append("DateStart", $("#txtDateStart").val());
        formData.append("TransPort", $("#txtTransPort").val());
        formData.append("Service", $("#txtService").val());
        formData.append("Gift", $("#txtGift").val());
        formData.append("ServiceConten", $("#txtServiceConten").val());
        formData.append("ServiceNotConten", $("#txtServiceNotConten").val());
        formData.append("Image", $("#hidImage").val());
        formData.append("Status", $("#ckStatus").prop('checked'));
        formData.append("SeoPageTitle", $("#txtSeoPageTitle").val());
        formData.append("SeoAlias", $("#txtSeoAlias").val());
        formData.append("SeoKeywords", $("#txtSeoKeyword").val());
        formData.append("SeoDescription", $("#txtSeoDescription").val());
        formData.append("DateCreated", $("#txtCreateDate").val());
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
            url: "/admin/tour/SaveEntity",
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