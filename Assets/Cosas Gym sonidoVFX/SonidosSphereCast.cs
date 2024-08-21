using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosSphereCast : MonoBehaviour
{
    public AudioSource randomSource;
    public GameObject currentHitObject;
    public float radioSphere;
    public float maxDistance;
    public LayerMask layerMask;
    private Vector3 origin, direction;
    private float currentHitDistance;
    public bool yaSono = false;

    void Start()
    {
        
        origin = transform.position;
        direction = -transform.up;
    }
    void Update()
    {
        currentHitDistance = maxDistance;
        RaycastHit hit;

        if(Physics.SphereCast(origin, radioSphere, direction, out hit, maxDistance,layerMask,QueryTriggerInteraction.UseGlobal))
        {
            AleatorioSonido();
            if(hit.transform.gameObject.CompareTag("Player") && AleatorioSonido() == true && yaSono == false)
            {
                randomSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[1]);
                yaSono = true;
            }
            
            currentHitObject = hit.transform.gameObject;
        }
        else{
            currentHitObject = null;
            yaSono = false;
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, radioSphere);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(origin, origin + direction * currentHitDistance);
    }

       private bool AleatorioSonido()
    {
        int numeroAleatorio = Random.Range(1, 11);
        bool eleccion = (numeroAleatorio == 1);
        Debug.Log(eleccion);
        return(eleccion);
    }
    
}
