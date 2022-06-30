using System;
using JDS;
using TMPro;
using UniRx;
using Zenject;

public class LevelCounterWindowView : MonoWindow
{
    private IDisposable _levelIndexObserver;
    public TMP_Text Text;

    private IGameData<PlayerGameData> _data;

    [Inject]
    private void Inject(IGameData<PlayerGameData> data)
    {
        _data = data;
        _levelIndexObserver = _data.Get().LevelsCompletedCount.Subscribe(Observer.Create<int>(SetLevelIndex));
        SetLevelIndex(_data.Get().LevelsCompletedCount.Value);
    }

    public void SetLevelIndex(int index)
    {
        index++;
        Text.text = $"<size=40%>level</size>\n{index}";
    }

    private void OnDestroy()
    {
        _levelIndexObserver.Dispose();
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