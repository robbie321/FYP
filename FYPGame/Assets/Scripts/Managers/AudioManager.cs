using UnityEngine.Audio;
using System;
using UnityEngine;
//have a list of sounds that can easily be added or removed sounds
public class AudioManager : MonoBehaviour {
    public Sound[] sounds;
    public static AudioManager instance;
	// Use this for initialization
	void Awake () {
        /*
         only want one instance of audio manager so sounds dont ccut off 
         between scenes and restart
         */
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
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
