public class PlayerDataHandler : IGameData<PlayerGameData>
{
    private readonly IDao<PlayerGameData> _dao;
    private PlayerGameData _cachedData;

    public PlayerDataHandler(IDao<PlayerGameData> dao)
    {
        _dao = dao;
    }

    public PlayerGameData Get() => _cachedData ??= _dao.Load() ?? new PlayerGameData();

    public void Update(PlayerGameData data) => _cachedData = data;

    public void Save(PlayerGameData data)
    {
        UnityEngine.Debug.Log("PlayerDataHandler Save, Coins: " + data.Coins);

        _cachedData = data;
        _dao.Save(data);
    }

    public void Delete()
    {
        _cachedData = null;
        _dao.Delete();
    }
}