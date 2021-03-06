﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    public TextAsset txtFile;
    public string[] txtLines;
    public Text showTxt;
    public int currentTxt = 0;
    //objects will disable
    public GameObject[] objs;
    //controll text scroll
    public bool isTyping;
    public bool cancelTyping;
    public float typeInterval;
    //controll dialogist image visible
    public GameObject dialogist1;
    public GameObject dialogist2;
    //send end dialogue message
    public GameObject msgReceiver;
    // Use this for initialization
    void Start () {
        txtLines = txtFile.text.Split('\n');
        currentTxt = 0;
        isTyping = false;
        cancelTyping = true;
        StartCoroutine(TextScroll(txtLines[currentTxt]));
    }
	
	// Update is called once per frame
	void Update () {
        if((txtLines.Length -1) == currentTxt)
            endDialogue();
        //showTxt.text = txtLines[currentTxt];
	}
    public void next()
    {
        //Debug.Log("next");
        if(!isTyping)
        {
            currentTxt++;
            //so although txtLines don't need,but is needed for function use!!!
            if (txtLines.Length-1 == currentTxt)
                endDialogue();
            else
                StartCoroutine(TextScroll(txtLines[currentTxt]));
        }else if(isTyping&&!cancelTyping)
        {
            cancelTyping = true;
        }
        //StartCoroutine(TextScroll(txtLines[currentTxt]));
    }
    public void endDialogue()
    {
        //foreach (var i in objs)
        //    i.SetActive(false);
        msgReceiver.SendMessage("overDialogue");

    }
    private IEnumerator TextScroll(string str)
    {
        if(null != dialogist1)
            dialogist1.SetActive(currentTxt % 2 == 0);
        if(null != dialogist2)
            dialogist2.SetActive(currentTxt % 2 == 1);

        showTxt.text = "";
        isTyping = true;
        cancelTyping = false;
        for (int i=0;isTyping && !cancelTyping &&(i < str.Length - 1);i++)
        {
            showTxt.text += str[i];
            yield return new WaitForSeconds(typeInterval);
        }
        showTxt.text = str;
        isTyping = false;
        cancelTyping = true;
    }
}
