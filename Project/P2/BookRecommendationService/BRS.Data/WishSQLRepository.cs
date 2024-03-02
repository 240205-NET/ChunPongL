using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using BRS.Logic;

namespace WishList.Data
{
    public class WishSQLRepository : IWishRepository
    {
        //Fields 
        private readonly string _connectionString;
        private readonly ILogger<WishSQLRepository> _logger;

        //constructors
        public WishSQLRepository(string connectionString, ILogger<WishSQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        public Task AddTOWishListAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Wishlist>> GetWishListAsync(int userId)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            await connection.OpenAsync();
            string cmdText = "SELECT [book].[wishlist].id, title AS Title FROM [book].[wishlist] JOIN [book].[books] ON [book].[books].id = [book].[wishlist].bookId where book.wishlist.userId= @userId;";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue(@"userId", userId);


            using SqlDataReader reader = await cmd.ExecuteReaderAsync();
            
            List<Wishlist> wishlist = new List<Wishlist>();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                string title = reader["title"].ToString() ?? "";
                wishlist.Add(new Wishlist(id, title));

            }
            await connection.CloseAsync();
            return wishlist;
        }
        public async Task DeleteBookFromWIshLostAsync(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string cmdText = "DELETE FROM [book].[wishlist] WHERE [book].[wishlist].id =@id;";
            using SqlCommand cmd = new SqlCommand(cmdText, connection);
            cmd.Parameters.AddWithValue("@id", id);

            await cmd.ExecuteNonQueryAsync();
            await connection.CloseAsync();
            _logger.LogInformation("Delete Execution completed, book id#{0}", id);
        }


    }
}
