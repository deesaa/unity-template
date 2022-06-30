namespace JDS
{
    public interface IReactiveCoreObserver<T>
    {
        void OnKeyValueChanged(T key, object nextValue);
    }
}