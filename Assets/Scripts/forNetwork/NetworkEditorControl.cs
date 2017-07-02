using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using SocketIO;

[ExecuteInEditMode]
public class NetworkEditorControl : MonoBehaviour {
    public bool testLocal = true;
    public SocketIOComponent socket;
    //StringBuilder builder;
    string origin = "ws://127.0.0.1:4567/socket.io/?EIO=4&transport=websocket";
    // Use this for initialization
 //   void Start () {
 //       //builder = new StringBuilder(origin);
	//}
	
	// Update is called once per frame
	void Update () {
        if (false == testLocal)
            socket.url = new StringBuilder(origin).Replace("127.0.0.1", "182.254.146.223").ToString();
        else
            socket.url = origin;
	}
}
