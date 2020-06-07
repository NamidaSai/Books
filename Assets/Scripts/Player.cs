using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;

    [SerializeField] Transform grabbedObject = null;

    Rigidbody2D myRigidbody;
    BoxCollider2D myGrabCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myGrabCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Move();
        Grab();
    }

    private void Move()
    {
        float xThrow = Input.GetAxis("Horizontal") * walkSpeed;
        float yThrow = Input.GetAxis("Vertical") * walkSpeed;
        Vector2 walkVelocity = new Vector2(xThrow, yThrow);

        myRigidbody.velocity = walkVelocity;
    }

    private void Grab()
    {
        bool playerIsInGrabDistance = myGrabCollider.IsTouchingLayers(LayerMask.GetMask("Moveable Objects"));
        if (Input.GetKey(KeyCode.Space) && playerIsInGrabDistance)
        {
            float distance = Vector2.Distance(grabbedObject.position, transform.position);

            if (distance != 1f)
            {
                distance = 1f;
                grabbedObject.position = (grabbedObject.position - transform.position).normalized * distance + transform.position;
            }
        }
    }
}
