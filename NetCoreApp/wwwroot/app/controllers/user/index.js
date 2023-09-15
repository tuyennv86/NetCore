let userController = function () {

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
            $('#hplRemoveImg').show();
            let id = $(this).attr('data-id');

            $.ajax({
                type: "GET",
                url: "/admin/User/GetById",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.stopLoading();
                    $("#hidId").val(response.id);
                    $("#txtFullName").val(response.fullName);
                    $("#txtUserName").val(response.userName);
                    $("#txtEmail").val(response.email);
                    $("#txtPhone").val(response.phone);
                    $("#ckStatus").prop("checked", response.status);
                    $("#hidImage").val(response.avatar);                   
                    $('#hplRemoveImg').attr('href', response.id);
                    $("#image-holder").html('<img class="img-thumbnail" src=' + response.avatar + '>');

                    getListRole(response.roles);
                    disableFieldEdit(true);
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
                        url: "/admin/User/Delete",
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
            $('#hplRemoveImg').hide();
            getListRole();
        });

        // remove Img
        $('body').on('click', '#hplRemoveImg', function (e) {
            e.preventDefault();
            let id = $(this).attr('href');
            bootbox.confirm('Bạn có muốn xóa ảnh này không?', function (result) {
                if (result) {
                    $.ajax({
                        type: "POST",
                        url: "/admin/User/DeleteImage",
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
        // View ảnh
        $('body').on('change', "#fuImage", function () {

            if (typeof (FileReader) !== "undefined") {
                let image_holder = $("#image-holder");
                image_holder.empty();
                let reader = new FileReader();
                reader.onload = function (e) {
                    $("<img />", {
                        "src": e.target.result,
                        "class": "img-thumbnail",
                        "width": "250px"
                    }).appendTo(image_holder);
                }
                image_holder.show();
                reader.readAsDataURL($(this)[0].files[0]);
                $("#hidImage").val($(this)[0].files[0].name);
            } else {
                alert("This browser does not support FileReader.");
            }
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
                    txtFullName: {
                        required: true
                    },
                    txtUserName: {
                        required: true
                    },
                    txtPasword: {
                        required: true,
                        minlength: 6
                    },
                    txtConfirmPasword: {
                        required: true,
                        minlength: 6,
                        equalTo: "#txtPasword"
                    },                    
                    txtEmail: {
                        required: true,
                        email: true
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
    function disableFieldEdit(disabled) {
        $('#txtUserName').prop('disabled', disabled);
        $('#txtPasword').prop('disabled', disabled);
        $('#txtConfirmPasword').prop('disabled', disabled);

    }
    let AddEdit = function () {
       
        let id = $("#hidId").val();

        let formData = new FormData();
        formData.append("Id", $("#hidId").val());
        formData.append("FullName", $("#txtFullName").val());
        formData.append("UserName", $("#txtUserName").val());
        formData.append("Email", $("#txtEmail").val());
        formData.append("Password", $("#txtPasword").val());
        formData.append("PhoneNumber", $("#txtPhone").val());
        formData.append("Avatar", $("#hidImage").val());
        $.each($('input[name="ckRoles"]'), function (i, item) {
            if ($(item).prop('checked') === true)                
                formData.append("Roles", $(item).prop('value'));
        });
        formData.append("Status", $("#ckStatus").prop('checked') === true ? 1 : 0);
        formData.append("DateCreated", Date());
        formData.append("DateModified", Date());
        formData.append("filesImg", $("#fuImage")[0].files[0]);       

        $.ajax({
            type: "POST",
            url: "/admin/User/SaveEntity",
            data: formData,
            processData: false,
            contentType: false,
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
        $("#hidId").val(0);
        $("#txtFullName").val('');
        $("#txtUserName").val('');
        $("#txtPasword").val('');
        $("#txtConfirmPasword").val('');
        $("#txtEmail").val('');
        $("#txtPhone").val('');
        $("#hidImage").val('');
        $("#ckStatus").prop('checked', false);        
        $("#fuImage").val('');
        $("#image-holder").html('');
        $('input[name="ckRoles"]').prop('checked', false);
    }

    function getListRole(selectedRoles) {
        $.ajax({
            type: "GET",
            url: "/admin/Role/GetAll",
            cache: false,            
            dataType: "json",            
            success: function (response) {
                let template = $('#role-template').html();
                let data = response;
                let render = '';
                $.each(data, function (i, item) {
                    let checked = '';
                    if (selectedRoles !== undefined && selectedRoles.indexOf(item.name) !== -1) {
                        checked = 'checked';
                    }
                    render += Mustache.render(template, {
                            Name: item.name,
                            Description: item.description + '- (' + item.name + ')',
                            Checked: checked
                        });
                });
                $('#list-roles').html(render);
            }
        });
    }

    let loadData = function (isPageChanged) {
        $.ajax({
            type: 'GET',           
            dataType: 'json',
            data: {               
                keyword: $('#txtSearch').val(),
                pageIndex: until.configs.pageIndex,
                pageSize: until.configs.pageSize
            },
            url: '/admin/User/GetAllPaging',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {               
                let templateWithData = Mustache.render($("#mp_template").html(), {
                    userTag: response.results,
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