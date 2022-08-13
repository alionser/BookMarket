namespace BookMarket.Data.Entities;

public class Book
{
    public int Id { get; set; }
    
    public decimal Rating { set; get; }

    public string Title { get; set; }
    public string? Description { get; set; }
    
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    
    public Author Author { get; set; }
    public int AuthorId { get; set; }
    
    public Publisher Publisher { get; set; }
    public int PublisherId { get; set; }
}