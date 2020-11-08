using UnityEngine;

namespace AudioScriptableObject
{
    public abstract class AudioEventBase : ScriptableObject
    {
        public AudioClip[] clips;

        public abstract void Play(AudioSource _source);
  
    }
}