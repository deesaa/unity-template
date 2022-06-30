using System.Collections.Generic;
using UnityEngine;

public class SourceGroup
{
    public string ClipName;
    public List<int> PlayingSources = new();
    public AudioSource AudioSource;

    public SourceGroup(Transform _container, AudioClip clip, float volume = 1, float pitch = 1)
    {
        AudioSource = new GameObject().AddComponent<AudioSource>();
        AudioSource.clip = clip;
        AudioSource.loop = true;
        AudioSource.pitch = pitch;
        AudioSource.volume = volume;
        AudioSource.transform.parent = _container;
    }
}