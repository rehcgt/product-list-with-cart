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

    public void RemoveItem(string itemId)
    {
        var item = items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            items.Remove(item);
            NotifyStateChanged();
        }
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
        if (item != null)
        {
            if (item.Quantity > 1)
            {
                item.Quantity -= 1;
            }
            else
            {
                items.Remove(item);
            }
            NotifyStateChanged();
        }
    }

    public int ItemsCount()
    {
        return items.Sum(i => i.Quantity);
    }

    public int getItemCount(string itemId)
    {
        var item = items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            return item.Quantity;
        }
        return 0;
    }

    public void ClearCart()
    {
        items.Clear();
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
