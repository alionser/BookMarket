namespace BookMarket.Data.Entities;

public class Customer
{
    public int Id { get; set; }
    
    public int PersonId { get; set; }
    public Person Person { get; set; }
}