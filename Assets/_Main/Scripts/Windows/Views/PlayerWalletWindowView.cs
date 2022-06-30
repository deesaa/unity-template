using System;
using JDS;
using TMPro;
using UniRx;
using UniRx.Triggers;
using Zenject;


public class PlayerWalletWindowView : MonoWindow
{
    private IDisposable _coinsCountObserver;
    public TMP_Text Text;
    private IGameData<PlayerGameData> _data;

    [Inject]
    private void Inject(IGameData<PlayerGameData> data)
    {
        _data = data;
        _coinsCountObserver = _data.Get().LevelsCompletedCount.Subscribe(Observer.Create<int>(SetCoinsCount));
        SetCoinsCount(_data.Get().Coins.Value);
    }

    public void SetCoinsCount(int count)
    {
        Text.text = count.ToString();
    }

    private void OnDestroy()
    {
        _coinsCountObserver.Dispose();
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