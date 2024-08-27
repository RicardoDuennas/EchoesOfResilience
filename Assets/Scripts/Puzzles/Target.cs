using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] private bool[] darts = new bool[3];
    public int damage;

    void Awake()
    {

        moonScript = GameObject.Find("Moon").GetComponent<DartReceiver>(); 
        sunScript = GameObject.Find("Sun").GetComponent<DartReceiver>(); 
        americaScript = GameObject.Find("America").GetComponent<DartReceiver>(); 
        darts[0] = false;
        darts[1] = false;
        darts[2] = false;
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
            bool hit = false;

            if (moonScript.success && !darts[0])
            {   darts[0] = true;
                hit = true;
            } else if (sunScript.success  && !darts[1]){
                darts[1] = true;
                hit = true;
            } else if (americaScript.success && !darts[2]){
                darts[2] = true;
                hit = true;
            }
            
            if (hit){
                GameObject dart = collision.gameObject;
                dart.tag = "DartAttached";

                rb = dart.GetComponent<Rigidbody>();
                // make sure projectile sticks to surface
                rb.isKinematic = true;
                dart.GetComponent<XRGrabInteractable>().enabled = false;
            } else {

            }

        }
    }
}
