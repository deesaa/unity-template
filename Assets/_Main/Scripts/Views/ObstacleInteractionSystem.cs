using _Main.Scripts.Audio;
using _Main.Scripts.Runtime.Services;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class ObstacleInteractionSystem : IEcsRunSystem
{
    private EcsFilter<CoinComponent, TriggerEnterComponent> _coins;
    private EcsFilter<BreakableComponent, TriggerEnterComponent> _breaks;
    [Inject] private IGameData<PlayerGameData> _gameData;
    [Inject] private IAudioService _audioService;
    [Inject] private VibrationService _vibrationService;
    public void Run()
    {
        foreach (var i in _breaks)
        {
            if (_breaks.Get2(i).Other.TryGetComponent(out PlayerView playerView))
            {
                _breaks.Get1(i).Breakable.OnBreak(_breaks.Get2(i).Other.transform);
                _vibrationService.Vibrate(50);
                _audioService.PlayInstant("Glass", 3);
            }
        }
        
        foreach (var i in _coins)
        {
            if (_coins.Get2(i).Other.TryGetComponent(out PlayerView playerView))
            {
                _coins.Get1(i).OnTake();
                _gameData.Get().CoinsThisLevel += 1;
                _vibrationService.Vibrate(25);
                _audioService.PlayInstant("Coin", 3);
            }
        }
    }
}