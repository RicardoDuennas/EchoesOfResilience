using UnityEngine;
using System.Collections;

public class DartReceiver : MonoBehaviour {


    [SerializeField] private int index;
    public bool success = false;

    void OnTriggerEnter(Collider collision) {
        // check if you hit an enemy
        if(collision.gameObject.CompareTag("Dart"))
        {
            success = true;
        }
    }
}