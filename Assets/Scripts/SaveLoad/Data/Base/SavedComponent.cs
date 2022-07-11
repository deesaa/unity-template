using System;
using UnityEngine;

[Serializable]
public struct SavedComponent
{
    [SerializeField]
    public string Type;
    public string Data;
}