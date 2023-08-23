using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ardalis.GuardClauses;
using Ardalis.Result;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.ApplicationCore.Entities.WishlistAggregate;


namespace Microsoft.eShopWeb.ApplicationCore.Services;
public class WishlistService : IWishlistService
{
    private readonly IRepository<Wishlist> _wishlistRepository;
    private readonly IAppLogger<WishlistService> _logger;

    public WishlistService(IRepository<Wishlist> wishlistRepository, IAppLogger<WishlistService> logger)
    {
        _wishlistRepository = wishlistRepository;
        _logger = logger;
    }

    public async Task<Wishlist> AddItemToWishlist(string username, int catalogItemId)
    {
        var wishlistSpec = new WishlistWithItemsSpecification(username);
        var wishlist = await _wishlistRepository.FirstOrDefaultAsync(wishlistSpec);

        //TODO: Use Copilot to help you finish this method by adding the item to _wishlistRepository


        await _wishlistRepository.UpdateAsync(wishlist);
        return wishlist;
    }


    public async Task<Wishlist> RemoveItemFromWishlist(string username, int catalogItemId)
    {
        var wishlistSpec = new WishlistWithItemsSpecification(username);
        var wishlist = await _wishlistRepository.FirstOrDefaultAsync(wishlistSpec);

        //TODO: Use Copilot to help you finish this method by removing the item from _wishlistRepository

        await _wishlistRepository.UpdateAsync(wishlist);
        return wishlist;
    }

    public async Task TransferWishlistAsync(string anonymousId, string userName)
    {
        var anonymousWishlistSpec = new WishlistWithItemsSpecification(anonymousId);
        var anonymousWishlist = await _wishlistRepository.FirstOrDefaultAsync(anonymousWishlistSpec);
        if (anonymousWishlist == null) return;
        var userWishlistSpec = new WishlistWithItemsSpecification(userName);
        var userWishlist = await _wishlistRepository.FirstOrDefaultAsync(userWishlistSpec);
        if (userWishlist == null)
        {
            userWishlist = new Wishlist(userName);
            await _wishlistRepository.AddAsync(userWishlist);
        }
        foreach (var item in anonymousWishlist.Items)
        {
            userWishlist.AddItem(item.CatalogItemId);
        }
        await _wishlistRepository.UpdateAsync(userWishlist);
        await _wishlistRepository.DeleteAsync(anonymousWishlist);
    }

    public async Task DeleteWishlistAsync(int wishlistId)
    {
        var wishlist = await _wishlistRepository.GetByIdAsync(wishlistId);
        Guard.Against.Null(wishlist, nameof(wishlist));
        await _wishlistRepository.DeleteAsync(wishlist);
    }
}
