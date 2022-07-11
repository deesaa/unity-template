using System;
using System.Linq;
using System.Reflection;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine.Scripting;

[Preserve]
public static class EcsEntityCreationExt
{
    private static MethodInfo _creationMethod;

    private static void Initialize()
    {
        _creationMethod = typeof(EcsEntityCreationExt).GetMethods()
            .First(x => x.Name == "CreateMonoLinkEntity" && x.GetParameters().Length == 2);
    }
    
    [Preserve]
    public static EcsEntity CreateUidEntity(this EcsWorld world)
    {
        var entity = world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        return entity;
    }

    [Preserve]
    public static EcsEntity CreateUidEntity<T>(this EcsWorld world) where T : struct
    {
        var entity = world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        entity.Get<T>();
        entity.Get<EventAddComponent<T>>();
        return entity;
    }

    [Preserve]
    public static EcsEntity CreateLinkedEntity<T>(this EcsWorld world, ILinkable link) where T : struct
    {
        var entity = world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        entity.Get<LinkComponent>().View = link;
        entity.Get<T>();
        entity.Get<EventAddComponent<T>>();
        link.Link(entity);
        return entity;
    }

    [Preserve]
    public static EcsEntity CastAndCreateLink(this EcsWorld world, LinkableView link)
    {
        if(_creationMethod == null)
            Initialize();
        
        var linkType = link.GetType();
        var specificMethod = _creationMethod.MakeGenericMethod(linkType);
        return (EcsEntity)specificMethod.Invoke(null, new[] { world, (object)link });
    }
    
    [Preserve]
    public static EcsEntity CreateMonoLinkEntity<TV>(this EcsWorld world, TV link) where TV : ILinkable
    {
        var entity = world.CreateMonoLinkEntityBase(link);
        return entity;
    }
    
    [Preserve]
    private static EcsEntity CreateMonoLinkEntityBase<TV>(this EcsWorld world, TV link)
        where TV : ILinkable
    {
        var entity = world.NewEntity();
        entity.Get<UIdComponent>().Value = UidGenerator.Next();
        entity.Get<MonoLinkComponent<TV>>().View = link;
        entity.Get<LinkComponent>().View = link;
        entity.Get<EventAddComponent<MonoLinkComponent<TV>>>();

        link.Link(entity);

        return entity;
    }

    [Preserve]
    public static EcsEntity CreateMonoLinkEntity<TV>(this EcsWorld world, TV link, Uid parentUid) where TV : ILinkable
    {
        var entity = world.CreateMonoLinkEntityBase(link);
        entity.Get<OwnerComponent>().Value = parentUid;
        return entity;
    }
}