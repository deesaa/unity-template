using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine.Scripting;

[Preserve]
public class InitPlayerSystem : ReactiveSystem<EventAddComponent<MonoLinkComponent<PlayerView>>>
{
    private EcsFilter<MonoLinkComponent<CameraView>> _camera;
    protected override EcsFilter<EventAddComponent<MonoLinkComponent<PlayerView>>> ReactiveFilter { get; }
    protected override void Execute(EcsEntity entity)
    {
        var center = entity.Get<MonoLinkComponent<PlayerView>>().View;
        var camera = _camera.Get1(0).View;
        camera.SetTarget(center.transform);
    }
}