using System.Collections.Generic;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;

public static class EcsFilterExt
{
    public static bool TryGetLinkOf<T>(this EcsFilter<MonoLinkComponent<T>> filter, GameObject go, out EcsEntity entity)
        where T : ILinkable
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static T First<T>(this EcsFilter<T> filter)
        where T : struct
    {
        return filter.Get1(0);
    }

    public static bool TryGetLinkOf<T, T1>(this EcsFilter<MonoLinkComponent<T>, T1> filter, GameObject go,
        out EcsEntity entity)
        where T : ILinkable
        where T1 : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T, T1, T2>(this EcsFilter<MonoLinkComponent<T>, T1, T2> filter, GameObject go,
        out EcsEntity entity)
        where T : ILinkable
        where T1 : struct
        where T2 : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T, T1, T2, T3>(this EcsFilter<MonoLinkComponent<T>, T1, T2, T3> filter,
        GameObject go, out EcsEntity entity)
        where T : ILinkable
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf(this EcsFilter<LinkComponent> filter, GameObject go, out EcsEntity entity)
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T>(this EcsFilter<LinkComponent>.Exclude<T> filter, GameObject go,
        out EcsEntity entity)
        where T : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T>(this EcsFilter<LinkComponent, T> filter, GameObject go, out EcsEntity entity)
        where T : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T, T2>(this EcsFilter<LinkComponent, T>.Exclude<T2> filter, GameObject go,
        out EcsEntity entity)
        where T : struct
        where T2 : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T, T2>(this EcsFilter<LinkComponent, T, T2> filter, GameObject go,
        out EcsEntity entity)
        where T : struct
        where T2 : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetLinkOf<T, T2, T3>(this EcsFilter<LinkComponent, T, T2, T3> filter, GameObject go,
        out EcsEntity entity)
        where T : struct
        where T2 : struct
        where T3 : struct
    {
        foreach (var i in filter)
            if (filter.Get1(i).View.UnityInstanceId == go.GetInstanceID())
            {
                entity = filter.GetEntity(i);
                return true;
            }

        entity = EcsEntity.Null;
        return false;
    }

    public static bool TryGetParentOf(this EcsFilter<UIdComponent> filter, EcsEntity childEntity, out EcsEntity parent)
    {
        if (!childEntity.Has<OwnerComponent>())
        {
            parent = EcsEntity.Null;
            return false;
        }

        foreach (var i in filter)
            if (filter.Get1(i).Value == childEntity.Get<OwnerComponent>().Value)
            {
                parent = filter.GetEntity(i);
                return true;
            }

        parent = EcsEntity.Null;
        return false;
    }

    public static bool TryGetParentOf<T>(this EcsFilter<UIdComponent, T> filter, EcsEntity childEntity,
        out EcsEntity parent)
        where T : struct
    {
        if (!childEntity.Has<OwnerComponent>())
        {
            parent = EcsEntity.Null;
            return false;
        }

        foreach (var i in filter)
            if (filter.Get1(i).Value == childEntity.Get<OwnerComponent>().Value)
            {
                parent = filter.GetEntity(i);
                return true;
            }

        parent = EcsEntity.Null;
        return false;
    }

    public static bool TryGetParentOf<T, T2>(this EcsFilter<UIdComponent, T, T2> filter, EcsEntity childEntity,
        out EcsEntity parent)
        where T : struct
        where T2 : struct
    {
        if (!childEntity.Has<OwnerComponent>())
        {
            parent = EcsEntity.Null;
            return false;
        }

        foreach (var i in filter)
            if (filter.Get1(i).Value == childEntity.Get<OwnerComponent>().Value)
            {
                parent = filter.GetEntity(i);
                return true;
            }

        parent = EcsEntity.Null;
        return false;
    }

    public static bool TryGetParentOf<T, T2, T3>(this EcsFilter<UIdComponent, T, T2, T3> filter, EcsEntity childEntity,
        out EcsEntity parent)
        where T : struct
        where T2 : struct
        where T3 : struct
    {
        if (!childEntity.Has<OwnerComponent>())
        {
            parent = EcsEntity.Null;
            return false;
        }

        foreach (var i in filter)
            if (filter.Get1(i).Value == childEntity.Get<OwnerComponent>().Value)
            {
                parent = filter.GetEntity(i);
                return true;
            }

        parent = EcsEntity.Null;
        return false;
    }

    public static bool TryGetChildrenOf<T, T1>(this EcsFilter<OwnerComponent, T>.Exclude<T1> filter,
        EcsEntity parentEntity, in List<EcsEntity> childEntities)
        where T : struct
        where T1 : struct
    {
        if (!parentEntity.Has<UIdComponent>()) return false;

        var id = parentEntity.Get<UIdComponent>().Value;

        foreach (var i in filter)
            if (filter.Get1(i).Value == id)
                childEntities.Add(filter.GetEntity(i));

        return childEntities.Count > 0;
    }

    public static bool TryGetChildrenOf<T, T1, T3>(this EcsFilter<OwnerComponent, T, T1>.Exclude<T3> filter,
        EcsEntity parentEntity, in List<EcsEntity> childEntities)
        where T : struct
        where T1 : struct
        where T3 : struct
    {
        if (!parentEntity.Has<UIdComponent>()) return false;

        var id = parentEntity.Get<UIdComponent>().Value;

        foreach (var i in filter)
            if (filter.Get1(i).Value == id)
                childEntities.Add(filter.GetEntity(i));

        return childEntities.Count > 0;
    }
}