using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class my_CarController2 : MonoBehaviour {
    Rigidbody rb;
    public float forwardSpeed = 40000f;
    //rotate
    public float rotateFactor = 5000f;
    public bool isGrounded;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //print(rb.angularVelocity);
        isGrounded = false;
    }
    public void Move(float hori,float veri)
    {
        //if(isGrounded)
        //{
        //    Vector3 force = transform.forward * forwardSpeed * veri;
        //    rb.AddForce(force);

        //    //Quaternion deltaRotation = Quaternion.Euler();
        //    //rb.MoveRotation(rb.rotation)
        //    rb.AddTorque(transform.up * rotateFactor * hori, ForceMode.Force);
        //    Debug.Log("move");
        //}
        Vector3 force = transform.forward * forwardSpeed * veri;
        rb.AddForce(force);
        rb.AddTorque(transform.up * rotateFactor * hori, ForceMode.Force);
        //Debug.Log(hori+":"+veri);
    }
    void OnCollisionStay(Collision coll)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
