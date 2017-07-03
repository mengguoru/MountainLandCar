using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class my_MobileButtonHandler : MonoBehaviour {
    public string Name;
    public string buttonName;

    void OnEnable()
    {

    }
    private void Start()
    {
        
    }
    public void SetDownState()
    {
        //CrossPlatformInputManager.SetButtonDown(Name);
        
        CrossPlatformInputManager.SetButtonDown(buttonName);
        Debug.Log(Name + " : " + CrossPlatformInputManager.GetAxis(Name));
    }


    public void SetUpState()
    {
        CrossPlatformInputManager.SetButtonUp(Name);
    }


    public void SetAxisPositiveState()
    {
        CrossPlatformInputManager.SetAxisPositive(Name);
        Debug.Log(Name + " : " + CrossPlatformInputManager.GetAxis(Name));
    }


    public void SetAxisNeutralState()
    {
        CrossPlatformInputManager.SetAxisZero(Name);
    }


    public void SetAxisNegativeState()
    {
        CrossPlatformInputManager.SetAxisNegative(Name);
        Debug.Log(Name + " : " + CrossPlatformInputManager.GetAxis(Name));
        //CrossPlatformInputManager.GetButtonDown("a");
    }

    public void Update()
    {

    }
}
