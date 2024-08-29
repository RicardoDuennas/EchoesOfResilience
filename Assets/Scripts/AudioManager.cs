using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource vFXSource, musicSource, afueras;
    public AudioClip[] sonidosAmbientales;
    public AudioClip[] sonidosVoces;
    [SerializeField] AudioMixer mixerGeneral;
    public bool recogioLibro = false;

    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void RecogerObjetoCorrecto()
    {
        vFXSource.PlayOneShot(sonidosAmbientales[0]);
    }

    public void PlayPositiveActionSound()
    {
        vFXSource.PlayOneShot(sonidosAmbientales[0]);
    }

    public void PlayNegativeActionSound()
    {
        vFXSource.PlayOneShot(sonidosAmbientales[1]);
    }

    public void PlayWinPuzzleSound()
    {
        vFXSource.PlayOneShot(sonidosAmbientales[6]);
    }
    public void RecogerLibro()
    {
        vFXSource.PlayOneShot(sonidosAmbientales[4]);
    }
    void Start()
    {
        afueras.PlayOneShot(sonidosAmbientales[4]);
    }

    public void StopSounds()
    {
        vFXSource.Stop();
    }

}
