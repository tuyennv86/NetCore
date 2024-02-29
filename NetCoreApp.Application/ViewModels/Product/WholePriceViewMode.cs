namespace NetCoreApp.Application.ViewModels.Product
{
    public class WholePriceViewMode
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FromQuantity { get; set; }
        public int ToQuantity { get; set; }
        public decimal Price { get; set; }      
        public  ProductViewModel Product { get; set; }
    }
}
