using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchButton : MonoBehaviour
{
    public Button Button;
    public Sprite SwitchOnSprite;
    public Sprite SwitchOffSprite;
    
    private Action<bool> _valueChanged;
    

    private bool _value;
    public bool Value
    {
        get => _value;
        set
        {
            _value = value;
            Button.image.sprite = _value ? SwitchOnSprite : SwitchOffSprite;
            _valueChanged?.Invoke(_value);
        }
    }

    public void RegisterValueChangedCallback(Action<bool> valueChanged)
    {
        _valueChanged = valueChanged;
    }

    public void UnregisterValueChangedCallback()
    {
        _valueChanged = null;
    }
    
    
    protected void Awake()
    {
        Button = GetComponent<Button>();
        Button.OnClickAsObservable().Subscribe(x =>
        {
            Value = !Value;
        }).AddTo(gameObject);
    }

    
    protected  void OnDestroy()
    {
        UnregisterValueChangedCallback();
    }
}