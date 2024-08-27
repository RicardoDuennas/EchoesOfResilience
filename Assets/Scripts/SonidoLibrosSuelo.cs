using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoLibrosSuelo : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[5]);
    }
}
