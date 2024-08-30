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
    public DartManager dartManager;
    [SerializeField] private bool[] targets = new bool[2];
    public ParticleSystem successParticleLeft;
    public ParticleSystem successParticleRight;
    public EscapeRoomManager escapeRoomManager;
    //public GameObject dartTemp;

    //private Rigidbody rbTemp;


    void Awake()
    {

        leftMapScript = GameObject.Find("LeftMap").GetComponent<DartReceiver>(); 
        rightMapScript = GameObject.Find("RightMap").GetComponent<DartReceiver>(); 
        targets[0] = false;
        targets[1] = false;
        //rbTemp = dartTemp.GetComponent<Rigidbody>();
    }

    void Start() {
        //rbTemp.AddForce(transform.forward, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // check if you hit an enemy
        if(collision.gameObject.CompareTag("Dart"))
        {
            dart = collision.gameObject;
            rb = dart.GetComponent<Rigidbody>();

            AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[6]);
            
            bool hit = false;

            if (leftMapScript.success && !targets[0])
            {   targets[0] = true;
                hit = true;
                successParticleLeft.Play();
                escapeRoomManager.SetPuzzleCondition(1, 0, true);
            } else if (rightMapScript.success  && !targets[1]){
                targets[1] = true;
                hit = true;
                successParticleRight.Play();
                escapeRoomManager.SetPuzzleCondition(1, 1, true);
            }
            
            if (hit){
                dart.tag = "DartAttached";
                rb.isKinematic = true;
                dart.GetComponent<XRGrabInteractable>().enabled = false;
                /////// AQUI SONIDO Y CODIGO PARA VICTORIA DARDO ///////  
            } else {
                rb.isKinematic = true;
                rb.useGravity = false;
                dart.GetComponent<XRGrabInteractable>().enabled = false;
                int posTemp = dart.name[4] - '0'; // Convert dart index to int
                Tween.LocalPosition(dart.transform, endValue: dartManager.GetDartPosition(posTemp), duration: 5);
                StartCoroutine(reactivateDart(dart));
                /////// AQUI SONIDO Y CODIGO PARA FALLO DARDO ///////  
            }
        }
    }

    IEnumerator reactivateDart(GameObject dart)
    {
        yield return new WaitForSeconds(6);
        dart.GetComponent<XRGrabInteractable>().enabled = true;      
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
