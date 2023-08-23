using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces;
public interface IWishlistService
{
    Task TransferWishlistAsync(string anonymousId, string userName);
    Task<Wishlist> AddItemToWishlist(string username, int catalogItemId);
    Task<Wishlist> RemoveItemFromWishlist(string username, int catalogItemId);
    Task DeleteWishlistAsync(int wishlistId);
}
