let roleController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadData(true);
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
                type: "GET",
                url: "/admin/Role/GetById",
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
                    $("#txtDescription").val(response.description);
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
                        url: "/admin/Role/Delete",
                        cache: false,
                        data: { id: id },                        
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

        $('body').on('click', '#lbtAddUser', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');           
        });       

        // show list role Permisstion
        $('body').on('click', '#lbtEditRole', function (e) {
            e.preventDefault();
            $('#modalRoleEdit').modal('show');                        
            $('#hidRoleId').val($(this).data('id'));
            $.when(loadFunctionList()).done(fillPermisstion($('#hidRoleId').val()));
        });

        $("#btnSavePermission").off('click').on('click', function () {
            let listPermmission = [];
            $.each($('#tblFunction tbody tr'), function (i, item) {
                listPermmission.push({
                    RoleId: $('#hidRoleId').val(),
                    FunctionId: $(item).data('id'),
                    CanRead: $(item).find('.ckView').first().prop('checked'),
                    CanCreate: $(item).find('.ckAdd').first().prop('checked'),
                    CanUpdate: $(item).find('.ckEdit').first().prop('checked'),
                    CanDelete: $(item).find('.ckDelete').first().prop('checked'),
                });
            });
            $.ajax({
                type: "POST",
                url: "/admin/role/SavePermission",
                data: {
                    listPermmission: listPermmission,
                    roleId: $('#hidRoleId').val()
                },
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    tedu.stopLoading();
                    until.notify('Cập nhật quyền thành công!', 'success');
                    $('#modalRoleEdit').modal('hide');                    
                },
                error: function () {
                    until.notify('Lỗi trong cập nhật quyền', 'error');
                    until.stopLoading();
                }
            });
        });
    
        // validator add and Edit
        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {
                    AddEdit();
                }
            });
            $('#frmAddEdit').validate({
                rules: {
                    txtName: {
                        required: true
                    },
                    txtDescription: {
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
    
    let AddEdit = function () {
        let id = $("#hidId").val();
        let name = $("#txtName").val();
        let description = $("#txtDescription").val();
       
        let dataPost = {
            "Id": id,
            "Name": name,
            "Description": description
        };

        $.ajax({
            type: "POST",
            url: "/admin/Role/SaveEntity",
            data: dataPost,
            dataType: "json",
            async: true,
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                if (id.length > 0) {
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
                until.notify('Lỗi không cập nhập hoặc thêm mới được!' + JSON.stringify(err), 'error');
                until.stopLoading();
            }
        });
    }

    function resetFormMaintainance() {
        $("#hidId").val('');
        $("#txtName").val('');
        $("#txtDescription").val('');
    }
    function loadFunctionList(callback) {        
        $.ajax({
            type: "GET",
            url: "/admin/Function/GetAll",
            dataType: "json",
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let template = $('#result-data-function').html();
                let render = "";
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Name: item.name,
                        treegridparent: item.parentId !== null ? "treegrid-parent-" + item.parentId : "",
                        Id: item.id,
                        AllowCreate: item.allowCreate ? "checked" : "",
                        AllowEdit: item.allowEdit ? "checked" : "",
                        AllowView: item.allowView ? "checked" : "",
                        AllowDelete: item.allowDelete ? "checked" : "",
                        Status: item.status,
                    });
                });
                if (render !== undefined) {
                    $('#lst-data-function').empty().html(render);
                }
                $('#tblFunction').treegrid();

                $('#ckCheckAllView').on('click', function () {
                    $('.ckView').prop('checked', $(this).prop('checked'));
                });

                $('#ckCheckAllCreate').on('click', function () {
                    $('.ckAdd').prop('checked', $(this).prop('checked'));
                });
                $('#ckCheckAllEdit').on('click', function () {
                    $('.ckEdit').prop('checked', $(this).prop('checked'));
                });
                $('#ckCheckAllDelete').on('click', function () {
                    $('.ckDelete').prop('checked', $(this).prop('checked'));
                });

                $('.ckView').on('click', function () {
                    if ($('.ckView:checked').length === response.length) {
                        $('#ckCheckAllView').prop('checked', true);
                    } else {
                        $('#ckCheckAllView').prop('checked', false);
                    }
                });
                $('.ckAdd').on('click', function () {
                    if ($('.ckAdd:checked').length === response.length) {
                        $('#ckCheckAllCreate').prop('checked', true);
                    } else {
                        $('#ckCheckAllCreate').prop('checked', false);
                    }
                });
                $('.ckEdit').on('click', function () {
                    if ($('.ckEdit:checked').length === response.length) {
                        $('#ckCheckAllEdit').prop('checked', true);
                    } else {
                        $('#ckCheckAllEdit').prop('checked', false);
                    }
                });
                $('.ckDelete').on('click', function () {
                    if ($('.ckDelete:checked').length === response.length) {
                        $('#ckCheckAllDelete').prop('checked', true);
                    } else {
                        $('#ckCheckAllDelete').prop('checked', false);
                    }
                });
                if (callback !== undefined) {
                    callback();
                }
                until.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    }
    let fillPermisstion = function (roleId) {
        $.ajax({
            type: "POST",
            url: "/admin/Role/ListAllFunction",
            data: {
                roleId: roleId
            },
            dataType: "json",
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {

                console.log(response);

                let litsPermission = response;
                $.each($('#tblFunction tbody tr'), function (i, item) {
                    $.each(litsPermission, function (j, jitem) {
                        if (jitem.FunctionId === $(item).data('id')) {
                            $(item).find('.ckView').first().prop('checked', jitem.canRead);
                            $(item).find('.ckAdd').first().prop('checked', jitem.canCreate);
                            $(item).find('.ckEdit').first().prop('checked', jitem.canUpdate);
                            $(item).find('.ckDelete').first().prop('checked', jitem.canDelete);
                        }
                    });
                });

                if ($('.ckView:checked').length === $('#tblFunction tbody tr .ckView').length) {
                    $('#ckCheckAllView').prop('checked', true);
                } else {
                    $('#ckCheckAllView').prop('checked', false);
                }
                if ($('.ckAdd:checked').length === $('#tblFunction tbody tr .ckAdd').length) {
                    $('#ckCheckAllCreate').prop('checked', true);
                } else {
                    $('#ckCheckAllCreate').prop('checked', false);
                }
                if ($('.ckEdit:checked').length === $('#tblFunction tbody tr .ckEdit').length) {
                    $('#ckCheckAllEdit').prop('checked', true);
                } else {
                    $('#ckCheckAllEdit').prop('checked', false);
                }
                if ($('.ckDelete:checked').length === $('#tblFunction tbody tr .ckDelete').length) {
                    $('#ckCheckAllDelete').prop('checked', true);
                } else {
                    $('#ckCheckAllDelete').prop('checked', false);
                }
                until.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    }

    let loadData = function (isPageChanged) {
        $.ajax({
            type: 'GET',           
            dataType: 'json',
            data: {               
                keyword: $('#txtSearch').val(),
                page: until.configs.pageIndex,
                pageSize: until.configs.pageSize
            },
            url: '/admin/Role/GetAllPaging',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {               
                let templateWithData = Mustache.render($("#mp_template").html(), {
                    rolesTag: response.results,
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
    
}