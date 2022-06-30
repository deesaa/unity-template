using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace JDS.Values
{
    [Serializable]
    public class LerpedFloat : IEasedValue<float>
    {
        private bool _isTargetValueReached;
        private List<IObserver<float>> _observers;
        private float _currentValue;
        
        [SerializeField] private float tolerance = 0.01f;
        [SerializeField] private float lerpSpeed = 1f;

        public float CurrentValue
        {
            get => _currentValue;
            private set
            {
                _currentValue = value;
                if (Math.Abs(_currentValue - TargetValue) < tolerance)
                {
                    _currentValue = _targetValue;
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
                if (Math.Abs(_targetValue - value) > tolerance)
                {
                    _targetValue = value;
                    _isTargetValueReached = false;
                }   
            }
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
            CurrentValue = Mathf.Lerp(CurrentValue, TargetValue, deltaTime * lerpSpeed);
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
    }
}