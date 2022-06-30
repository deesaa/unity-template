using Leopotam.Ecs;
using UnityEngine.Scripting;

[Preserve]
public class TransformSystem : IEcsRunSystem
{
    private EcsFilter<LinkComponent, TransformComponent, EventAddComponent<TransformComponent>> _transforms;

    public void Run()
    {
        foreach (var i in _transforms)
        {
            _transforms.Get1(i).View.Transform.position = _transforms.Get2(i).WorldPosition;
            _transforms.Get1(i).View.Transform.rotation = _transforms.Get2(i).Rotation;
            _transforms.Get1(i).View.Transform.localScale = _transforms.Get2(i).Scale;
            _transforms.GetEntity(i).Del<EventAddComponent<TransformComponent>>();
        }
    }
}