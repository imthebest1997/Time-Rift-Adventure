using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public AudioSource musicSource;
    [SerializeField] AudioClip gameMusic;

    private void Start()
    {
        musicSource.clip = gameMusic;
        musicSource.Play();
    }
    public void PlaySfx(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.PlayOneShot(clip);//Funciona sin que tengamos que asignar un clip desde properties
    }
}
