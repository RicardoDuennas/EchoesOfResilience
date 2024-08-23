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
            //BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();
            GameObject dart = collision.gameObject;

            rb = dart.GetComponent<Rigidbody>();
            // make sure projectile sticks to surface
            rb.isKinematic = true;

            // make sure projectile moves with target
            transform.SetParent(this.transform); 

        }
    }
}
