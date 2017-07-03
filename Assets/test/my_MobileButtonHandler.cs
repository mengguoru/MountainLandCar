using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class my_MobileButtonHandler : MonoBehaviour {
    public string Name;

    void OnEnable()
    {

    }
    private void Start()
    {
        
    }
    public void SetDownState()
    {
        CrossPlatformInputManager.SetButtonDown(Name);
        Debug.Log(Name + " : negative" + CrossPlatformInputManager.GetAxis(Name));
    }


    public void SetUpState()
    {
        CrossPlatformInputManager.SetButtonUp(Name);
    }


    public void SetAxisPositiveState()
    {
        CrossPlatformInputManager.SetAxisPositive(Name);
    }


    public void SetAxisNeutralState()
    {
        CrossPlatformInputManager.SetAxisZero(Name);
    }


    public void SetAxisNegativeState()
    {
        CrossPlatformInputManager.SetAxisNegative(Name);
        //Debug.Log(Name + " : negative" + CrossPlatformInputManager.GetAxis(Name));
        //CrossPlatformInputManager.GetButtonDown("a");
    }

    public void Update()
    {

    }
}
