using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;


public class SettingsOpenFormView : MonoBehaviour
{
    public SwitchButton SoundToggle;
    public SwitchButton VibrationToggle;

    private SettingsFormData? _data = null;
    public bool IsOpen => _data.HasValue;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Open(SettingsFormData settingsFormData)
    {
        Assert.IsFalse(_data.HasValue);

        _data = settingsFormData;
        
        SoundToggle.Value = _data.Value.IsSoundEnabled;
        SoundToggle.RegisterValueChangedCallback(SoundEnableChanged);
        
        
        VibrationToggle.Value = _data.Value.IsVibrationEnabled;
        VibrationToggle.RegisterValueChangedCallback(VibrationEnableChanged);
        
        gameObject.SetActive(true);
    }
    

    private void SoundEnableChanged(bool newValue)
    {
        _data.Value.SoundEnableChanged(newValue);
    }
    
    private void VibrationEnableChanged(bool newValue)
    {
        _data.Value.VibrationEnableChanged(newValue);
    }

    private void OnDestroy()
    {
        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        SoundToggle.UnregisterValueChangedCallback();
        VibrationToggle.UnregisterValueChangedCallback();
        _data = null;

    }
}