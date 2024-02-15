public interface IEntity
{
    public void Add<T>(T component);
    public bool TryComponent<T>(out T component);
    public T Get<T>();
}