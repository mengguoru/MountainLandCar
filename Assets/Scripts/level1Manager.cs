using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1Manager : MonoBehaviour {
    public GameObject[] m_objs;
    bool m_start = false;
	// Use this for initialization
	void Start () {
        m_start = false;
        foreach (var i in m_objs)
            i.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            m_start = true;
        if(m_start)
        {
            foreach (var i in m_objs)
                i.SetActive(true);
        }
	}
}
