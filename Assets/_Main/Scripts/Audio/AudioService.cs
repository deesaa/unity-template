using System;
using System.Collections.Generic;
using JDS;
using ModestTree;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Main.Scripts.Audio
{
    public class AudioService : IAudioService, IInitializable
    {
        [Inject] private IGameData<PlayerGameData> _data;

        private Dictionary<string, AudioClip> _clips = new();
        private Dictionary<string, SourceGroup> _sourceGroups = new();

        private int _audioSourceCount = 3;
        private int _currentAudioSource = 0;

        private IDisposable _soundSwitchObserver;

        private Transform _container;

        private int GetNextAudioSource()
        {
            var x = _currentAudioSource;
            _currentAudioSource++;
            if (_currentAudioSource >= _audioSourceCount)
                _currentAudioSource = 0;
            return x;
        }
        
        private List<AudioSource> _audioInstantSources = new List<AudioSource>();
        private AudioSource _audioSourceLoop;
        
        public void Initialize()
        {
            var clips = Resources.LoadAll<AudioClip>("Sound");
            foreach (var audioClip in clips)
            {
                _clips[audioClip.name] = audioClip;
            }

            _container = new GameObject("Audio Sources Container").transform;

            for (int i = 0; i < _audioSourceCount; i++)
            {
                var source = new GameObject().AddComponent<AudioSource>();
                source.transform.parent = _container;
                _audioInstantSources.Add(source);
            }
            
            _audioSourceLoop = new GameObject().AddComponent<AudioSource>();
            _audioSourceLoop.transform.parent = _container;
            
            GameObject.DontDestroyOnLoad(_container.gameObject);
            _soundSwitchObserver = _data.Get().IsSoundEnabled.Subscribe(Observer.Create<bool>(SoundEnableChanged));
        }

        private void SoundEnableChanged(bool value)
        {
            _audioSourceLoop.enabled = value;
            foreach (var audioInstantSource in _audioInstantSources)
            {
                audioInstantSource.enabled = value;
            }
        }

        public void PlayLoop(string name, float volume = 1, float pitch = 1)
        {
            if(!_data.Get().IsSoundEnabled.Value)
                return;
            if(!_clips.ContainsKey(name))
                return;
            
            _audioSourceLoop.Stop();
            _audioSourceLoop.loop = true;
            _audioSourceLoop.pitch = pitch;
            _audioSourceLoop.volume = volume;
            _audioSourceLoop.clip = _clips[name];
            _audioSourceLoop.Play();
        }

        public void PlayEnable(string name, bool enable, int sourceId, int maxSources, float volume = 1, float pitch = 1)
        {
            if (!_sourceGroups.ContainsKey(name))
                _sourceGroups[name] = new SourceGroup(_container, _clips[name], volume, pitch);

            enable = _data.Get().IsSoundEnabled.Value & enable;

            var source = _sourceGroups[name];
            if (enable)
            {
                if (!source.PlayingSources.Contains(sourceId))
                {
                    source.PlayingSources.Add(sourceId);
                }
            }
            else
            {
                if (source.PlayingSources.Contains(sourceId))
                {
                    source.PlayingSources.Remove(sourceId);
                }
            }

            source.AudioSource.enabled = !source.PlayingSources.IsEmpty();
        }

        public void PlayInstant(string name, int range, float volume = 1, float pitch = 1)
        {
            if(range != -1)
                name = name + Random.Range(0, range);
            
            if(!_data.Get().IsSoundEnabled.Value)
                return;
            if(!_clips.ContainsKey(name))
                return;
            
            var source = _audioInstantSources[GetNextAudioSource()];
            source.pitch = pitch;
            source.volume = volume;
            source.PlayOneShot(_clips[name]);
        }
    }
}