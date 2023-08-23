namespace Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;
public class WishlistItem: BaseEntity
{
    public int WishlistId { get; set; }
    public int CatalogItemId { get; private set; }
    public int Quantity { get; private set; }
    public WishlistItem(int catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }
}
