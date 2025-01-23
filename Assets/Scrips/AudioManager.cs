using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource sfx;

    public AudioClip BrMusic;
    public AudioClip click;

    public void PlayMucsic()
    {
        music.clip = BrMusic;
        music.Play();
        music.loop = true;
    }

     public void PlaySFXSound(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void stopBackMusic()
    {
        music.Stop();
    }

}
