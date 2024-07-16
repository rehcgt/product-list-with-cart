
public class CartItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}