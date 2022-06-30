using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;
[Preserve]
public class LoadGameSystem : ReactiveSystem<LoadGameEventComponent>
{
    private EcsFilter<UIdComponent> _entities;
    [Inject] private IGameData<PlayerGameData> _data;
    protected override EcsFilter<LoadGameEventComponent> ReactiveFilter { get; }
    protected override void Execute(EcsEntity entity)
    {
        var data = _data.Get();
        foreach (var savedEntity in data.SavedEntities)
        {
            foreach (var component in savedEntity.Components)
            {
                Debug.Log(component);
                
            }
        }
    }
}