using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level1Manager : MonoBehaviour {
    public GameObject[] m_objs;
    public GameObject[] m_disableObjs;
    public Text m_txt;
    bool m_start = false;
    //controll continue
    int state = 0;
    //state 1 
    public GameObject dialogue;
    //skip button
    public GameObject skipButton;

	// Use this for initialization
	void Start () {
        m_start = false;
        //foreach (var i in m_objs)
        //    i.SetActive(false);
        activeArray(m_objs, false);
        //fade text
        //TextFadeController tmp = GetComponent<TextFadeController>();
        //StartCoroutine(tmp.FadeTextToZeroAlpha(5f, m_txt));
        StartCoroutine(FadeTextToZeroAlpha(5f, m_txt));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            m_start = true;
        if(m_start)
        {
            //foreach (var i in m_objs)
            //    i.SetActive(true);
            //foreach(var i in m_disableObjs)
            //    i.SetActive(false);
            activeArray(m_objs, true);
            activeArray(m_disableObjs, false);
            //m_txt.SetActive(false);
        }
        if (1 == state)
            dialogue.SetActive(true);
        else
            dialogue.SetActive(false);
        if(2 == state)
        {
            activeArray(m_objs, true);
            activeArray(m_disableObjs, false);
        }
	}
    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        state++;
    }
    public void overDialogue()
    {
        state++;
    }
    public void forSkipButton()
    {
        state = 2;
        Destroy(skipButton);
    }
    void activeArray(GameObject[] objs,bool isActive)
    {
        foreach (var i in objs)
            i.SetActive(isActive);
    }
}
