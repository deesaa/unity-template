using System;

namespace JDS.GRC
{
    public readonly struct BindHandler<T>
    {
        private readonly Action _action;
        private readonly T _valueType;

        public BindHandler(Action action, T valueType)
        {
            _action = action;
            _valueType = valueType;
        }

        public void Invoke() => _action();

        public void Destroy()
        {
            GRC<T>.Unbind(_valueType, _action);
        }

        public bool IsEqual(T valueType, Action action)
        {
            return _action == action && valueType.Equals(_valueType);
        }
    }
}