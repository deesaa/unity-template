using System.Collections.Generic;
using UnityEngine;

namespace JDS
{
    public class UnityReactiveCoreObserver : MonoBehaviour, IReactiveCoreObserver<string>
    {
        private static UnityReactiveCoreObserver _instance;

        public Dictionary<string, ReactiveCoreObserverElement> _valuePairs = new Dictionary<string, ReactiveCoreObserverElement>();

        private void Awake()
        {
            if (_instance != null)
                Destroy(gameObject);
        }

        public void OnKeyValueChanged(string key, object nextValue)
        {
            string value = nextValue != null ? nextValue.ToString() : "NULL_VALUE";
            
            if (_valuePairs.ContainsKey(key))
            {
                _valuePairs[key].SetNext(value);
            }
            else
            {
                _valuePairs.Add(key, new ReactiveCoreObserverElement(key, value));
            }
        }

        public static void Create(ReactiveCore<string> reactiveCore)
        {
            var go = new GameObject("[RC-Debug Observer]");
            var observer = go.AddComponent<UnityReactiveCoreObserver>();
            _instance = observer;
            DontDestroyOnLoad(go);
            reactiveCore.SetDebugObserver(observer);
        }
    }
}