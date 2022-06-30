using System;
using System.Collections.Generic;
using DG.Tweening;
using Leopotam.Ecs;
using Zenject;

public class EcsBootstrap : IInitializable, ITickable, IDisposable
{
    private IList<IEcsRunSystem> _runSystems;
    private IList<IEcsInitSystem> _initSystems;
    
    private EcsSystems _systems;
    
    private readonly EcsWorld _world;
    private readonly EcsSystems _initUpdateSystems;
    private readonly EcsSystems _lateUpdateSystems;

    public EcsBootstrap(EcsWorld world,
        IList<IEcsRunSystem> runSystems,
        IList<IEcsInitSystem> initSystems)
    {
        _runSystems = runSystems;
        _initSystems = initSystems;
        _world = world;
    }

    public void Initialize()
    {
        _systems = new EcsSystems(_world);
        foreach (var initSystem in _initSystems)
            _systems.Add(initSystem);
        foreach (var runSystem in _runSystems)
            _systems.Add(runSystem);
        DeclareOneFrames();
        
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
#endif
        
        _systems?.Init();
    }

    public void Tick()
    {
        _systems?.Run();
    }

    public void Dispose()
    {
        DOTween.KillAll();
        _systems?.Destroy();
        _world?.Destroy();
    }

    private void DeclareOneFrames()
    {
       _systems.OneFrame<TouchpadEventSwipeComponent>(); 
       _systems.OneFrame<TouchpadEventDragComponent>(); 
       _systems.OneFrame<TouchpadEventDownComponent>(); 
       _systems.OneFrame<TriggerEnterComponent>(); 
    }
}