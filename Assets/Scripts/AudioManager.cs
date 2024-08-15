using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource vFXSource, musicSource;
    public AudioClip[] sonidosAmbientales;
    public AudioClip[] sonidosVoces;
    [SerializeField] AudioMixer mixerGeneral;

    private static AudioManager instance;

    public static AudioManager Instance {get{return instance;}}

    private void Awake() {
            if ( instance == null )
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
