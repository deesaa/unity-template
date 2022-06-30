using Zenject;

public class StageLevelFail : IGameStage
{
    [Inject] private IAnalytics _analytics;
    [Inject] private IGameData<PlayerGameData> _data;
    public void Init()
    {
        
    }
    
    public void OnEnter(GameStageService service)
    {
        _analytics.OnLevelFail(_data.Get().LevelsCompletedCount.Value);
    }

    public void OnExit(GameStageService service)
    {
       
    }

    public void Update(GameStageService service)
    {
       
    }
}