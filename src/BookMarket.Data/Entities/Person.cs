namespace BookMarket.Data.Entities;

public class Person
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    
    //TODO: хранить дату рождения
    public int Age { get; set; }
    
    public Customer Customer { get; set; }
}