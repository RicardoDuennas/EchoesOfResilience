using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoLibrosSuelo : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = AudioManager.Instance.vFXSource;
        audioSource.enabled = false; 
        Invoke("EnableAudioSource", 0.5f);
    }

    void EnableAudioSource()
    {
        audioSource.enabled = true;
    }

    private void OnCollisionEnter(Collision other) {
        AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[7]);
    }
}
