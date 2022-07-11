using System;
using _Main.Scripts.Audio;
using UniRx;
using UnityEngine.UI;
using Zenject;


public class LevelCompleteWindowView : MonoWindow
{
    public Button NextLevelButton;
    public LevelRewardFormUiView RewardForm;
    public float RewardFormDelay = 1f;
    [Inject] private IGameStageService _gameStage;
    [Inject] private IGameData<PlayerGameData> _gameData;
    [Inject] private IAudioService _audioService;

    private IDisposable rewardFormTimer; 

    private void Awake()
    {
        RewardForm.gameObject.SetActive(false);
        NextLevelButton.OnClickAsObservable().Subscribe(x =>
        {
            _gameStage.ChangeStage<StageLoadNextLevel>();
        }).AddTo(gameObject);
    }

    public override void OnShow()
    {
        gameObject.SetActive(true);
        rewardFormTimer = Observable.Timer(TimeSpan.FromSeconds(RewardFormDelay)).Subscribe(x =>
        {
            RewardForm.Open(_gameData.Get().CoinsThisLevel);
            _audioService.PlayInstant("Reward", 2);
        }).AddTo(gameObject);
    }

    public override void OnHide()
    {
        rewardFormTimer.Dispose();
        gameObject.SetActive(false);
    }
}