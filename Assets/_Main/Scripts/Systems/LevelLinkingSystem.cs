using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;
[Preserve]
public class LevelLinkingSystem : IEcsInitSystem
{
    private EcsWorld _world;
    [Inject] private GameObjectFabric _fabric;
    [Inject] private IGameData<PlayerGameData> _data;
    [Inject] private IGameStageService _gameStage;
    public void Init()
    {
        /*if (_data.Get().SavedEntities.Count != 0)
        {
            
        }
        else
        {*/
            foreach (var linkableView in GameObject.FindObjectsOfType<LinkableView>(true))
            {
                _fabric.CreateFromInstance(linkableView);
            }
        //}
        
        
        

        _gameStage.ChangeStage<StageLevelStart>();
    }
}