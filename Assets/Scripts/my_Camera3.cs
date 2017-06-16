using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(my_CarController2))]
public class my_Camera3 : MonoBehaviour {
    public Camera ca;
    Vector3 offset;
    my_CarController2 carController;
    public Quaternion rot;
    private void Start()
    {
        carController = GetComponent<my_CarController2>();
        offset = (ca.transform.position - transform.position)+(-transform.forward);

        ca.transform.parent = transform;
    }
    // Update is called once per frame
    void Update () {
        if (carController.isGrounded)
        {
            ca.transform.parent = transform;
            rot = ca.transform.rotation; 
        }
        else
        {
            ca.transform.parent = null;
            ca.transform.rotation = rot;
            ca.transform.position = transform.position + transform.forward + offset;
        }
	}
}
