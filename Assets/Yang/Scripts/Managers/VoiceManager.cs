using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VoiceManager : MonoBehaviour
{
    [Header("��פ������")]
    public AudioSource[] BgMusicSource; // ����������ƵԴ
                                        // public AudioSource sfxSource; // ��Ч��ƵԴ
    [Header("������Ч")]

    public AudioSource walk;

    [Header("������Ч")]
    public AudioSource F;
    public AudioSource Door;



    [Header("��������")]
    public float backgroundMusicVolume = 1.0f; // ������������
    public float sfxVolume = 1.0f; // ��Ч����



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

        // ��ʼ������
        foreach (AudioSource source in BgMusicSource)
            source.volume = backgroundMusicVolume;
        //sfxSource.volume = sfxVolume;

        // ע�᳡�������¼�
        //  SceneManager.sceneLoaded += PlayBackgroundMusic;


    }


    public string currentSceneName;
    private void Start()
    {
        // ��ȡ��ǰ����������


    }



    /// <summary>
    /// ���ű�������
    /// </summary>
    /// <param name="clip">����������Ƶ����</param>
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
    /// ��ͣ��������
    /// </summary>
    public void PauseBackgroundMusic()
    {
        foreach (AudioSource source in BgMusicSource)
            source.Pause();
    }

    /// <summary>
    /// �ָ���������
    /// </summary>
    public void ResumeBackgroundMusic()
    {
        foreach (AudioSource source in BgMusicSource)
            source.UnPause();
    }

    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void StopBackgroundMusic()
    {
        foreach (AudioSource source in BgMusicSource)
            source.Stop();
    }

    /// <summary>
    /// ������Ч
    /// </summary>
    /// <param name="clip">��Ч��Ƶ����</param>
    public void PlaySFX(AudioClip clip)
    {
        //sfxSource.PlayOneShot(clip, sfxVolume);
    }

    /// <summary>
    /// ���ñ�����������
    /// </summary>
    /// <param name="volume">����ֵ (0.0f �� 1.0f)</param>
    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicVolume = volume;
        //BgMusicSource.volume = volume;
    }

    /// <summary>
    /// ������Ч����
    /// </summary>
    /// <param name="volume">����ֵ (0.0f �� 1.0f)</param>
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