using AudioScriptableObject;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class CrashingBox : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSrc;
    [SerializeField] public AudioEventEnhanced crashSFX;
   
   
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision other)
    {
        Vector3 velocity = rb.velocity;
       
        
        if (crashSFX != null)
        {
            crashSFX.Play(audioSrc, velocity.magnitude);
        }
      
    }
}
