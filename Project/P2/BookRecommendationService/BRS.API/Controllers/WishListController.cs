using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using BRS.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishList.app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        //Fields
        private readonly IWishRepository _repo;
        private readonly ILogger<WishListController> _logger;

        public WishListController(IWishRepository repo, ILogger<WishListController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishListAsync(int userId)
        {
            IEnumerable<Wishlist> wishlist;
            try
            {
                wishlist = await _repo.GetWishListAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);

            }
            return wishlist.ToList();
        }



        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookFromWIshLostAsync(int id)
        {
            try
            {
                await _repo.DeleteBookFromWIshLostAsync(id);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
    }
}
