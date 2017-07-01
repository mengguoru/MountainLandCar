using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System.Text.RegularExpressions;
using UnityEngine.UI;
//using car namespace
using UnityStandardAssets.Vehicles.Car;

public class NetworkManager : MonoBehaviour {
    public SocketIOComponent socketIO;
   
    public GameObject carPreb;
    public GameObject localPlayer;
    public GameObject otherPlayer;
    //spawn position
    public Transform[] spawnPos;
    //show current information
    public Text localInfo;
    public Text waitingInfo;
    //use for sync data
    public Vector3 oldPos;
    #region legacy
    ////use for when no prefab
    //public GameObject Player1;
    //public Vector3 p1Position;

    #endregion
    // Use this for initialization
    void Start () {
        //Debug.Log("start");
        localPlayer = otherPlayer = null;
        socketIO.On("USER_CONNECTED", OnUserConnected);
        socketIO.On("OTHER_USER_CONNECTED", OtherUserConnected);
        socketIO.On("SERVER_BUSY", serverBusy);
        socketIO.On("OTHER_USER_MOVED", otherUserMoved);

        StartCoroutine("CallToServer");

        //p1Position = Player1.transform.position;

        //use for sync
        oldPos = Vector3.zero;
        //for waiting
        waitingInfo.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q");
        }
	}
    private void FixedUpdate()
    {
        //if(Player1.transform.position != p1Position)
        //{
        //    p1Position = Player1.transform.position;

        //    //send position change to server
           
        //    socketIO.Emit("MOVE",posToJson(p1Position));
        //}

        //sync data if localPlayer is setted
        if(null != localPlayer)
        {
            //if(oldPos != localPlayer.transform.position)
            //{
            //    socketIO.Emit("MOVE", dataToJson(localPlayer.transform));
            //    oldPos = localPlayer.transform.position;
            //}

            //if bigger than threshold
            if(Vector3.Distance(oldPos,localPlayer.transform.position)>0.3)
            {
                socketIO.Emit("MOVE", dataToJson(localPlayer.transform));
                oldPos = localPlayer.transform.position;
            }
        }
    }

    public IEnumerator CallToServer()
    {
        yield return new WaitForSeconds(1f);

        //Debug.Log("send message to server");
        //send local player start position
        //socketIO.Emit("USER_CONNECT",posToJson(p1Position));
        socketIO.Emit("USER_CONNECT"); 
    }

    void OnUserConnected(SocketIOEvent obj)
    {
        //Debug.Log(obj.ToString());
        //Player1.gameObject.name = JsonToString(obj.data.GetField("name").ToString(), "\"");

        //dirty spawn
        //if("Player1" == JsonToString(obj.data.GetField("name").ToString(), "\""))
        //{
        //    localPlayer = GameObject.Instantiate(carPreb.gameObject, spawnPos[0].position, spawnPos[0].rotation);
        //    localPlayer.gameObject.name = "Player1";
        //}
        int currentNum = 0;
        obj.data.GetField(ref currentNum, "num");
        localPlayer = GameObject.Instantiate(carPreb.gameObject, spawnPos[currentNum].position, spawnPos[currentNum].rotation);
        string tmp = "";

        obj.data.GetField(ref tmp, "name");
        localPlayer.gameObject.name = tmp;
        localInfo.text += tmp;
        //waiting for other player
        if(null == otherPlayer)
        {
            waitingInfo.text = "Waiting for another player";
            ableCarControl(localPlayer, false);
        }
    }
    void OtherUserConnected(SocketIOEvent obj)
    {
        int currentNum = 0;
        obj.data.GetField(ref currentNum, "num");
        Debug.Log("other user connected:" + currentNum);
        otherPlayer = GameObject.Instantiate(carPreb.gameObject, spawnPos[currentNum].position, spawnPos[currentNum].rotation);

        //disable useless component
        Destroy(otherPlayer.gameObject.GetComponent<Rigidbody>());
        Destroy(otherPlayer.gameObject.GetComponent<CarUserControl>());
        Destroy(otherPlayer.gameObject.GetComponent<CarAudio>());
        Destroy(otherPlayer.gameObject.GetComponent<CarController>());
        //disable child object except for car model
        for (int i=0;i<otherPlayer.transform.childCount;i++)
        {
            if("CC_ME_R4" != otherPlayer.transform.GetChild(i).name)
            {
                Destroy(otherPlayer.transform.GetChild(i).gameObject);
            }
        }
        string tmp = null;

        obj.data.GetField(ref tmp, "name");
        otherPlayer.gameObject.name = tmp;

        //enable local player controll
        if (null != localPlayer)
        {
            ableCarControl(localPlayer, true);
            Destroy(waitingInfo);
        }
        else
            Debug.Log("check why local player not set");
        //ableCarControl(localPlayer, true);
    }
    void serverBusy(SocketIOEvent obj)
    {
        localInfo.text = "Server busy,you have to wait...";
    }
    void otherUserMoved(SocketIOEvent e)
    {
        if(null != otherPlayer)
        {
            otherPlayer.transform.position = JsonToVecter3(JsonToString(e.data.GetField("pos").ToString(), "\""));
            Vector3 rot = JsonToVecter3(JsonToString(e.data.GetField("rot").ToString(), "\""));
            otherPlayer.transform.rotation = Quaternion.Euler(rot);
        }
    }
    string JsonToString(string target, string s)
    {

        string[] newString = Regex.Split(target, s);

        return newString[1];

    }

    JSONObject posToJson(Vector3 pos)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        Vector3 vec3 = pos;

        Vector3 position = new Vector3(vec3.x, vec3.y, vec3.z);
        data["pos"] = position.x + "," + position.y + "," + position.z;
        return new JSONObject(data);
    }
    JSONObject dataToJson(Transform trans)
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        Vector3 pos = trans.position;
        Vector3 rot = trans.rotation.eulerAngles;
        data["pos"] = pos.x+","+pos.y+","+pos.z;
        data["rot"] = rot.x + "," + rot.y + "," + rot.z;
        return new JSONObject(data);
    }
    private void OnApplicationQuit()
    {
        //Dictionary<string, string> data = new Dictionary<string, string>();
        //data["name"] = localPlayer.gameObject.name;
        //socketIO.Emit("DISCONNECT", new JSONObject(data));
        socketIO.Emit("DISCONNECT");
    }
    //utility
    Vector3 JsonToVecter3(string target)
    {

        Vector3 newVector;
        string[] newString = Regex.Split(target, ",");
        newVector = new Vector3(float.Parse(newString[0]), float.Parse(newString[1]), float.Parse(newString[2]));

        return newVector;

    }
    //control car control component
    void ableCarControl(GameObject car,bool flg)
    {
        car.GetComponent<CarUserControl>().enabled = flg;
        car.GetComponent<CarController>().enabled = flg;
    }
}
