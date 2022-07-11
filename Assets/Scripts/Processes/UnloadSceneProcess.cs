using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JDS.Services.Processor
{
    public class UnloadSceneProcess : IProcess, IProgressable
    {
        private int _sceneIndex;
        private AsyncOperation _operation;
        private Action _onCompleted;
        
        public UnloadSceneProcess(int sceneIndex)
        {
            _sceneIndex = sceneIndex;
        }
        
        public void DoProcess(Action OnComplete)
        {
            _onCompleted = OnComplete;
            _operation = SceneManager.UnloadSceneAsync(_sceneIndex);
            _operation.completed += Completed;
        }

        private void Completed(AsyncOperation obj)
        {
            _operation.completed -= Completed;
            _onCompleted();
        }

        public float Progress => _operation.progress;
    }
}