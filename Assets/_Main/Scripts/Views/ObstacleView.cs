using Leopotam.Ecs;
using UnityEngine;

public class ObstacleView : LinkableView
{
    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEnter_(other);
        Entity.Get<TriggerEnterComponent>().Other = other;
    }

    protected virtual void OnTriggerEnter_(Collider other)
    {
        
    }
}

        