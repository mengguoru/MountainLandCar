using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.EventSystems;

public class CheckInput : MonoBehaviour {
    //public CarUserControl userControl;
    public Text checkInputTxt;
    bool getInput;

    // Use this for initialization
    void Start () {
        getInput = false;
        if (null == EventSystem.current)
            checkInputTxt.text = "event system not exist";
        else
            getInput = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(getInput)
        {
            checkInputTxt.text = "hori: " + CrossPlatformInputManager.GetAxis("Horizontal") + ":" +
            "v: " + CrossPlatformInputManager.GetAxis("Vertical");
        }
    }
}
