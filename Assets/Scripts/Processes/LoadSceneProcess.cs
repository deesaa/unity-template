using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JDS.Services.Processor
{
    public class LoadSceneProcess : IProcess, IProgressable
    {
        private int _sceneIndex;
        private AsyncOperation _operation;
        private Action _onCompleted;
        private LoadSceneMode _loadSceneMode;
        
        public LoadSceneProcess(int sceneIndex, LoadSceneMode loadSceneMode)
        {
            _sceneIndex = sceneIndex;
            _loadSceneMode = loadSceneMode;
        }
        
        public void DoProcess(Action OnComplete)
        {
            _onCompleted = OnComplete;
            Debug.Log("LOADING SCENE : " + _sceneIndex);
            _operation = SceneManager.LoadSceneAsync(_sceneIndex, _loadSceneMode);
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