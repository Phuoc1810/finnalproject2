using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
    private AudioSource soundSource;
    private AudioSource musicSource;
    
    public AudioSource music2;
    public AudioSource music3;
    public AudioSource musicboss;
    public AudioSource musicfinalboss;
    //tao mot reference den AudioSource
    private AudioSource audioSource;
    //Them AudiioSource rieng cho nhac nen
    private AudioSource bgmSource;
    [SerializeField] private Slider sound;
    [SerializeField] private Slider music;
    private void Update()
    {
        changesoundvolume();
        changemusicvolume();
    }
    void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource =transform.GetChild(0).GetComponent<AudioSource>();
        music2 = transform.GetChild(1).GetComponent<AudioSource>();
        music3 = transform.GetChild(2).GetComponent<AudioSource>();
        musicboss = transform.GetChild(3).GetComponent<AudioSource>();
        musicfinalboss = transform.GetChild(4).GetComponent<AudioSource>();
        if (instance == null)
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
    public void StopBackGroundMusic(AudioClip bg_Music)
    {
        bgmSource.Stop();
    }
    public void changesoundvolume()
    {

        float setingsound = sound.value; 
        soundSource.volume = setingsound;
    }
    public void changemusicvolume()
    {
        float musicsound = music.value;
        musicSource.volume = musicsound;
        music2.volume = musicsound;
        music3.volume = musicsound;
        musicboss.volume = musicsound;
        musicfinalboss.volume = musicsound;
    }
}
