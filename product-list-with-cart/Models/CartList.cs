
public class CartList
{
    public Guid CartId { get; set; }
    public List<CartItem> Items { get; set; }
}

public class CartItem
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}