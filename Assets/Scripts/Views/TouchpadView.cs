using System;
using Lean.Touch;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchpadView : LinkableView
{
    private LeanFinger _activeFinger;
    
    private void Awake()
    {
        Lean.Touch.LeanTouch.OnFingerSwipe += OnFingerSwipe;
        Lean.Touch.LeanTouch.OnFingerDown += OnFingerDown;
        Lean.Touch.LeanTouch.OnFingerUp += OnFingerUp;
    }

    private void OnFingerUp(LeanFinger obj)
    {
        _activeFinger = null;
    }

    private void OnFingerDown(LeanFinger obj)
    {
        _activeFinger = obj;
    }

    private void Update()
    {
        if(_activeFinger == null)
            return;

        Entity.Get<TouchpadEventDragComponent>() = new TouchpadEventDragComponent()
        {
            Delta = _activeFinger.ScaledDelta
        };
    }

    private void OnFingerSwipe(LeanFinger obj)
    {
        Entity.Get<TouchpadEventSwipeComponent>() = new TouchpadEventSwipeComponent()
        {
            Delta = obj.SwipeScaledDelta
        };
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        return;
        Entity.Get<TouchpadEventDownComponent>() = new TouchpadEventDownComponent()
        {
            Position = eventData.position
        };
    }

    private void OnDestroy()
    {
        Lean.Touch.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
    }
}