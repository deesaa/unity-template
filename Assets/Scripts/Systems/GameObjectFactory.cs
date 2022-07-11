using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class GameObjectFactory
{
    [Inject] private EcsWorld _world;
    [Inject] private LevelConfiguration Configuration;
    
    public void CreateSimpleColorable(Vector3 position, Quaternion rotation)
    {
        var entity = _world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        entity.GetAndFire<PrefabComponent>().Name = "ColorableView";
        entity.GetAndFire<ColorComponent>().Color = EGameColors._default;
        entity.GetAndFire<TransformComponent>() = new TransformComponent()
        {
            WorldPosition = position,
            Rotation = rotation,
            Scale = Vector3.one
        };
    }

    public void CreatePlayer(Vector3 position, Quaternion rotation)
    {
        var entity = _world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        entity.GetAndFire<PrefabComponent>().Name = "PlayerView";
        entity.GetAndFire<ColorComponent>().Color = EGameColors._default;
        entity.Get<PlayerComponent>();
        entity.GetAndFire<TransformComponent>() = new TransformComponent()
        {
            WorldPosition = position,
            Rotation = rotation,
            Scale = Vector3.one
        };
    }

    public void CreatePlayerUnit(Vector3 position, Quaternion rotation, Uid PlayerUid, int index, EGameColors color)
    {
        var entity = _world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        entity.GetAndFire<OwnerComponent>().Value = PlayerUid;
        entity.GetAndFire<PrefabComponent>().Name = "PlayerUnitView";
        entity.GetAndFire<ColorComponent>().Color = color;
        entity.Get<IndexComponent>().Value = index;
        entity.GetAndFire<TransformComponent>() = new TransformComponent()
        {
            WorldPosition = position,
            Rotation = rotation,
            Scale = Vector3.one
        };
    }

    public void CreateFromInstance(LinkableView linkableView)
    {
        _world.CastAndCreateLink(linkableView);
    }
}