using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;
[Preserve]
public class LevelLinkingSystem : IEcsInitSystem
{
    private EcsWorld _world;
    [Inject] private GameObjectFactory _factory;
    [Inject] private IGameData<PlayerGameData> _data;
    [Inject] private IGameStageService _gameStage;
    public void Init()
    {
        foreach (var linkableView in GameObject.FindObjectsOfType<LinkableView>(true))
        {
            _factory.CreateFromInstance(linkableView);
        }
        
        _gameStage.ChangeStage<StageLevelStart>();
    }
}