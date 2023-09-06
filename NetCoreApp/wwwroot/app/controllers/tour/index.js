let tourController = function () {

    this.initialize = function () {        
               
        registerEvents();
        loadData(true);
    }

    let registerEvents = function () {

        loadCategories();

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

    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',           
            url: '/admin/productcategory/GetAll',
            beforeSend: function () {
                until.startLoading();
            },
            success: function (response) {
                let render = "<option value=''>--Chọn danh mục--</option>";
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

    let loadData = function (isPageChanged) {
        $.ajax({
            type: 'POST',           
            dataType: 'json',
            data: {
                cateogryId: $('#slCategory').val(),
                name: $('#txtSearch').val(),
                pageIndex: until.configs.pageIndex,
                pageSize: until.configs.pageSize
            },
            url: '/admin/tour/GetAll',
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
        //Bind Pagination Event
        $('#pagination').twbsPagination('destroy');
        $('#pagination').twbsPagination({
            totalPages: totalsize,
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

$(document).ready(function () {    

    $("#checkAll").change(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });

});