using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_CarController2 : MonoBehaviour {
    Rigidbody rb;
    public float forwardSpeed = 40f;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Move(float hori,float veri)
    {
        Vector3 force = transform.forward * forwardSpeed * veri;
        rb.AddForce(force);
    }
}
