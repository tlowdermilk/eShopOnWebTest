using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;
public sealed class WishlistWithItemsSpecification : Specification<Wishlist>, ISingleResultSpecification
{
    public WishlistWithItemsSpecification(int wishlistId)
    {
        Query
            .Where(b => b.Id == wishlistId)
            .Include(b => b.Items);
    }

    public WishlistWithItemsSpecification(string buyerId)
    {
        Query
            .Where(b => b.BuyerId == buyerId)
            .Include(b => b.Items);
    }
}
