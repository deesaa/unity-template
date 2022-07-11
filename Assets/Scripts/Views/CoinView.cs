using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

public class CoinView : ObstacleView
{
    public Transform OnTakeEffectPrefab;
    public override void Link(EcsEntity entity)
    {
        base.Link(entity);
        Entity.Get<CoinComponent>().OnTake = OnTake;
    }

    private void OnTake()
    {
        GetComponent<Collider>().enabled = false;
        transform.DOMove(transform.position + Vector3.up * 10f, 2f).OnComplete(() =>
        {
            Entity.Get<DestroyComponent>();
        }).SetTarget(gameObject);
        

        Destroy(Instantiate(OnTakeEffectPrefab, transform.position, Quaternion.identity).gameObject, 2f);
    }
}