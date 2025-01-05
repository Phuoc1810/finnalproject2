using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumesetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider musicSlider;
    public AudioSource music;

    private void Update()
    {
        float sound = musicSlider.value;
        music.volume = sound;
    }
    
}