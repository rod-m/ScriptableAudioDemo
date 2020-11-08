using CustomEditorExtentions;
using UnityEngine;
using UnityEngine.WSA;

namespace AudioScriptableObject
{
 
    [CreateAssetMenu(fileName = "AudioEventSimple", menuName = "Audio Events/Simple", order = 0)]
    public class AudioEventSimple : AudioEventBase
    {
        public RangedFloat volume;
        public RangedFloat pitch;

        
        public override void Play(AudioSource _source)
        {
            if (clips.Length == 0) return;
            _source.clip = clips[Random.Range(0, clips.Length)];
            _source.volume = Random.Range(volume.minValue, volume.maxValue);
            _source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        
            _source.Play();
        }
        public void Play(AudioSource _source, float _velocity)
        {
            if (clips.Length == 0) return;
            _source.volume = _velocity + Random.Range(volume.minValue, volume.maxValue);
            _source.pitch = _velocity + Random.Range(pitch.minValue, pitch.maxValue);
            Debug.Log($"Input velocity {_velocity} Volume {_source.volume} Pitch {_source.pitch}");
            _source.Play();
        }
    }
}