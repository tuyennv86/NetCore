var productCategoryController = function () {

    this.initialize = function () {

        loadCategories();
        registerEvents();
        updateOrder();       
       
    }
   
    function registerEvents() {
        $("#checkAll").change(function () {
            $('input:checkbox').not(this).prop('checked', this.checked);
        });


        $('#addCategory').off('click').on('click', function () {
            $('#modalAddEdit').modal('show');
        });

        $('body').on('click', '#lbtEdit', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            var id = $(this).attr('data-id');
            $('#hiIdCates').val(id);;
            console.log(id);
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
               
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            cache: false,           
            url: '/admin/productcategory/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {                

                //console.log(sortArry(response));

                var templateWithData = Mustache.render($("#mp_template").html(), {                    
                    categoryTag: sortArry(response),
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

    function traverse(list) {
        var html = '<ul>';
        for (var i = 0; i < list.length; i++) {
            html += '<li>' + list[i].Name;
            if (list[i].children) {
                html += traverse(list[i].children);
            }
            html += '</li>';
        }
        html += '</ul>';

        return html;
    }
  /*  sắp xếp mảng */
    function hierarchySortFunc(a, b) {
        return a.name > b.name;
    }

    function hierarhySort(hashArr, key, result) {

        if (hashArr[key] === undefined) return;
        var arr = hashArr[key].sort(hierarchySortFunc);
        for (var i = 0; i < arr.length; i++) {
            result.push(arr[i]);
            hierarhySort(hashArr, arr[i].id, result);
        }
        return result;
    }    

    function sortArry(arr) {

        var hashArr = {};
        for (var i = 0; i < arr.length; i++) {
            if (hashArr[arr[i].parentId] === undefined) hashArr[arr[i].parentId] = [];
            hashArr[arr[i].parentId].push(arr[i]);
        }

        var result = hierarhySort(hashArr, 0, []);
        return result;
    }   

    /*hết sắp xếp */

    function updateOrder() {

        $(function () {
            $.validator.setDefaults({
                submitHandler: function () { 
                   
                    $("#tblList tbody tr").each(function () {
                        var sortorder = $(this).find("input").eq(1).val();                        
                        var homeorder = $(this).find("input").eq(2).val();
                        var id = $(this).find('a').last().attr('data-id');  

                        $.ajax({
                            type: "POST",
                            url: "/admin/productcategory/UpdateOrder",
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

}

