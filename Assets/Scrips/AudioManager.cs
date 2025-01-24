using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; 
    [SerializeField] AudioSource sfxSource;    

    public AudioClip backgroundMusic; // đầu vào âm thanh
    public AudioClip tab; // đầu vào khi người dùng nhân vào màn hình
    public void PlayBackgroundMusic()
    {
        musicSource.loop = true; // Lặp  nhạc nền
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFXSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

}
