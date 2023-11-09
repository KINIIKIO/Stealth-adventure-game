using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#include <iostream>
//using namespace std;

public class PlayerMocement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float Move;
    public float jumpForce;
    private Collider playerCollider;
    [SerializeField]  // makes it so you can see the function? so public
    private bool canJump;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Land()
    {
        canJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Land();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move = Input.GetAxis("Horizontal");
        Move = 1;
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);

        if (canJump && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            canJump = false;
        }

    }

}