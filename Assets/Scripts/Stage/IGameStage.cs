using Leopotam.Ecs;

public interface IGameStage : IEcsInitSystem
{
    public void OnEnter(GameStageService service);
    public void OnExit(GameStageService service);
    public void Update(GameStageService service);
}