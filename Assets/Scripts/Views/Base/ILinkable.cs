using Leopotam.Ecs;
using Newtonsoft.Json;
using UnityEngine;

public interface ILinkable
{
    int Hash { get; }
    [JsonIgnore]
    Transform Transform { get; }
    int UnityInstanceId { get; }
    void Link(EcsEntity entity);
    void Destroy();
}