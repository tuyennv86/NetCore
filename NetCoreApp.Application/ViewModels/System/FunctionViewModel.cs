using NetCoreApp.Application.ViewModels.Category;
using NetCoreApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace NetCoreApp.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        [StringLength(250)]
        public string URL { set; get; }
        public int CategoryTypeID { get; set; }
        //public CategoryTypeViewModel CategoryType { set; get; }

        [StringLength(128)]
        public string ParentId { set; get; }

        public string IconCss { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public bool IsType { get; set; }
    }
}
