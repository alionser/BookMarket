namespace BookMarket.Data.Entities;

public class Author
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public decimal Rating { set; get; }

    public ICollection<Book> Books { get; set; }
}