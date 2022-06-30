﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace JDS
{
    public class BindBehaviour<T> : MonoBehaviour
    {
        private readonly List<BindHandler<T>> _bindHandlers = new List<BindHandler<T>>();
        
        private void OnDestroy()
        {
            foreach (var bindHandler in _bindHandlers)
            {
                bindHandler.Destroy();
            }
            AfterDestroy();
        }

        protected void Bind(T valueType, Action<object> action, ReactiveCore<T> parent)
        {
            _bindHandlers.Add(parent.Bind(valueType, action));
        }

        protected virtual void AfterDestroy() { }
    }
}