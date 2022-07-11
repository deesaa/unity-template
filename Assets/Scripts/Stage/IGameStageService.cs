public interface IGameStageService
{
    public void ChangeStage<T>() where T : IGameStage;
    IGameStage CurrentStage { get; }
}