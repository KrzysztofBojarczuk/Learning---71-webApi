namespace sklep.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Workers { get; set; }
        public List<Product> Products { get; set; }
    }
}
