using UnityEngine;

//To add multiple Simple Audio Event assets use Assets/Audio/Simple
namespace AudioScriptableObject
{
    [CreateAssetMenu(fileName = "AudioEventEnhanced", menuName = "Audio Events/Enhanced", order = 1)]
    public class AudioEventEnhanced : AudioEventBase
    {
        
        [MinMaxRange(0, 2)] public RangedFloat volume;
        [MinMaxRange(0, 2)] public RangedFloat pitch;

        [MinMaxRange(0.2f, 5)] public RangedFloat dopler;
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

            Play(_source);
            _source.dopplerLevel = Random.Range(dopler.minValue, dopler.maxValue);;
        
            _source.volume = _velocity + Random.Range(volume.minValue, volume.maxValue);
            _source.pitch = _velocity + Random.Range(pitch.minValue, pitch.maxValue);
            Debug.Log($"Input velocity {_velocity} Volume {_source.volume} Pitch {_source.pitch}");
            _source.Play();
        }

       
    }
}