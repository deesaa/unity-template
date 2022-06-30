public class LevelCompleteStageWindowGroup : WindowGroup
{
    public LevelCompleteStageWindowGroup()
    {
        AddWindow<LevelCompleteWindowView>();
        AddWindow<PlayerWalletWindowView>();
        AddWindow<SettingsWindowView>();
    }
}