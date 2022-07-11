using System;
using JDS.Services.SceneLoadManager;

namespace JDS.Services.Processor
{
    public class FadeInProcess : IProcess
    {
        private SplashFaderView _fader;
        private float _duration; 
        public FadeInProcess(SplashFaderView faderView, float duration)
        {
            _duration = duration;
            _fader = faderView;
        }
        
        public void DoProcess(Action OnComplete)
        {
            _fader.FadeIn(_duration, OnComplete);
        }
    }
}