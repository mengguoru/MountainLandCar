using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
    private void OnTriggerEnter(Collider other)
    {
        if ("endpoint" == other.name)
            SceneManager.LoadScene("level2");
    }
}
