using Zenject;

namespace _Main.Scripts.Runtime.Services
{
    public class VibrationService : IInitializable
    {
        [Inject] private IGameData<PlayerGameData> _data;
        public void Initialize() { }

        public void Vibrate(long mlseconds)
        {
            if(!_data.Get().IsVibrationEnabled)
                return;
            
            Vibration.Vibrate(mlseconds);
        }
    }
}