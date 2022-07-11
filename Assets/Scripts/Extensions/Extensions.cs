using UnityEngine;

namespace JDS
{
    public static class Extensions
    {
        public static Vector3 RotatePointAroundPivot(this Vector3 point, Vector3 pivot, Vector3 angles) {
            Vector3 dir = point - pivot; // get point direction relative to pivot
            dir = Quaternion.Euler(angles) * dir; // rotate it
            point = dir + pivot; // calculate rotated point
            return point; // return it
        }
    }
}