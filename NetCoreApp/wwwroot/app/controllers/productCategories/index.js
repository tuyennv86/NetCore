var productCategoryController = function () {

    this.initialize = function () {

        loadCategories();
        //registerEvents();
        updateOrder();       
       
    }

    //function registerEvents() {
        
    //}

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
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

$(document).ready(function () {
    $('.tree').treegrid({
        /* 'initialState': 'collapsed',*/
        treeColumn: 1
    });         

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
                console.log(id);
                // gọi hàm xóa
            }
        });
    });
    
});