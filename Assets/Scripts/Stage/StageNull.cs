using ECS.Utils.Extensions;
using Leopotam.Ecs;

public class StageNull : IGameStage
{
    public void OnEnter(GameStageService service) { }
    public void OnExit(GameStageService service) { }
    public void Update(GameStageService service){ }
    public void Init()
    {
        
    }
}