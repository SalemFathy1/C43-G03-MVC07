namespace Domain.Models;
public class BaseEntity<TKey> // int
{
    public TKey Id { get; set; } = default!; 
}

