using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerNoVRController : MonoBehaviour
{
    [SerializeField] private float speedPlayer;
    private Rigidbody rb;

    private PlayerInput playerInput;
    private InputAction moveAction;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"]; // Asegúrate de que el nombre coincida con tu configuración en el Input Action Asset
    }

    private void FixedUpdate() 
    {
        MovimientoPlayerNoRv();
    }

    private void MovimientoPlayerNoRv()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        float verticalInput = inputVector.y;

        if(verticalInput != 0)
        {
            Vector3 movement = (speedPlayer * verticalInput * Vector3.forward);
            rb.velocity = movement;
        }
    }

    void Update()
    {
        // Otros métodos o lógica pueden ir aquí
    }
}

