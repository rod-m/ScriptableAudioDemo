using System;
using UnityEngine;
using Random = UnityEngine.Random;

//To add multiple Simple Audio Event assets use Assets/Audio/Simple
[CreateAssetMenu(menuName="Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    public RangedFloat volume;

    [MinMaxRange(0, 2)]
    public RangedFloat pitch;

    [MinMaxRange(0.2f, 5)]
    public RangedFloat dopler;
    
    public override void Play(AudioSource source)
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        
        source.Play();
    }

    public override void Play(AudioSource source, float _velocity)
    {
        if (clips.Length == 0) return;
        source.dopplerLevel = Random.Range(dopler.minValue, dopler.maxValue);;
        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = _velocity + Random.Range(volume.minValue, volume.maxValue);
        source.pitch = _velocity + Random.Range(pitch.minValue, pitch.maxValue);
        Debug.Log(String.Format("Input velocity {0} Volume {1} Pitch {2}", _velocity, source.volume, source.pitch));
        source.Play();
    }
}