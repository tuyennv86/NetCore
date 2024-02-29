using NetCoreApp.Application.ViewModels.Tag;

namespace NetCoreApp.Application.ViewModels.Product
{
    public class ProductTagViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }      
        public string TagId { set; get; }      
        public ProductViewModel Product { set; get; }      
        public TagViewModel Tag { set; get; }
    }
}
