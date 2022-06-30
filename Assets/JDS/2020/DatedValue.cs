using System;

namespace JDS
{
    public struct DatedValue
    {
        public string Value;
        public DateTime DateTime;

        public DatedValue(string value)
        {
            Value = value;
            DateTime = DateTime.Now;
        }
    }
}