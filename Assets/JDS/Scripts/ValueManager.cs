using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace JDS.Values
{
    public class ValueManager : MonoBehaviour
    {
        private List<IEasedValue<float>> _values = new List<IEasedValue<float>>();

        private void Update()
        {
            foreach (var easedValue in _values)
            {
                if (easedValue.IsDisposed)
                    _values.Remove(easedValue);
                
                easedValue.Update(Time.deltaTime);
            }
        }

        public IEasedValue<float> Init(EasedFloat config, Ease ease)
        {
            var newValue = config.SetEase(EaseFunc.Get(ease));
            _values.Add(newValue);
            return newValue;
        }
        
        public IEasedValue<float> Init(LerpedFloat config)
        {
            var newValue = config;
            _values.Add(newValue);
            return newValue;
        }
    }
}