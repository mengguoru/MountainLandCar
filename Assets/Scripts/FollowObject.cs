using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 tmp = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = tmp;
	}
}
