using System;
using System.Collections.Generic;

public class WindowGroup
{
    private List<Type> _windows = new List<Type>();
    protected void AddWindow<T>() where T : IWindow
    {
        if(!_windows.Contains(typeof(T)))
            _windows.Add(typeof(T));
    }

    public bool Contains(Type type)
    {
        return _windows.Contains(type);
    }

    public List<Type> Windows => _windows;
}