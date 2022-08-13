namespace BookMarket.Data.Entities;

public class Author
{
    public int Id { get; set; }
    
    public decimal Rating { set; get; }

    public int PersonId { get; set; }
    public Person Person { get; set; }
    
    public ICollection<Book> Books { get; set; }
}