using System;
using JDS.Services.SceneLoadManager;

namespace JDS.Services.Processor
{
    public class FadeOutProcess : IProcess
    {
        private SplashFaderView _fader;
        private float _duration; 
        public FadeOutProcess(SplashFaderView faderView, float duration)
        {
            _duration = duration;
            _fader = faderView;
        }
        
        public void DoProcess(Action OnComplete)
        {
            _fader.FadeOut(_duration, OnComplete);
        }
    }
}