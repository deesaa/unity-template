using System;
using _Main.Scripts.Runtime.Services;
using JDS.Services.SceneLoadManager;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public GameMeta GameMeta;
    public MySceneManager_Settings SceneManagerSettings;
    public override void InstallBindings()
    {
        UnityEngine.Debug.Log("ProjectInstaller - InstallBindings");
        SignalBusInstaller.Install(Container);
        Container.BindInterfacesAndSelfTo<GameMeta>().FromScriptableObject(GameMeta).AsSingle();
        Container.BindInterfacesAndSelfTo<MySceneManager>().AsSingle();
        Container.Bind<MySceneManager_Settings>().FromScriptableObject(SceneManagerSettings).AsSingle();
        Container.BindInterfacesAndSelfTo<VibrationService>().AsSingle();
        //Container.Bind<IAnalytics>().To<HomaAnalytics>().AsSingle();
        Container.Bind<IAnalytics>().To<EmptyAnalytics>().AsSingle();
        Application.targetFrameRate = 200;
    }
}