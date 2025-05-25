namespace Ordering.Domain.Abstractions;

//Provides auditing properties common to all entities (creation/modification metadata).
public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}


//Extends IEntity to include an Id of generic type T, which is usually a GUID or int.
//This makes the entity uniquely identifiable.
public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
