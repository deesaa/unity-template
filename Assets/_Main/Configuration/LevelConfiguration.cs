using UnityEngine;

[CreateAssetMenu(menuName = "Create LevelConfiguration", fileName = "LevelConfiguration", order = 0)]
public class LevelConfiguration : ScriptableObject
{
    
    public int StartPlayerUnitsCount = 2;
    public Vector3 ColorableUnitsScale = Vector3.one;
    public EGameColors IntialPlayerColor;
    public EGameColors IntialColorableObjectsColor;
}