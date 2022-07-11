using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WindowsInstaller : MonoInstaller
{
    public Canvas MainCanvasPrefab;
    public override void InstallBindings()
    {
        var mainCanvas = Instantiate(MainCanvasPrefab);
        var windowsPrefabs = Resources.LoadAll<MonoWindow>("Windows");
        
        foreach (var windowPrefab in windowsPrefabs)
        {
            var newWindow = Instantiate(windowPrefab, mainCanvas.transform);
            newWindow.gameObject.SetActive(false);
            Container.QueueForInject(newWindow);
            Container.BindInterfacesAndSelfTo(newWindow.GetType()).FromInstance(newWindow);
        }
        
        Container.Bind<Windows>().To<Windows>().AsSingle().WithArguments(MainCanvasPrefab);
    }
}