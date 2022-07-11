using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class EcsInstaller : MonoInstaller
{
    List<Type> bindSystemTypes = new List<Type>()
    {
        typeof(IEcsRunSystem),
        typeof(IEcsInitSystem),
        typeof(IGameStage)
    };
    
    public override void InstallBindings()
    {
        Container.Bind<EcsWorld>().AsSingle().NonLazy();
        Container.BindInterfacesTo<EcsBootstrap>().AsSingle();
        BindSystemsReflection();
    }

    private void BindSystemZenjectReflection()
    {
        Container.Bind<IEcsRunSystem>().To(x =>
        { 
            x.AllNonAbstractClasses().Where(type => !type.IsSealed && !type.IsGenericParameter && type.IsGenericType).DerivingFrom<IEcsRunSystem>().FromAllAssemblies();
        }).AsSingle();
        
        Container.Bind<IEcsInitSystem>().To(x =>
        { 
            x.AllNonAbstractClasses().Where(type => !type.IsSealed && !type.IsGenericParameter && type.IsGenericType).DerivingFrom<IEcsInitSystem>().FromAllAssemblies();
        }).AsSingle();
    }

    private void BindSystemsReflection()
    {
        List<Type> types = new List<Type>();
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            types.AddRange(assembly.GetTypes());
        }

        var systems = types
                .Where(x => !x.IsAbstract && !x.IsSealed && !x.IsGenericType && !x.IsGenericParameter && 
                            bindSystemTypes.Any(type => type.IsAssignableFrom(x)));
        
        foreach (var systemType in systems)
        {
            var bindMethod = typeof(DiContainer).GetMethods().First(x => x.IsGenericMethod && x.Name == "BindInterfacesAndSelfTo");
            var specificMethod = bindMethod.MakeGenericMethod(systemType);
            ((FromBinderNonGeneric)specificMethod.Invoke(Container, null)).AsSingle(); 
        }
    }
}