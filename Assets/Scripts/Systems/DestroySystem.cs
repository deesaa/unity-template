using Leopotam.Ecs;
using UnityEngine.Scripting;

[Preserve]
public class DestroySystem : IEcsRunSystem
{
    private EcsFilter<LinkComponent, DestroyComponent> _toDestroy;
    public void Run()
    {
        foreach (var i in _toDestroy)
        {
            _toDestroy.Get1(i).View.Destroy();
            _toDestroy.GetEntity(i).Destroy();
        }
    }
}
