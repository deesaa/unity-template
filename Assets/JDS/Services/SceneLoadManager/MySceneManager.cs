using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JDS.Services.Processor;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using Zenject;

namespace JDS.Services.SceneLoadManager
{
    public class MySceneManager : ISceneLoadManager, IInitializable
    {
        //public List<AsyncOperation> _processes = new List<AsyncOperation>();

        [Inject] private IGameMeta _gameMeta;
        [Inject] private MySceneManager_Settings _settings;

        private IProcessSequence _loadProcess;
        public int CurrentBuildSceneIndex;
        private int LoadingSceneIndex;

        private SplashFaderView _fader;

        public void Initialize()
        {
            _fader = GameObject.Instantiate(_settings.SplashFaderViewPrefab);
            GameObject.DontDestroyOnLoad(_fader);
        }

        public MySceneManager()
        {
            CurrentBuildSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
        
        public async void LoadScene(int levelIndex)
        {
            int buildIndex = _gameMeta.GetBuildIndexByMapIndex(levelIndex);
            _loadProcess = new LoadingProcessor()
                .Append(new FadeInProcess(_fader, _settings.FadeInDuration))
                .Append(new LoadSceneProcess(_gameMeta.LoadingSceneIndex, LoadSceneMode.Additive))
                .Append(new UnloadSceneProcess(CurrentBuildSceneIndex))
                .Append(new LoadSceneProcess(buildIndex, LoadSceneMode.Additive))
                //.Append(new LoadFromSceneHook())
                .Append(new UnloadSceneProcess(_gameMeta.LoadingSceneIndex))
                .Append(new WaitProcess(_settings.FinalWaitDuration))
                .Append(new FadeOutProcess(_fader, _settings.FadeOutDuration));

            _loadProcess.DoProcess(null);

            CurrentBuildSceneIndex = buildIndex;
        }
        

        public float GetProgress()
        {
            return _loadProcess.Progress;
        }
    }
}