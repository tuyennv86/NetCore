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
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            cache: false,
            data: {
                parentId: 0
            },
            url: '/admin/productcategory/GetByParent',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {

                //console.log(mergeChildren(response));

                var templateWithData = Mustache.render($("#mp_template").html(), {                    
                    categoryTag: mergeChildren(response),                    
                    dateFormat: function () {
                        return function (timestamp, render) {
                            return new Date(render(timestamp).trim()).toLocaleString('en-GB', { timeZone: 'UTC' });
                        };
                    }
                });
                $("#tpl_content").empty().html(templateWithData);

                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }

    function mergeChildren(sources) {
        var children = [];
        for (var index in sources) {
            var source = sources[index];
            children.push({
                id: source.id,
                parentId: source.parentId,
                name: source.name,
                image: source.image,
                homeOrder: source.homeOrder,
                homeFlag: source.homeFlag,
                description: source.description,
                seoAlias: source.seoAlias,
                seoDescription: source.seoDescription,
                seoKeywords: source.seoKeywords,
                seoPageTitle: source.seoPageTitle,
                sortOrder: source.sortOrder,
                status: source.status,
                dateModified: source.dateModified,
                dateCreated: source.dateCreated
            });
            if (source.children) {
                children = children.concat(mergeChildren(source.children))
            }
        }
        return children;
    }

    function updateOrder() {
        $(function () {
            $.validator.setDefaults({
                submitHandler: function () {
                    alert('');
                    $('#tblList > tbody  > tr').each(function (index, tr) {

                        var self = $(this);
                        var col_1_value = self.find("input.eq(0)").text().trim();
                        var col_2_value = self.find("input.eq(1)").text().trim();
                        var result = col_1_value + "- " + col_2_value;
                        alert(result);
                    });

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

