using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Create MaterialBase", fileName = "MaterialBase", order = 0)]
public class MaterialBase : ScriptableObject, IMaterialBase, IInitializable
{
    private Dictionary<string, Material> _objects = new Dictionary<string, Material>();
    public void Initialize()
    {
        foreach (var gameObject in Resources.LoadAll<Material>("Materials"))
        {
            if (!_objects.ContainsKey(gameObject.name))
                _objects[gameObject.name] = gameObject;
        }
    }

    public Material GetMaterial(EGameColors name)
    {
        return GetMaterial(name.ToString());
    }
    
    public Material GetMaterial(string name)
    {
        return _objects[name];
    }
}