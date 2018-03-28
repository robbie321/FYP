using UnityEngine.Audio;
using System;
using UnityEngine;
//have a list of sounds that can easily be added or removed sounds
public class AudioManager : Singleton<AudioManager>
{
    public Sound[] sounds;
	// Use this for initialization
	public void Awake () {
        DontDestroyOnLoad(gameObject);
		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
	}
	
	public void Play(string name)
    {
       Sound s =  Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
        }
        s.source.Play();
    }

    public void Start()
    {
        Play("Theme");
    }
}
