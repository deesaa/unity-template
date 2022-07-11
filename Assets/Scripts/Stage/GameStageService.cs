using System.Collections.Generic;
using System.Linq;
using JDS;
using Log;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Zenject;

public class GameStageService : ITickable, IGameStageService, IInitializable
{
    [Inject] private readonly IList<IGameStage> _stages;

    private IGameStage _currentStage;
    public IGameStage CurrentStage => _currentStage;

    public void Initialize()
    {
        ChangeStage<StageNull>();
    }

    public void ChangeStage<T>() where T : IGameStage
    {
        if (_currentStage != null)
        {
            DebugLog.Log($"Exit Stage: {_currentStage.GetType()}");

            _currentStage?.OnExit(this);
        }
        
        var newStage = _stages.FirstOrDefault(x => x is T);
        if (newStage != null)
        {
            _currentStage = newStage;
            DebugLog.Log($"Enter Stage: {_currentStage.GetType()}");
            _currentStage?.OnEnter(this);
        }
    }
    
    public void Tick()
    {
        _currentStage?.Update(this);
    }
}