﻿using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
public abstract class ReactiveSystem<T> : IEcsRunSystem where T : struct
{
    protected abstract EcsFilter<T> ReactiveFilter { get; }
    protected virtual bool EntityFilter(EcsEntity entity) => true;
    protected virtual bool DeleteEvent => true;
    public void Run()
    {
        foreach (var i in ReactiveFilter)
        {
            var entity = ReactiveFilter.GetEntity(i);
            if (EntityFilter(entity))
                Execute(entity);
            if(DeleteEvent)
                entity.Del<T>();
        }
    }
    protected abstract void Execute(EcsEntity entity);
}