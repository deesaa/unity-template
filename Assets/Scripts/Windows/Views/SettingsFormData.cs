using System;

public struct SettingsFormData
{
    public bool IsSoundEnabled;
    public Action<bool> SoundEnableChanged;
    public bool IsVibrationEnabled;
    public Action<bool> VibrationEnableChanged;
}