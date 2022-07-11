using System;
using Leopotam.Ecs;
using UnityEngine;
using Random = UnityEngine.Random;

public class BreakableObstacleView : ObstacleView, IBreakable
{
    public Transform OnTakeEffectPrefab;
    public Transform OnTakeUiEffectPrefab;
    public Transform OnTakeUiEffectPosition;

    public ModelDestroyer ModelDestroyer;
    public Transform BreakExplosionForcePosition;
    public float Force;
    public float TorqueForce;
    public float Radius;
    public float UpModifier;
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Entity.Get<BreakableComponent>().Breakable = this;
    }

    public void OnBreak(Transform other)
    {
        GetComponent<Collider>().enabled = false;
        Entity.Get<DestroyComponent>();
        Destroy(Instantiate(OnTakeEffectPrefab, transform.position, Quaternion.identity).gameObject, 2f);
        Destroy(Instantiate(OnTakeUiEffectPrefab, OnTakeUiEffectPosition.position, OnTakeUiEffectPosition.rotation).gameObject, 2f);

        var pos = new Vector3(other.position.x, BreakExplosionForcePosition.position.y, other.position.z);
        
        ModelDestroyer.DestroyModel(pos, Radius,Force, UpModifier, TorqueForce);
    }
}