namespace ShopOnline.API.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        //Foreign key - point to cart containing this item
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
