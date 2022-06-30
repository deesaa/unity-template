public interface IGameData<T>
{
    public T Get();
    public void Save(T data);
    public void Delete();
}