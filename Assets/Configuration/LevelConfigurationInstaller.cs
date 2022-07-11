using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Create LevelConfigurationInstaller", fileName = "LevelConfigurationInstaller", order = 0)]
public class LevelConfigurationInstaller : ScriptableObjectInstaller
{
    public PlayerConfiguration PlayerConfiguration;
    public LevelConfiguration LevelConfiguration;

    public override void InstallBindings()
    {
        Container.Bind<PlayerConfiguration>().FromScriptableObject(PlayerConfiguration).AsSingle();
        Container.Bind<LevelConfiguration>().FromScriptableObject(LevelConfiguration).AsSingle();
    }
}