using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float xThrow = Input.GetAxis("Horizontal") * walkSpeed;
        float yThrow = Input.GetAxis("Vertical") * walkSpeed;
        Vector2 walkVelocity = new Vector2(xThrow, yThrow);

        myRigidbody.velocity = walkVelocity;
    }
}
