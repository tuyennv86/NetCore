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
        let id = $("#hiId").val();
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
            processData: false,
            dataType: "json",
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
        $("#txtName").val('');
        $("#txtDescription").val('');
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