using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    public float Zspeed = 150f;
    public float torque = 4f;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        // var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        // //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        // var z = Input.GetAxis("Vertical") * Time.deltaTime * Zspeed;

        // transform.Rotate(0, x, 0);
        // transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        //Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        //todo,rotate

        Vector3 force = moveVertical * Zspeed * transform.forward;
        rb.AddForce(force);
        transform.Rotate(0, moveHorizontal, 0);
        //rb.AddTorque(transform.up * torque * moveHorizontal);
        //rb.velocity = movement * Zspeed;
    }

    //control jump
    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
