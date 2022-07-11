using System;
using System.Collections.Generic;
using System.Linq;

namespace JDS.Services.Processor
{
    public class LoadingProcessor : IProcessSequence
    {
        private List<IProgressable> _progressables = new List<IProgressable>();
        private Queue<IProcess> _processes = new Queue<IProcess>();
        private Action _onComplete;

        public IProcessSequence Append(IProcess process)
        {
            if(process is IProgressable progressable)
                _progressables.Add(progressable);

            _processes.Enqueue(process);
            return this;
        }

        private void OnProcessComplete()
        {
            if (_processes.Count == 0)
            {
                _onComplete?.Invoke();
                return;
            }
            DoProcess(_onComplete);
        }

        public float Progress
        {
            get { return _progressables.Sum(progressable => progressable.Progress) / _progressables.Count; }
        }

        public void DoProcess(Action OnComplete)
        {
            _onComplete = OnComplete;
            var process = _processes.Dequeue();
            process.DoProcess(OnProcessComplete);
        }
    }
}