using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixerGroup audioMixer;
    public Sound[] sounds;
    //private float volume = 0.5f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            //Update();
            //s.volume = volume;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = audioMixer;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Play("Music");
    }

    public void Play(string name)
    {
        //AudioMixer mixer = Resources.Load("MaasterMixer") as AudioMixer;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    //public void SetVolume(float vol)
    //{
        //volume = vol;
    //}
}
