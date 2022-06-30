using UnityEngine;

[CreateAssetMenu(menuName = "Create PlayerConfiguration", fileName = "PlayerConfiguration", order = 0)]
public class PlayerConfiguration : ScriptableObject
{
    public float PlayerRotationSpeed;

    public float DragDecreaseSpeed = 2f;
    public float TempViewRotateScale = 0.5f;
    public float TempViewRotateMax = 20f;
    
}