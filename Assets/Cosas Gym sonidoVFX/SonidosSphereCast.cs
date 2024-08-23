using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SonidosSphereCast : MonoBehaviour
{
    public AudioSource randomSource;
    public GameObject currentHitObject;
    public AudioClip[] sonidoEscogido;
    public float radioSphere;
    public float maxDistance;
    public LayerMask layerMask;
    private Vector3 origin, direction;
    private float currentHitDistance;
    public bool yaSono = false;

    private void Awake()
    {
         
    }
    void Start()
    {
        origin = transform.position;
        direction = -transform.up;
    }
    private void FixedUpdate()
    {
        currentHitDistance = maxDistance;
        Esfera();
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, radioSphere);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(origin, origin + direction * currentHitDistance);
    }
    private AudioClip SeleccionarElementoAleatorio(AudioClip[] array)
    {
        int indiceAleatorio = Random.Range(0, array.Length);
        return array[indiceAleatorio];
    }

    private void Esfera()
    {
        RaycastHit hit;
        if(Physics.SphereCast(origin, radioSphere, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            if(hit.transform.gameObject.CompareTag("Player"))
            {
                
                if (!yaSono)
                {
                    randomSource.PlayOneShot(SeleccionarElementoAleatorio(sonidoEscogido));
                    yaSono = true;
                }
            }
            else
            {
                yaSono = false;
            }

            currentHitObject = hit.transform.gameObject;
        }
        else
        {
            currentHitObject = null;
            yaSono = false;
        }
    }
}
