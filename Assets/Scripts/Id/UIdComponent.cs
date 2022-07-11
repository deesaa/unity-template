using System;
using UnityEngine;

[Serializable]
public struct UIdComponent : ISavable
{
    public Uid Value;
    public override string ToString() => Value.ToString();
    public string Save()
    {
        return JsonUtility.ToJson(this);
    }
}