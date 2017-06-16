using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_CarController2 : MonoBehaviour {
    Rigidbody rb;
    public float forwardSpeed = 40f;
    //rotate
    public float rotateFactor = 100f;
    bool isGrounded;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //print(rb.angularVelocity);
        isGrounded = false;
    }
    public void Move(float hori,float veri)
    {
        if(isGrounded)
        {
            Vector3 force = transform.forward * forwardSpeed * veri;
            rb.AddForce(force);

            //Quaternion deltaRotation = Quaternion.Euler();
            //rb.MoveRotation(rb.rotation)
            rb.AddTorque(transform.up * rotateFactor * hori, ForceMode.Force);
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
