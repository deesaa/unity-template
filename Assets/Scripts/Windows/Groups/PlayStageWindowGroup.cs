public class PlayStageWindowGroup : WindowGroup
{
    public PlayStageWindowGroup()
    {
        AddWindow<LevelCounterWindowView>();
        AddWindow<PlayerWalletWindowView>();
        AddWindow<SettingsWindowView>();
    }
}