﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChangeVolume : MonoBehaviour
{
    public AudioMixer audioMixer;
   public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
