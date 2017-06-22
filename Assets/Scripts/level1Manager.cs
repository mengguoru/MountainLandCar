using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level1Manager : MonoBehaviour {
    public GameObject[] m_objs;
    public GameObject[] m_disableObjs;
    public Text m_txt;
    bool m_start = false;
	// Use this for initialization
	void Start () {
        m_start = false;
        foreach (var i in m_objs)
            i.SetActive(false);
        //fade text
        TextFadeController tmp = GetComponent<TextFadeController>();
        StartCoroutine(tmp.FadeTextToZeroAlpha(5f, m_txt));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            m_start = true;
        if(m_start)
        {
            foreach (var i in m_objs)
                i.SetActive(true);
            foreach(var i in m_disableObjs)
                i.SetActive(false);
            //m_txt.SetActive(false);
        }
	}
}
