using UnityEngine;
using System.Collections;
namespace UI.Audio
{
    [CreateAssetMenu(menuName = "AudioEvents/Simple")]
    public class SimpleAudioEvent: AudioEventSO
    {
        public AudioClip CLİP;
        
      
        public override void Play(AudioSource source)
        {

            source.clip = CLİP;            
            source.Play();
        }

    }

   
}