using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private Vector3 movement;
    private Rigidbody charRB;

    void Start()
    {
        charRB = GetComponent<Rigidbody>();
        charRB.useGravity = false;
    }
    
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        movement = transform.right * x + transform.forward * z;
        charRB.MovePosition(transform.position + movement.normalized * movementSpeed * Time.deltaTime);
    }
}
