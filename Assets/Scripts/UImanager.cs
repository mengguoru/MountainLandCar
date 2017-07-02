using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour {
    bool mWarning = false;
	// Use this for initialization
	void Start () {
        mWarning = false;
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
    public void level1()
    {
        SceneManager.LoadScene("level1");
    }
    public void m_exit()
    {
        Application.Quit() ;
    }
    public void myWarning()
    {
        mWarning = !mWarning;
    }
    public void toSceneOnline()
    {
        //SceneManager.LoadScene("level_online");
        SceneManager.LoadScene("level_online_mobile");
    }

    private void OnGUI()
    {
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        centeredStyle.fontSize = 30;
        centeredStyle.normal.textColor = Color.magenta;
        Vector2 box = new Vector2(300, 640);
        if (mWarning)
            GUI.Label(new Rect(Screen.width / 2 - (box.x/2), Screen.height / 2, box.x,box.y), "功能还在开发中\n敬请期待", centeredStyle);
    }
}
