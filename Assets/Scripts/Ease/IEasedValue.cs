using System;

namespace JDS.Values
{
    public interface IEasedValue<T> : IObservable<T>, IDisposable
    {
        T CurrentValue { get; }
        T TargetValue { get; set; }
        void Update(float deltaTime);
        bool IsDisposed { get; }
    }
}