using UnityEngine;

public abstract class MonoWindow : MonoBehaviour, IWindow
{
    public abstract void OnShow();
    public abstract void OnHide();
}