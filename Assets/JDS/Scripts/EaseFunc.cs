using System;
using DG.Tweening;

namespace JDS.Values
{
    public static class EaseFunc
    {
        public static Func<float, float, float, float> Get(Ease ease)
        {
            return (a, b, time) => DOVirtual.EasedValue(a, b, time, ease);
        }
    }
}