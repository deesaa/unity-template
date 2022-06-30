using UniRx;
using UnityEngine.UI;
using Zenject;

public class SettingsWindowView : MonoWindow
{
    public Button OpenSettingsButton;
    private IGameData<PlayerGameData> _data;

    public SettingsOpenFormView SettingsOpenFormView;

    [Inject]
    private void Inject(IGameData<PlayerGameData> data)
    {
        _data = data;

        OpenSettingsButton.OnClickAsObservable().Subscribe(x =>
        {
            if (SettingsOpenFormView.IsOpen)
            {
                SettingsOpenFormView.Close();
                return;
            }

            var currentData = _data.Get();
            
            SettingsOpenFormView.Open(new SettingsFormData()
            {
                IsSoundEnabled = currentData.IsSoundEnabled.Value,
                IsVibrationEnabled = currentData.IsVibrationEnabled,
                SoundEnableChanged = enabled =>
                {
                    currentData.IsSoundEnabled.Value = enabled;
                },
                VibrationEnableChanged = enabled =>
                {
                    currentData.IsVibrationEnabled = enabled;
                }
            });
        }).AddTo(gameObject);
    }
    
    private void OnDestroy()
    {
       
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