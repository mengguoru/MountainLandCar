using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
    public void level1()
    {
        SceneManager.LoadScene("level1");
    }
    public void exit()
    {
        SceneManager.LoadScene("level1");
    }
}
