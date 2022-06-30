using System.Collections.Generic;

namespace JDS
{
    public class ReactiveCoreObserverElement
    {
        private static readonly int capacity = 32;
        public string Key { get; private set; }
        public readonly List<DatedValue> ValueHistory = new List<DatedValue>();
        
        public ReactiveCoreObserverElement(string key, string value)
        {
            this.Key = key;
            SetNext(value);
        }

        public void SetNext(string value)
        {
            ValueHistory.Add(new DatedValue(value));
            if (ValueHistory.Count > capacity)
                ValueHistory.RemoveAt(0);
        }
    }
}