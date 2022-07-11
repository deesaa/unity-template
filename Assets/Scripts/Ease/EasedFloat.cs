using System;
using System.Collections.Generic;
using UnityEngine;

namespace JDS.Values
{
    [Serializable]
    public class EasedFloat : IEasedValue<float>
    {
        private bool _isTargetValueReached;
        private List<IObserver<float>> _observers;
        private float _timePassed;
        private float _lastValue;
        
        [SerializeField] private float tolerance = 0.01f;
        [SerializeField] private float easeTime = 1f;

        private Func<float, float, float, float> _ease;

        private float _currentValue;
        public float CurrentValue
        {
            get => _currentValue;
            private set
            {
                _currentValue = value;

                if (_timePassed >= easeTime)
                {
                    _currentValue = TargetValue;
                    _isTargetValueReached = true;
                }

                if (_observers == null)
                    return;

                foreach (var observer in _observers)
                    observer.OnNext(CurrentValue);
            }
        }

        private float _targetValue;
        public float TargetValue
        {
            get => _targetValue;
            set
            {
                _lastValue = CurrentValue;
                
                if (Math.Abs(TargetValue - value) > tolerance)
                {
                    _targetValue = value;
                    _timePassed = 0f;
                    _isTargetValueReached = false;
                }   
            }
        }

        public EasedFloat SetEase(Func<float, float, float, float> ease)
        {
            _ease = ease;
            return this;
        }

        public IDisposable Subscribe(IObserver<float> observer)
        {
            _observers ??= new List<IObserver<float>>();
            if(!_observers.Contains(observer))
                _observers.Add(observer);
            return this;
        }
        
        public void Update(float deltaTime)
        {
            if(_isTargetValueReached)
                return;

            _timePassed += deltaTime;

            CurrentValue = _ease(_lastValue, TargetValue, _timePassed/easeTime);
        }

        private bool _isDisposed;
        public bool IsDisposed => _isDisposed;
        
        public void Dispose()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();
            _observers.Clear();
            _isDisposed = true;
        }

        public void Reset(float value)
        {
            TargetValue = value;
            CurrentValue = value;
        }
    }
}