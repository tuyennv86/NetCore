let categoryController = function () {

    this.initialize = function () {
        loadCategoryType();
        loadCategories();
        registerEvents();
        updateOrder();
    }

    let registerEvents = function () {
        $('#slcategoryType').on('change', function () {
            loadCategories();
        });

        $("#btnSearch").on('click', function () {
            loadCategories();
        });

        $("#txtName").on('keypress', function (e) {
            let title = until.removeVietnamese($("#txtName").val());
            $("#txtSeoAlias").val(title);
        });

        $("#txtSearch").on('keypress', function (e) {
            if (e.which === 13) {
                e.preventDefault();
                loadCategories();
            }
        });

        $("#checkAll").change(function () {
            $('input:checkbox').not(this).prop('checked', this.checked);
        });

        $('#addCategory').off('click').on('click', function () {           
            $('#modalAddEdit').modal('show');
            viewCategoryType(-1);
            loadCategoriesTotree();

        });

        $('body').on('click', '#lbtEdit', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            let id = $(this).attr('data-id');
            
                        
            $.ajax({
                type: "POST",
                url: "/admin/category/GetById",                
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.stopLoading();
                    console.log(response);
                                       
                    loadCategoriesTotree(response.parentId);
                    $("#hidCategoryId").val(response.parentId);
                    viewCategoryType(response.categoryTypeID)
                    $("#hiIdCates").val(response.id);
                    $("#txtName").val(response.name);
                    $("#txtDescription").val(response.description);
                    $("#hidCategoryId").val(response.parentId);                    
                    $("#txtHomeOrder").val(response.homeOrder);
                    $("#hidImage").val(response.image);
                    $('#ckShowHome').prop('checked', response.homeFlag);
                    $("#txtOrder").val(response.sortOrder);
                    $("#ckStatus").prop('checked', response.status);
                    $("#txtSeoPageTitle").val(response.seoPageTitle);
                    $("#txtSeoAlias").val(response.seoAlias);
                    $("#txtSeoKeyword").val(response.seoKeywords);
                    $("#txtSeoDescription").val(response.seoKeywords);                    
                    $('#txtDetail').summernote('code', response.detail);
                    $('#hplRemoveImg').attr('href', response.id);
                    $("#image-holder").html('<img class="img-thumbnail" src=' + response.image + '>');
                },
                error: function (status) {
                    until.notify('Lỗi không load được dữ liệu', 'error' + status);
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
                        url: "/admin/category/Delete",
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
                        type: "POST",
                        url: "/admin/category/DeleteByListID",
                        cache: false,
                        data: { listId: listId },
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

        $('body').on('click', '#btnStatus', function (e) {
            e.preventDefault();
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/Category/UpdateStatus",
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
            let id = $(this).attr('data-id');
            $.ajax({
                type: "POST",
                url: "/admin/Category/UpdateHomeFalg",
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

        // remove Img
        $('body').on('click', '#hplRemoveImg', function (e) {
            e.preventDefault();
            let id = $(this).attr('href');
            bootbox.confirm('Bạn có muốn xóa ảnh này không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "POST",
                        url: "/admin/category/DeleteImage",
                        cache: false,
                        data: { Id: id },
                        dataType: "json",
                        beforeSend: function () {
                            until.startLoading();
                        },
                        success: function (response) {
                            until.notify('Xóa ảnh thành công', 'success');
                            $("#image-holder").html('');
                            loadCategories();
                            until.stopLoading();
                        },
                        error: function (status) {
                            until.notify('Lỗi không xóa được', 'error' + status);                           
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
                    txtSeoAlias: {
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

        //view anh khi chọn
        $('body').on('change', "#fuImage", function () {

            if (typeof (FileReader) !== "undefined") {
                let image_holder = $("#image-holder");
                image_holder.empty();
                let reader = new FileReader();
                reader.onload = function (e) {
                    $("<img />", {
                        "src": e.target.result,
                        "class": "img-thumbnail",
                        "width":"250px"
                    }).appendTo(image_holder);
                }
                image_holder.show();
                reader.readAsDataURL($(this)[0].files[0]);
                $("#hidImage").val($(this)[0].files[0].name);
            } else {
                alert("This browser does not support FileReader.");
            }
        });
    }
    // load chủng loại danh mục tìm kiếm hiển thị
    function loadCategoryType() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/admin/CategoryType/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let render = "<option value='0'>Chọn loại danh mục</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.id + "'>" + item.name + "</option>"
                });
                $('#slcategoryType').html(render);
                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }
    // view chủng loại danh mục thêm sửa
    function viewCategoryType(id) {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/admin/CategoryType/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.id + "'>" + item.name + "</option>"
                });
                $('#slcategoryTypeAdd').html(render);
                $("#slcategoryTypeAdd > option[value=" + id + "]").prop("selected", true);
                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }
    // load danh sách các danh mục
    function loadCategories() {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            cache: false,
            url: '/admin/Category/GetByTypeAndKeyWord',
            data: {
                keyWord: $("#txtSearch").val(),
                categoryTypeID: $("#slcategoryType").val()
            },
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {

                //console.log(response);

                let templateWithData = Mustache.render($("#mp_template").html(), {
                    categoryTag: recursiveArraySort(response),
                    dateFormat: function () {
                        return function (timestamp, render) {
                            return new Date(render(timestamp).trim()).toLocaleString('en-GB', { timeZone: 'UTC' });
                        };
                    }
                });
                $("#tpl_content").empty().html(templateWithData);
                $('#tblList').simpleTreeTable({
                    expander: $('#expander'),
                    collapser: $('#collapser'),

                });

                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }       

    // load danh sách các danh mục
    function loadCategoriesTotree(selectID) {

        $.ajax({
            type: 'GET',
            dataType: 'json',
            cache: false,
            url: '/admin/Category/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                comboTree1 = $('#ddlCategory').comboTree({ isMultiple: false});
               
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
    
    const recursiveArraySort = (list, parent = { id: 0, level: 0 }) => {
        let result = [];      
        const children = list.filter(item => item.parentId === parent.id);       
        children.forEach(child => {
            child.level = parent.level + 1;
            result = [...result, child, ...recursiveArraySort(list, child)];
        });
        return result;
    };

    function updateOrder() {

        $(function () {
            $.validator.setDefaults({
                submitHandler: function () { 
                   
                    $("#tblList tbody tr").each(function () {
                        let sortorder = $(this).find("input").eq(1).val();                        
                        let homeorder = $(this).find("input").eq(2).val();
                        let id = $(this).find('a').last().attr('data-id');  

                        $.ajax({
                            type: "POST",
                            url: "/admin/Category/UpdateOrder",
                            cache: false,
                            data: { Id: id, homeOrder: homeorder, sortOrder: sortorder },
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

    
    let AddEditAction = function () {

        let formData = new FormData();
        formData.append("Id", $("#hiIdCates").val());
        formData.append("Name", $("#txtName").val());
        formData.append("Description", $("#txtDescription").val());
        formData.append("ParentId", $("#hidCategoryId").val());
        formData.append("CategoryTypeID", $("#slcategoryTypeAdd").val());
        formData.append("HomeOrder", $("#txtHomeOrder").val());
        formData.append("Image", $("#hidImage").val());
        formData.append("HomeFlag", $('#ckShowHome').prop('checked'));
        formData.append("SortOrder", $("#txtOrder").val());
        formData.append("Status", $("#ckStatus").prop('checked'));
        formData.append("SeoPageTitle", $("#txtSeoPageTitle").val());
        formData.append("SeoAlias", $("#txtSeoAlias").val());
        formData.append("SeoKeywords", $("#txtSeoKeyword").val());
        formData.append("SeoDescription", $("#txtSeoDescription").val());
        formData.append("Detail", $("#txtDetail").val());
        formData.append("filesImg", $("#fuImage")[0].files[0]);

        let id = $("#hiIdCates").val();

        $.ajax({
            type: "POST",
            url: "/admin/Category/SaveEntity",
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
                loadCategories();
                loadCategoriesTotree();
            },
            error: function (err) {
                until.notify('Lỗi không cập nhập hoặc thêm mới được!' + JSON.stringify(err), 'error');
                until.stopLoading();
            }
        });
    }

    function resetFormMaintainance() {
        $("#hiIdCates").val(0);
        $("#txtName").val('');
        $("#txtDescription").val('');
        $("#hidCategoryId").val(0);
        $("#slcategoryTypeAdd").val('0');
        $("#txtOrder").val('');
        $("#txtHomeOrder").val('');
        $("#hidImage").val('');
        $('#ckShowHome').prop('checked', false);
        $("#ckStatus").prop('checked', false);
        $("#txtSeoPageTitle").val('');
        $("#txtSeoAlias").val('');
        $("#txtSeoKeyword").val('');
        $("#txtSeoDescription").val('');
        $('#txtDetail').summernote('code', '');
        $("#fuImage").val('');
        $("#image-holder").html('');        
    }

}