using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Create PrefabBase", fileName = "PrefabBase", order = 0)]
public class PrefabBase : ScriptableObject, IPrefabBase, IInitializable
{
    private Dictionary<string, GameObject> _objects = new Dictionary<string, GameObject>();
    public T GetPrefab<T>(string name)
    {
        return _objects[name].GetComponent<T>();
        
    }
    
    public GameObject GetPrefab(string name)
    {
        return _objects[name];
    }

    public void Initialize()
    {
        foreach (var gameObject in Resources.LoadAll<GameObject>("Prefabs"))
        {
            if (!_objects.ContainsKey(gameObject.name))
                _objects[gameObject.name] = gameObject;
        }
    }
}