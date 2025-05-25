namespace Ordering.Domain.Abstractions;

//A base abstract class providing the concrete implementation for IEntity<T>.
//It simplifies the creation of domain entities by implementing common fields(Id, CreatedAt, etc.).
public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
