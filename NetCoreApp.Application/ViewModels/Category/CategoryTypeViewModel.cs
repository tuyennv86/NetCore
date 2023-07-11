using System;

namespace NetCoreApp.Application.ViewModels.Category
{
    public class CategoryTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}