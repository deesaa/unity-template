using Newtonsoft.Json;
using UnityEngine;

public struct TransformComponent
{
    public Vector3 WorldPosition;
    [JsonIgnore]
    public Quaternion Rotation;
    public Vector3 Scale;
}