using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(my_CarController2))]
public class my_Camera : MonoBehaviour {
    public Camera ca;
    //Vector3 offset;
    //for in the air
    my_CarController2 carController;
    public Quaternion caRot;
    //void Awake()
    //{
    //    ca = transform.Find("Camera");
    //}
    void Start()
    {
        //offset = ca.transform.position - transform.position;
        carController = GetComponent<my_CarController2>();
    }
	// Update is called once per frame
	void FixedUpdate () {
        //ca.transform.position = transform.position + offset;
        if (!carController.isGrounded)
            ca.transform.rotation = caRot;
        else
            caRot = ca.transform.rotation;
    }
}
