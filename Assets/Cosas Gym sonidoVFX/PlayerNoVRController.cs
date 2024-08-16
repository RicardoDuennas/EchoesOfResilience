using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoVRController : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform feet;
    private void Awake()
    {
    }

    private void FixedUpdate() 
    {

    }

    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, feet.position.y, head.position.z);
    }
}

