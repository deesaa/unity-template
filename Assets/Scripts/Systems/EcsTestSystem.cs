using ECS.Utils.Extensions;
using JDS.Values;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

[Preserve]
public class EcsTestSystem : IEcsRunSystem
{
    private EcsFilter<MonoLinkComponent<PlayerView>, PlayerComponent> _player;
    private EcsWorld _world;
    [Inject] private ISaveGame _saveGame;
    public void Run()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _saveGame.Save();
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            _world.NewEntity().Get<LoadGameEventComponent>();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            

        }
        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
}