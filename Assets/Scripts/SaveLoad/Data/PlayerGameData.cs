using System;
using System.Collections.Generic;
using JDS;
using Leopotam.Ecs;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;

public class PlayerGameData
{
    [JsonIgnore]
    private List<SavedEntity> _savedEntities;
    public PlayerGameData()
    {
        _savedEntities = new List<SavedEntity>();

        IsSoundEnabled.Value = true;
        IsVibrationEnabled = true;
        UpdateVersion = 0;
    }
    public void ClearSavedEntities() => _savedEntities.Clear();
    public void WriteEntity(EcsEntity entity) => _savedEntities.Add(new SavedEntity(entity));

    public List<SavedEntity> SavedEntities
    {
        get => _savedEntities;
        set => _savedEntities = value;
    }

    public ReactiveProperty<int> LevelsCompletedCount = new ReactiveProperty<int>();
    public ReactiveProperty<int> Coins = new ReactiveProperty<int>();
    public ReactiveProperty<bool> IsSoundEnabled = new ReactiveProperty<bool>();
    
    public bool IsVibrationEnabled;
    public int UpdateVersion;
    public int CoinsThisLevel;
}