using System;
using JDS.Services.SceneLoadManager;
using UniRx;

namespace JDS.Services.Processor
{
    public class WaitProcess : IProcess
    {
        private SplashFaderView _fader;
        private float _duration; 
        public WaitProcess(float duration)
        {
            _duration = duration;
        }
        
        public void DoProcess(Action OnComplete)
        {
            Observable.Timer(TimeSpan.FromSeconds(_duration)).Subscribe(x => OnComplete());
        }
    }
}