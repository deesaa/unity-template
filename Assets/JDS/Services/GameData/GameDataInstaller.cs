using Zenject;

public class GameDataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LocalDao<PlayerGameData>>().AsSingle().WithArguments("PlayerGameData");
        Container.BindInterfacesAndSelfTo<PlayerDataHandler>().AsSingle();
    }
}