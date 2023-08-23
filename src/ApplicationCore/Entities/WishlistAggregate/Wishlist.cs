using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;
public class Wishlist : BaseEntity, IAggregateRoot
{
    public string BuyerId { get; set; }
    private readonly List<WishlistItem> _items = new List<WishlistItem>();
    public IReadOnlyCollection<WishlistItem> Items => _items.AsReadOnly();
    public int TotalItems => _items.Sum(i => i.Quantity);

    public Wishlist(string buyerId)
    {
        BuyerId = buyerId;
    }

    public void AddItem(int catalogItemId)
    {
        if (!Items.Any(i => i.CatalogItemId == catalogItemId)) { 
            _items.Add(new WishlistItem(catalogItemId));
            return; 
        }       
    }
    public void RemoveItem(int catalogItemId)
    {
        if (Items.Any(i => i.CatalogItemId == catalogItemId))
        {
            _items.Remove(new WishlistItem(catalogItemId));
            return;
        }
    }
}
