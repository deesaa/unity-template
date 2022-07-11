using _Main.Scripts.Audio;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Zenject;

public class StageLevelStart : IGameStage
{
    private EcsFilter<MonoLinkComponent<PlayerView>> _player;
    private EcsFilter<MonoLinkComponent<CameraView>> _camera;
    [Inject] private EcsWorld _world;
    [Inject] private IAnalytics _analytics;
    [Inject] private IGameData<PlayerGameData> _data;
    [Inject] private Windows _windows;
    [Inject] private IAudioService _audioService;

    public void OnEnter(GameStageService service)
    {
        _data.Get().CoinsThisLevel = 0;
        _analytics.OnLevelStart(_data.Get().LevelsCompletedCount.Value);
        _audioService.PlayLoop("Ambient", 0.2f);
        _camera.Get1(0).View.SetStage(this);
        _windows.OpenWindowGroup<GameStartStageWindowGroup>();
    }
    public void OnExit(GameStageService service)
    {
        
    }
    public void Update(GameStageService service)
    {
        
    }
    
    public void Init()
    {
        
    }
}