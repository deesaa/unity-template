using System;

namespace JDS.Services.Processor
{
    public interface IProcess
    {
        public void DoProcess(Action OnComplete);
    }
}