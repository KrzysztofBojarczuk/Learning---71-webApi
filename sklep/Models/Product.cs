namespace sklep.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ItemNumbers { get; set; }
        public int ShopId { get; set; }
        public Shop shop { get; set; }

    }
}
