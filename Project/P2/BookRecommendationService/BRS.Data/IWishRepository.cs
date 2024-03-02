using BRS.Logic;

namespace WishList.Data
{
    public interface IWishRepository
    {
        public Task<IEnumerable<Wishlist>> GetWishListAsync(int userId);
        public Task AddTOWishListAsync(int id);
        public Task DeleteBookFromWIshLostAsync(int bookId);

    }
}
