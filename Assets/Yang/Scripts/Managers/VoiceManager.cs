using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VoiceManager : MonoBehaviour
{
    [Header("≥£◊§±≥æ∞“Ù")]
    public AudioSource[] BgMusicSource; // ±≥æ∞“Ù¿÷“Ù∆µ‘¥
                                        // public AudioSource sfxSource; // “Ù–ß“Ù∆µ‘¥
    [Header("÷˜Ω«“Ù–ß")]

    public AudioSource walk;

    [Header("∆‰À˚“Ù–ß")]
    public AudioSource F;
    public AudioSource Door;



    [Header("“Ù¡øøÿ÷∆")]
    public float backgroundMusicVolume = 1.0f; // ±≥æ∞“Ù¿÷“Ù¡ø
    public float sfxVolume = 1.0f; // “Ù–ß“Ù¡ø



    public static VoiceManager Instance;


    private void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // ≥ı ºªØ“Ù¡ø
        foreach (AudioSource source in BgMusicSource)
            source.volume = backgroundMusicVolume;
        //sfxSource.volume = sfxVolume;

        // ◊¢≤·≥°æ∞º”‘ÿ ¬º˛
        //  SceneManager.sceneLoaded += PlayBackgroundMusic;


    }


    public string currentSceneName;
    private void Start()
    {
        // ªÒ»°µ±«∞≥°æ∞µƒ√˚≥∆


    }



    /// <summary>
    /// ≤•∑≈±≥æ∞“Ù¿÷
    /// </summary>
    /// <param name="clip">±≥æ∞“Ù¿÷“Ù∆µºÙº≠</param>
/*    public void PlayBackgroundMusic(Scene scene, LoadSceneMode mode)
    {

        if (currentSceneName == "chapter 3")
        {
            BgMusicSource[2].Play();
            BgMusicSource[3].Play();

            BgMusicSource[2].volume = backgroundMusicVolume;
            BgMusicSource[3].volume = backgroundMusicVolume;

        }
        else if (currentSceneName == "chapter 2" || currentSceneName == "chapter 1")
        {
            Debug.Log(currentSceneName);

            BgMusicSource[0].Play();
            BgMusicSource[1].Play();

            BgMusicSource[0].volume = backgroundMusicVolume;
            BgMusicSource[1].volume = backgroundMusicVolume;
        }
        else 
        {
            BgMusicSource[4].Play();

            BgMusicSource[4].volume = backgroundMusicVolume;

        }
       

    }*/


    public void PlayStartBGM()
    {
        StopBackgroundMusic();

        BgMusicSource[0].Play();
        BgMusicSource[0].volume = backgroundMusicVolume;
    }

    public void PlayBGM1()
    {
        StopBackgroundMusic();

        BgMusicSource[1].Play();
        BgMusicSource[1].volume = backgroundMusicVolume;
    }

    public void PlayBGM2()
    {
        StopBackgroundMusic();
        BgMusicSource[2].Play();
        BgMusicSource[2].volume = backgroundMusicVolume;

    }









    /// <summary>
    /// ‘›Õ£±≥æ∞“Ù¿÷
    /// </summary>
    public void PauseBackgroundMusic()
    {
        foreach (AudioSource source in BgMusicSource)
            source.Pause();
    }

    /// <summary>
    /// ª÷∏¥±≥æ∞“Ù¿÷
    /// </summary>
    public void ResumeBackgroundMusic()
    {
        foreach (AudioSource source in BgMusicSource)
            source.UnPause();
    }

    /// <summary>
    /// Õ£÷π±≥æ∞“Ù¿÷
    /// </summary>
    public void StopBackgroundMusic()
    {
        foreach (AudioSource source in BgMusicSource)
            source.Stop();
    }

    /// <summary>
    /// ≤•∑≈“Ù–ß
    /// </summary>
    /// <param name="clip">“Ù–ß“Ù∆µºÙº≠</param>
    public void PlaySFX(AudioClip clip)
    {
        //sfxSource.PlayOneShot(clip, sfxVolume);
    }

    /// <summary>
    /// …Ë÷√±≥æ∞“Ù¿÷“Ù¡ø
    /// </summary>
    /// <param name="volume">“Ù¡ø÷µ (0.0f µΩ 1.0f)</param>
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicVolume = volume;
        //BgMusicSource.volume = volume;
    }

    /// <summary>
    /// …Ë÷√“Ù–ß“Ù¡ø
    /// </summary>
    /// <param name="volume">“Ù¡ø÷µ (0.0f µΩ 1.0f)</param>
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        //sfxSource.volume = volume;
    }

    private void Update()
    {

    }

    public void walkVoice()
    {
        walk.Play();
    }

    public void StopWalk()
    {
        walk.Stop();
    }

    public void DoorVoice()
    {
        Door.Play();
    }


    public void FVoice()
    {
        F.Play();
    }


}