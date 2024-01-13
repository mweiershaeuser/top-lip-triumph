using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager global;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (global == null)
        {
            global = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("music");
    }

    public void PlayMusic(string name)
    {
        Sound music = Array.Find(musicSounds, m => m.name == name);
        if (music == null)
        {
            Debug.Log("Music not found!");
            return;
        }
        musicSource.clip = music.audio;
        musicSource.Play();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void PlaySFX(string name)
    {
        Sound sfx = Array.Find(sfxSounds, s => s.name == name);
        if (sfx == null)
        {
            Debug.Log("SFX not found!");
            return;
        }
        sfxSource.PlayOneShot(sfx.audio);
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
}
