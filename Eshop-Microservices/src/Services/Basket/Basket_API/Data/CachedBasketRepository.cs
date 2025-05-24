namespace Basket_API.Data;

public class CachedBasketRepository(IBasketRepository repository, IDistributedCache cache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        //use userName as key to get value from cache
        var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);

        //if key-value pair exists in cache we return it
        if (!string.IsNullOrEmpty(cachedBasket))
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;

        //else we get value from database
        var basket = await repository.GetBasket(userName, cancellationToken);
        await cache.SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        //store first in database
        await repository.StoreBasket(basket, cancellationToken);

        //store in cache
        await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);

        return basket;
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        //delete in database
        await repository.DeleteBasket(userName, cancellationToken);

        //delete in cache
        await cache.RemoveAsync(userName, cancellationToken);

        return true;
    }
}
