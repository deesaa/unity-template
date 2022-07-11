using System;
using UnityEngine;
using Zenject;

public class SceneData : MonoBehaviour
{
    [Inject] private ISaveGame _saveGame;

    private void OnApplicationQuit()
    {
        _saveGame.Save();
    }
}