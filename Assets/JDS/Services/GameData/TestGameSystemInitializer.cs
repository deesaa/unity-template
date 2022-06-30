using Zenject;

public class TestGameSystemInitializer : IInitializable
{
    [Inject] private DiContainer Container;
    [Inject] private TestPlayerData PlayerDataPrefab;

    public void Initialize()
    {
        Container.InstantiatePrefab(PlayerDataPrefab);
    }
}