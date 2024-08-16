using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonidosAleatorios : MonoBehaviour
{
    public AudioSource randomSource;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private bool AleatorioSonido()
    {
        int numeroAleatorio = Random.Range(1, 3);
        bool eleccion = (numeroAleatorio == 1);
        Debug.Log(eleccion);
        return(eleccion);
    }

    private void OnTriggerEnter(Collider other) 
    {
        
        if(other.CompareTag("Player"))
        {
            AleatorioSonido();
            if(AleatorioSonido() == true)
            {
                randomSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[1]);
            }
            else
            {
                
            }
        }
    }
}

