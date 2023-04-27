var productCategoryController = function () {

    this.initialize = function () {
              
        registerEvents();
    }

    var registerEvents = function () {
        loadCategories();
    }

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

                console.log(mergeChildren(response));

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
}

$(document).ready(function () {

    $('.tree').treegrid({
        /* 'initialState': 'collapsed',*/
        treeColumn: 1
    });

    $("#checkAll").change(function () {
        $('input:checkbox').not(this).prop('checked', this.checked);
    });

});