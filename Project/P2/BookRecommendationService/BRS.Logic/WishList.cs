namespace BRS.Logic
{
    public class Wishlist
    {
        //public int userID {  get; set; }
        public int id { get; set; }
        //public Book book { get; set; }
        public string title { get; set; }

        public Wishlist(int id, string title)
        {
            this.id = id;
            this.title = title;
        }
        public override string ToString()
        {
            return $"\nID: {this.id}\n Title: {this.title}\n";
        }
    }
}
