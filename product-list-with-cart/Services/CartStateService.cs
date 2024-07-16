public class CartStateService
{
    private List<CartItem> items = new List<CartItem>();
    public event Action OnChange;
    public IEnumerable<CartItem> Items => items;

    public void AddItem(CartItem item)
    {
        var existingItem = items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {            
            existingItem.Quantity += item.Quantity;
        }
        else
        {            
            items.Add(item);
        }
        NotifyStateChanged();
    }

    public void IncrementQuantity(string itemId)
    {
        var item = items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            item.Quantity += 1;
            NotifyStateChanged();
        }        
    }

    public void DecrementQuantity(string itemId)
    {
        var item = items.FirstOrDefault(i => i.Id == itemId);
        if (item != null && item.Quantity > 1)
        {
            item.Quantity -= 1;
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
