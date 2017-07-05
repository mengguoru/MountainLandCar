using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timmer : MonoBehaviour {

    public GameObject textField;
    public int timeLeft = 90;
	// Use this for initialization
	void Start () {
        StartCoroutine(Count());
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}

    IEnumerator Count()
    {
        while (timeLeft >= 0)
        {
            textField.GetComponent<Text>().text = timeLeft.ToString();
        
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        GameOver();
    }
    void GameOver()
    {
        Debug.Log("level1 game over");
    }
}
