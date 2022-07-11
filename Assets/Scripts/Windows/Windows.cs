using System;
using System.Collections.Generic;
using UnityEngine;

public class Windows
{
    private Canvas _mainCanvas;
    private Dictionary<Type, IWindow> _allWindows = new Dictionary<Type, IWindow>();
    private Dictionary<Type, IWindow> _openWindows = new Dictionary<Type, IWindow>();

    public Windows(Canvas mainCanvasPrefab, List<IWindow> windows)
    {
        _mainCanvas = mainCanvasPrefab;
        foreach (var window in windows)
        {
            _allWindows[window.GetType()] = window;
        }
    }
    
    public void OpenWindowGroup<T>() where T : WindowGroup, new()
    {
        var windowGroupToOpen = new T();
        foreach (var window in _allWindows)
        {
            if (windowGroupToOpen.Contains(window.Key))
            {
                OpenWindow(window.Value);
            }
            else
            {
                CloseWindow(window.Value);
            }
        }
    }

    public void OpenWindow<T>() where T : IWindow
    {
        foreach (var window in _allWindows)
        {
            if (window.Key == typeof(T))
            {
                OpenWindow(window.Value);
            }
            else
            {
                CloseWindow(window.Value);
            }
        }
    }

    private void OpenWindow(IWindow window)
    {
        if(_openWindows.ContainsValue(window))
            return;
        
        window.OnShow();
        _openWindows[window.GetType()] = window;
    }

    private void CloseWindow(IWindow window)
    {
        if(!_openWindows.ContainsValue(window))
            return;
        
        window.OnHide();
        _openWindows.Remove(window.GetType());
    }
    
    private void CloseAll()
    {
        foreach (var openWindow in _openWindows)
        {
            openWindow.Value.OnHide();
        }
        _openWindows.Clear();
    }
}