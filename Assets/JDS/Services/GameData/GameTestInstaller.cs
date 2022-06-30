using Zenject;

public class GameTestInstaller : MonoInstaller
{
    public TestPlayerData TestPlayerDataPrefab;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TestGameSystemInitializer>().AsSingle();
        Container.Bind<TestPlayerData>().FromInstance(TestPlayerDataPrefab).AsSingle();
    }
}