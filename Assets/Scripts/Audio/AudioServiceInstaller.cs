using Zenject;

namespace _Main.Scripts.Audio
{
    public class AudioServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();
        }
    }
}