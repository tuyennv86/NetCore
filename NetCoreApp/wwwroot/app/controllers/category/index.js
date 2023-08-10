﻿let categoryController = function () {

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
            viewCategoryType();
            loadCategoriesTotree();

        });

        $('body').on('click', '#lbtEdit', function (e) {
            e.preventDefault();
            $('#modalAddEdit').modal('show');
            let id = $(this).attr('data-id');           

            $.ajax({
                type: "POST",
                url: "/admin/category/GetByID",
                cache: false,
                data: { id: id },
                dataType: "json",
                beforeSend: function () {
                    until.startLoading();
                },
                success: function (response) {
                    until.stopLoading();
                    console.log(response);

                    $("#hidCategoryId").val(response.parentId);
                    loadCategoriesTotreeBySelectID(response.parentId);

                    $("#hidId").val(response.id);
                    $("#txtName").val(response.name);
                    $("#txtAlias").val(response.seoAlias);
                    $("#txtDesc").val(response.description);
                    $("#txtSeoKeyword").val(response.seoKeywords);
                    $("#txtOrder").val(response.sortOrder);
                    $("#txtHomeOrder").val(response.homeOrder);
                    $("#hidImage").val(response.image);
                    $("#imgImage").attr("src", response.image);
                    $("#txtSeoPageTitle").val(response.seoPageTitle);
                    $("#txtSeoAlias").val(response.seoAlias);
                    $("#txtSeoKeyword").val(response.seoKeywords);
                    $("#txtSeoDescription").val(response.seoDescription);
                    $("#ckStatus").prop("checked", response.status);
                    $("#ckShowHome").prop("checked", response.homeFlag);
                },
                error: function (status) {
                    until.notify('Lỗi không xóa được', 'error' + status);
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
                        url: "/admin/category/DeleteCategoryByID",
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
                messages: {
                    txtName: {
                        required: "Tên danh mục không được bỏ trống"
                    },
                    txtSeoAlias: {
                        required:"Seo Alias không được bỏ trống"
                    },
                    txtOrder: {
                        required: "Thứ tự không được bỏ trống",
                        digits: "Chỉ được nhập số"
                    },
                    txtHomeOrder: {
                        required: "Thứ tự không được bỏ trống",
                        digits: "Chỉ được nhập số"
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
    function viewCategoryType() {
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
    //load danh sách các danh mục thành cây danh mục
    function loadCategoriesTotree() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            cache: false,
            url: '/admin/Category/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {                
                
               comboTree1 = $('#ddlCategory').comboTree({                    
                    isMultiple: false
                });

                comboTree1.clearSelection();
                comboTree1.setSource(createTreeSub(response));

                comboTree1.onChange(function () {
                    $('#hidCategoryId').val(comboTree1.getSelectedIds());
                });

                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }
    // load danh sách các danh mục dạng edit
    function loadCategoriesTotreeBySelectID(selectID) {

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
                comboTree1.setSource(createTreeSub(response));
                comboTree1.setSelection([selectID]);                
                
                comboTree1.onChange(function () {
                    $('#hidCategoryId').val(comboTree1.getSelectedIds());
                });                

                until.stopLoading();
            }, error: function (status) {
                until.notify("Không load được dữ liệu", status);
            }
        })
    }
    
    //function traverse(list) {
    //    var html = '<ul>';
    //    for (var i = 0; i < list.length; i++) {
    //        html += '<li>' + list[i].Name;
    //        if (list[i].children) {
    //            html += traverse(list[i].children);
    //        }
    //        html += '</li>';
    //    }
    //    html += '</ul>';

    //    return html;
    //}
    
    // dang childer tu mang
    function createTreeSub(arr) {
        let tree = [],
            mappedArr = {},
            arrElem,
            mappedElem;

        // First map the nodes of the array to an object -> create a hash table.
        for (let i = 0, len = arr.length; i < len; i++) {
            arrElem = arr[i];
            mappedArr[arrElem.id] = arrElem;
            mappedArr[arrElem.id]['subs'] = [];
        }

        for (let id in mappedArr) {
            if (mappedArr.hasOwnProperty(id)) {
                mappedElem = mappedArr[id];
                // If the element is not at the root level, add it to its parent array of children.
                if (mappedElem.parentId) {
                    mappedArr[mappedElem['parentId']]['subs'].push(mappedElem);
                }
                // If the element is at the root level, add it to first level elements array.
                else {
                    tree.push(mappedElem);
                }
            }
        }
        let parentITem = { id: 0, name: 'Root' };
        tree.unshift(parentITem);
        return tree;
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
        let id = $("#hiId").val();
        let name = $("#txtName").val();
        let sortOrder = $("#txtOrder").val();
        let isDeleted = $('#ckStatus').prop('checked');

        let dataPost = {
            "Id": id,
            "Name": name,
            "SortOrder": sortOrder,
            "IsDeleted": isDeleted,
            "DateCreated": Date(),
            "DateModified": Date()
        };
        $.ajax({
            type: "POST",
            url: "/admin/Category/SaveEntity",
            data: dataPost,
            dataType: "json",
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
            },
            error: function () {
                until.notify('Lỗi không cập nhập hoặc thêm mới được!', 'error');
                until.stopLoading();
            }
        });
    }

    function resetFormMaintainance() {
        $('#hiId').val(0);
        $('#txtName').val('');
        $('#txtOrder').val('');
        $('#ckStatus').prop('checked', false);
    }

}

$(document).ready(function () {
    $('#txtDetail').summernote({        
        tabsize: 2,
        height: 120,
        lang: 'vi-VN', 
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'underline', 'clear']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],
            ['insert', ['link', 'picture', 'video']],
            ['view', ['fullscreen', 'codeview', 'help']]
        ]
    });
});