using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;

    //tao mot reference den AudioSource
    private AudioSource audioSource;
    //Them AudiioSource rieng cho nhac nen
    private AudioSource bgmSource;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            bgmSource = GetComponent<AudioSource>();
            bgmSource.loop = true; //Dat nhac nen tu dong lap
        }
        else Destroy(gameObject);
    }

    //phat effect 
    public void PlayOneShotAudio(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    //phat nhac nen
    public void PlayBackGroundMusic(AudioClip bgmClip)
    {
        if (bgmSource.clip == bgmClip) return; //Neu cung nhac thi khong phat lai
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }
    //Dung nhac nen
    public void StopBackGroundMusic()
    {
        bgmSource.Stop();
    }
}
