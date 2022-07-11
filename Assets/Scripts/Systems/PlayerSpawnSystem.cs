using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

[Preserve]
public class PlayerSpawnSystem : IEcsRunSystem
{
    private EcsFilter<MonoLinkComponent<PlayerSpawnPosition>> _position;
    private EcsFilter<PlayerComponent> _player;
    [Inject] private GameObjectFactory _factory;
    [Inject] private LevelConfiguration LevelConfiguration;

    private EcsWorld _world;
    public void Run()
    {
        if(!_player.IsEmpty())
            return;
        if(_position.IsEmpty())
            return;

        var positionView = _position.Get1(0).View.transform;
        _factory.CreatePlayer(positionView.position, Quaternion.identity);
    }
}