using UnityEngine;

namespace JDS
{
    public static class Extensions
    {
        /*public static T Get<T>(this object o)
        {
            if (o is T value)
                return value;

            DebugLog.LogError($"object {o} is not type of {typeof(T)}, it is type of {o.GetType()}");
            return default;
        }*/
        
        public static Vector3 RotatePointAroundPivot(this Vector3 point, Vector3 pivot, Vector3 angles) {
            Vector3 dir = point - pivot; // get point direction relative to pivot
            dir = Quaternion.Euler(angles) * dir; // rotate it
            point = dir + pivot; // calculate rotated point
            return point; // return it
        }
    }
}