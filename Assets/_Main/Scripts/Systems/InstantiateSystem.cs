using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;
[Preserve]
public class InstantiateSystem : ReactiveSystem<EventAddComponent<PrefabComponent>>, IEcsInitSystem
{
    [Inject] private IPrefabBase _prefabBase;
    [Inject] private DiContainer _container;
    
    private Dictionary<string, GameObject> _folders = new Dictionary<string, GameObject>();
    
    private MethodInfo _addMonoLink;
    protected override EcsFilter<EventAddComponent<PrefabComponent>> ReactiveFilter { get; }
    
    public void Init()
    {
        _addMonoLink = typeof(InstantiateSystem).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(x => x.Name.Contains("AddMonoLink"));
    }
    
    protected override void Execute(EcsEntity entity)
    {
        string prefabName = entity.Get<PrefabComponent>().Name;
        var prefab = _prefabBase.GetPrefab(prefabName);

        var position = entity.Get<TransformComponent>().WorldPosition;
        var rotation = entity.Get<TransformComponent>().Rotation;
        if (!_folders.ContainsKey(prefabName))
        {
            _folders[prefabName] = new GameObject($"{prefabName}_Folder");
        }
        var instance = _container.InstantiatePrefab(prefab, position, rotation, _folders[prefabName].transform);

        if (instance.TryGetComponent(out LinkableView link))
        {
            entity.GetAndFire<LinkComponent>().View = link;
            link.Link(entity);
            if (link.GetType() != typeof(LinkableView))
            {
                var genericMethod = _addMonoLink.MakeGenericMethod(link.GetType());
                genericMethod.Invoke(this, new[] {(object)entity,  link});
            }
        }
    }

    private void Aaa()
    {
        
    }

    private void AddMonoLink<T>(EcsEntity entity, T link) where T : ILinkable
    {
        entity.GetAndFire<MonoLinkComponent<T>>().View = link;
    }
}