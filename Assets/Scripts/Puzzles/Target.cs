using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private bool targetHit;
    private Rigidbody rb;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hola");
        // check if you hit an enemy
        if(collision.gameObject.CompareTag("Dart"))
        {
            AudioManager.Instance.vFXSource.PlayOneShot(AudioManager.Instance.sonidosAmbientales[6]);
            //BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();
            GameObject dart = collision.gameObject;
            dart.tag = "DartAttached";

            rb = dart.GetComponent<Rigidbody>();
            // make sure projectile sticks to surface
            Debug.Log(rb.isKinematic);
            rb.isKinematic = true;
           Debug.Log(rb.isKinematic);
 
            // Vector3 tempPos = rb.transform.position;
            // Debug.Log(rb.transform.position);
            
            // // make sure projectile moves with target
            // rb.transform.SetParent(this.transform, false); 
            // //rb.transform.position = tempPos;

            // Debug.Log(rb.transform.position);

        }
    }
}
