public interface IDao<T>
{
    public void Save(T Data);
    public T Load();
    public void Delete();
}