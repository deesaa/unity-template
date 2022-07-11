using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    public PrefabBase PrefabBase;
    public MaterialBase MaterialBase;
    public SceneData SceneData;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PrefabBase>().FromScriptableObject(PrefabBase).AsSingle();
        Container.BindInterfacesAndSelfTo<MaterialBase>().FromScriptableObject(MaterialBase).AsSingle();
        Container.BindInterfacesTo<LevelInitializer>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameObjectFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<GameStageService>().AsSingle();
        Container.BindInstance(SceneData).AsSingle();
    }
}