public class GameStartStageWindowGroup : WindowGroup
{
    public GameStartStageWindowGroup()
    {
        AddWindow<GameStartWindowView>();
        AddWindow<SettingsWindowView>();
        AddWindow<PlayerWalletWindowView>();
    }
}