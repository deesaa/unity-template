﻿using System.Collections.Generic;

namespace JDS
{
    public interface IGameState
    {
        void OnEnter();
        void OnExit();
        void MovedForward();
        void MovedBack();
    }
}