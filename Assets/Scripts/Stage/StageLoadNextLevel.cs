using JDS.Services.SceneLoadManager;
using Zenject;

public class StageLoadNextLevel : IGameStage
{
    [Inject] private ISceneLoadManager _sceneLoadManager;
    [Inject] private IAnalytics _analytics;
    [Inject] private IGameData<PlayerGameData> _data;
    [Inject] private IGameMeta _gameMeta;
    public void OnEnter(GameStageService service)
    {
        int levelsCompletedCount = _data.Get().LevelsCompletedCount.Value;
        int levelScenesCount = _gameMeta.LevelScenesCount;
        int targetSceneIndex = levelsCompletedCount % levelScenesCount;
        _sceneLoadManager.LoadScene(targetSceneIndex);
    }
    public void OnExit(GameStageService service) { }
    public void Update(GameStageService service){ }
    public void Init()
    {
        
    }
}