using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class Player : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
    private void OnTriggerEnter(Collider other)
    {
        //for scene2 
        if ("endpoint" == other.name)
            SceneManager.LoadScene("level3");
        if("oil" == other.tag)
        {
            //Debug.Log("oil");
            Destroy(other.transform.root.gameObject);
            getOil();
        }
    }
    public void getOil()
    {
        if(GetComponent<CarController>() != null)
        {
            if (GetComponent<Rigidbody>() != null)
            {
                //GetComponent<Rigidbody>().velocity = GetComponent<CarController>().MaxSpeed;
                GetComponent<Rigidbody>().velocity *= 5;
            }
        }
    }
}
