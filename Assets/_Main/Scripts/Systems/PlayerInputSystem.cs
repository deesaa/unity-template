using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<MonoLinkComponent<PlayerView>, PlayerComponent> _player;
    public void Run()
    {
        if(_player.IsEmpty())
            return;
        
        if (Input.anyKeyDown)
        {
            
        }
    }
}