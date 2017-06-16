using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(my_CarController2))]
public class my_Camera2 : MonoBehaviour {
    public Camera ca;
    Vector3 offset;
    my_CarController2 carController;
    Quaternion rot;
    private void Start()
    {
        carController = GetComponent<my_CarController2>();
        offset = ca.transform.position - transform.position;
    }
    // Update is called once per frame
    void Update () {
        ca.transform.position = transform.position + offset;
        if (carController.isGrounded)
        {
            ca.transform.rotation = rot = transform.rotation;
        }
        else
        {
            ca.transform.rotation = rot;
        }
	}
}
