using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

public class SaveGameService : IEcsInitSystem, ISaveGame
{
    private EcsFilter<UIdComponent> _entities;
    [Inject] private IGameData<PlayerGameData> _data;
    public void Init() { }
    public void Save()
    {
        Debug.Log("SaveGameService Save");
        var data = _data.Get();
        Debug.Log("SaveGameService data Coins: " + data.Coins);

        data.ClearSavedEntities();
        foreach (var i in _entities)
        {
            data.WriteEntity(_entities.GetEntity(i));
        }
        _data.Save(data);
    }
}