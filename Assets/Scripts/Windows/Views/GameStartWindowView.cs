using System;
using Leopotam.Ecs;
using UniRx;
using UnityEngine.UI;
using Zenject;

public class GameStartWindowView : MonoWindow
{
    public Button StartButton;
    [Inject] private IGameStageService _gameStage;

    private void Awake()
    {
        StartButton.OnClickAsObservable().Subscribe(x =>
        {
            _gameStage.ChangeStage<StagePlay>();
        }).AddTo(gameObject);
    }

    public override void OnShow()
    {
        gameObject.SetActive(true);
    }

    public override void OnHide()
    {
        gameObject.SetActive(false);
    }
}