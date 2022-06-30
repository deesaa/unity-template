using UnityEngine;
using Zenject;

public class TestPlayerData : MonoBehaviour
{
    [Inject] private IGameData<PlayerGameData> _playerData;

    private void Update()
    {
        return;
    }
}