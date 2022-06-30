using System;
using _Main.Scripts.Audio;
using ECS.Utils.Extensions;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<MonoLinkComponent<PlayerView>, PlayerComponent> _player;
    private EcsFilter<TouchpadEventSwipeComponent> _swipe;
    [Inject] private PlayerConfiguration Configuration;
    [Inject] private IGameStageService _gameStage;
    [Inject] private IGameData<PlayerGameData> _gameData;
    [Inject] private IAudioService _audioService;
    private EcsWorld _world;
    public void Run()
    {
        if(_player.IsEmpty())
            return;
        if(_swipe.IsEmpty())
            return;

        if(_gameStage.CurrentStage is not StagePlay) 
            return;

        var delta = _swipe.Get1(0).Delta.normalized;
    }
    
    public void CheckWin()
    {
        _gameStage.ChangeStage<StageLevelCompleted>();
    }
}