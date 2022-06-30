using System;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;
using Zenject;

public class StageLevelCompleted : IGameStage
{
    private EcsFilter<MonoLinkComponent<PlayerView>> _player;
    private EcsFilter<MonoLinkComponent<CameraView>> _camera;
    [Inject] private EcsWorld _world;
    [Inject] private IAnalytics _analytics;
    [Inject] private IGameData<PlayerGameData> _data;
    [Inject] private ISaveGame _saveGame;
    [Inject] private Windows _windows;

    public void OnEnter(GameStageService service)
    {
        int levelsCompletedCount = _data.Get().LevelsCompletedCount.Value;
        _analytics.OnLevelCompleted(levelsCompletedCount);

        foreach (var i in _player)
        {
            
        }

        _camera.Get1(0).View.SetStage(this);
        
        _data.Get().CoinsThisLevel += 3;

        Observable.Timer(TimeSpan.FromSeconds(1.5f)).Subscribe(x => _windows.OpenWindowGroup<LevelCompleteStageWindowGroup>());
    }

    public void OnExit(GameStageService service)
    {
        int currentLevelIndex = _data.Get().LevelsCompletedCount.Value;
        currentLevelIndex++;
        _data.Get().LevelsCompletedCount.Value = currentLevelIndex;
        _saveGame.Save();
    }
    public void Update(GameStageService service){ }
    public void Init()
    {
        
    }
}