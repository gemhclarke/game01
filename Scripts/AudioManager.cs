using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    //private float pitchVar;
   

    
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds){
            
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        } 
    }

    // Update is called once per frame
    public void Play(string name, float pitch)
    {
        Sound s = Array.Find(sounds, match: sound => sound.name == name);
        s.source.pitch = pitch;
        s.source.Play();
    }
}
