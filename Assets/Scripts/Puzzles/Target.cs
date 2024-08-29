using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{

    private bool targetHit;
    private Rigidbody rb;
    private GameObject moonGameObject;
    private GameObject sunGameObject;
    private GameObject americaObject;
    DartReceiver moonScript;
    DartReceiver sunScript;
    DartReceiver americaScript;
    GameObject dart;
    [SerializeField] private bool[] targets = new bool[3];
    public int damage;

    void Awake()
    {

        moonScript = GameObject.Find("Moon").GetComponent<DartReceiver>(); 
        sunScript = GameObject.Find("Sun").GetComponent<DartReceiver>(); 
        americaScript = GameObject.Find("America").GetComponent<DartReceiver>(); 
        targets[0] = false;
        targets[1] = false;
        targets[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnCollisionEnter(Collision collision)
    {
        // check if you hit an enemy
        if(collision.gameObject.CompareTag("Dart"))
        {
            AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[6]);
            Debug.Log("1");

            bool hit = false;

            if (moonScript.success && !targets[0])
            {   targets[0] = true;
                hit = true;
            Debug.Log("2");
            } else if (sunScript.success  && !targets[1]){
                targets[1] = true;
                hit = true;
            Debug.Log("3");
            } else if (americaScript.success && !targets[2]){
                targets[2] = true;
                hit = true;
            Debug.Log("4");
            }
            
            if (hit){
                Debug.Log("5");
                dart = collision.gameObject;
                dart.tag = "DartAttached";

                rb = dart.GetComponent<Rigidbody>();
                // make sure projectile sticks to surface
                rb.isKinematic = true;
                dart.GetComponent<XRGrabInteractable>().enabled = false;
            } else {
                Debug.Log("6");
                Tween.Position(dart.transform, endValue: new Vector3(-53.3899994f,1.56799996f,-4.92799997f), duration: 3);
            }

        }
    }
}
