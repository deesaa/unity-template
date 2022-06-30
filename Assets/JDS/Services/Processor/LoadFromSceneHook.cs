using System;

namespace JDS.Services.Processor
{
    public class LoadFromSceneHook : IProcess, IProgressable
    {
        public void DoProcess(Action OnComplete)
        {
            
        }

        public float Progress { get; }
    }
}