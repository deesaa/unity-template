using System.Collections.Generic;
using System.IO;
using JDS.Services.SceneLoadManager;
using UnityEngine;
using Zenject;


public class SplashInitializer : IInitializable
{
    [Inject] private ISceneLoadManager _sceneLoadManager;
    [Inject] private IGameMeta _gameMeta;
    [Inject] private IGameData<PlayerGameData> _gameData;

    public void Initialize()
    {
        UnityEngine.Debug.Log("SplashInitializer - Initialize");
        var currentData = _gameData.Get();
        if (currentData.UpdateVersion != _gameMeta.UpdateVersion)
        {
            UnityEngine.Debug.Log("SplashInitializer - New currentData");

            _gameData.Delete();
            currentData = _gameData.Get();
            currentData.LevelsCompletedCount.Value = _gameMeta.FirstPlaySceneIndex;
            currentData.UpdateVersion = _gameMeta.UpdateVersion;
        }
        UnityEngine.Debug.Log("SplashInitializer - _sceneLoadManager.LoadScene; CurrentUpdateVersion = " + currentData.UpdateVersion.ToString());
        
        int levelsCompletedCount = currentData.LevelsCompletedCount.Value;
        int levelScenesCount = _gameMeta.LevelScenesCount;
        int targetSceneIndex = levelsCompletedCount % levelScenesCount;
        _sceneLoadManager.LoadScene(targetSceneIndex);
    }
}