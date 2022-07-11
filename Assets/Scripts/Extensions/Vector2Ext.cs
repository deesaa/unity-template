using UnityEngine;

public static class Vector2Ext
{
    public static bool IsInRange(this Vector2 vector2, float value)
    {
        return value <= vector2.y && value > vector2.x;
    }
}