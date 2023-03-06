using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioManager : MonoBehaviour
{
    public Sound[] sound;
    public static audioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip= s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
         // s.source.loop = s.loop;
        }
    }

    public void play(string name)
    {
        Sound s= Array.Find(sound, sound => sound.name == name);
     
        s.source.Play();
    }

    public void stop(string name)
    {
        Sound s= Array.Find(sound, sound => sound.name == name);
     
        s.source.Stop();
    }
}
