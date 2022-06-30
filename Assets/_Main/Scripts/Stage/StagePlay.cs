using ECS.Utils.Extensions;
using Leopotam.Ecs;
using Zenject;

public class StagePlay : IGameStage
{
    [Inject] private IAnalytics _analytics;
    [Inject] private IGameData<PlayerGameData> _data;
    [Inject] private Windows _windows;

    public void OnEnter(GameStageService service)
    {
        _analytics.GameplayStarted();
        _windows.OpenWindowGroup<PlayStageWindowGroup>();
    }
    public void OnExit(GameStageService service) { }
    public void Update(GameStageService service){ }
    public void Init()
    {
        
    }
}