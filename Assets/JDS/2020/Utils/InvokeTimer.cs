using System;
using System.Collections.Generic;
using UnityEngine;

namespace JDS
{
    public class InvokeTimer : MonoBehaviour
    {
        public static InvokeTimer Instance { get; private set; }

        private List<TimedAction> _registered = new List<TimedAction>();
        
        private void Awake() => Instance = this;

        public TimedAction Create(float interval, float delay, Action action) =>
            new TimedAction(interval, delay, action);

        public TimedAction Create(float interval, float delay, int targetIterations, Action action) =>
            new TimedAction(interval, delay, targetIterations, action); 

        public void Register(TimedAction timedAction)
        {
            if (_registered.Contains(timedAction))
                return;
            
            _registered.Add(timedAction);
        }

        private void Update()
        {
            for (int i = 0; i < _registered.Count; i++)
                _registered[i].Update(Time.deltaTime);
        }

        public void Destroy(TimedAction timedAction)
        {
            if(_registered.Contains(timedAction))
                _registered.Remove(timedAction);
        }
    }
}