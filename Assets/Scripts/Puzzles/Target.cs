using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;
using UnityEngine.XR.Interaction.Toolkit;

public class Target : MonoBehaviour
{

    private bool targetHit;
    private Rigidbody rb;
    private GameObject leftMapGameObject;
    private GameObject rightMapGameObject;
    DartReceiver leftMapScript;
    DartReceiver rightMapScript;
    GameObject dart;
    [SerializeField] private bool[] targets = new bool[2];
    public ParticleSystem successParticleLeft;
    public ParticleSystem successParticleRight;
    public GameObject dartTemp;
    private Rigidbody rbTemp;


    void Awake()
    {

        leftMapScript = GameObject.Find("LeftMap").GetComponent<DartReceiver>(); 
        rightMapScript = GameObject.Find("RightMap").GetComponent<DartReceiver>(); 
        targets[0] = false;
        targets[1] = false;
        rbTemp = dartTemp.GetComponent<Rigidbody>();
    }

    void Start() {
        rbTemp.AddForce(transform.forward, ForceMode.Impulse);
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
            Debug.Log("1");
            AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[6]);
            
            bool hit = false;

            if (leftMapScript.success && !targets[0])
            {   targets[0] = true;
                hit = true;
                successParticleLeft.Play();
                Debug.Log("2");
            } else if (rightMapScript.success  && !targets[1]){
                targets[1] = true;
                hit = true;
                successParticleRight.Play();
                Debug.Log("3");
            }
            
            if (hit){
                Debug.Log("4");
                dart = collision.gameObject;
                dart.tag = "DartAttached";

                rb = dart.GetComponent<Rigidbody>();

                // make sure projectile sticks to surface
                rb.isKinematic = true;
                dart.GetComponent<XRGrabInteractable>().enabled = false;
            } else {
                Debug.Log("5");
                Tween.Position(dart.transform, endValue: new Vector3(-53.3899994f,1.56799996f,-4.92799997f), duration: 3);
            }

        }
    }
}
