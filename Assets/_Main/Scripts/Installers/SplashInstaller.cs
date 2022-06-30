using Zenject;

public class SplashInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        UnityEngine.Debug.Log("SplashInstaller - InstallBindings");

        Container.BindInterfacesTo<SplashInitializer>().AsSingle();
    }
}