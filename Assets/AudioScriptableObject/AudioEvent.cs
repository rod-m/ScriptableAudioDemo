using UnityEngine;

namespace AudioScriptableObject
{
    public abstract class AudioEvent : ScriptableObject
    {
        public abstract void Play(AudioSource _source);
  
    }
}