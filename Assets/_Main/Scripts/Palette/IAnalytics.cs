public interface IAnalytics
{
    public abstract void MainMenuLoaded();
    public abstract void GameplayStarted();
    public abstract void OnLevelStart(int levelIndex);
    public abstract void OnLevelFail(int levelIndex);
    public abstract void OnLevelCompleted(int levelIndex);
    public abstract void TutorialStepStarted(string stepName);
    public abstract void TutorialStepFailed(string stepName);
    public abstract void TutorialStepCompleted(string stepName);
}