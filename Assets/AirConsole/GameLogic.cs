using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
public class AirConsoleGameLogic : MonoBehaviour
{
    public Text names;
    void Awake() {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
    }
    void OnMessage(int from, JToken data) {
        Debug.Log("Button pressed: "+data.ToString());
        AirConsole.instance.Message(from, "Full of pixels!");
    }
    void OnConnect(int device_id){
        string newNickname = AirConsole.instance.GetNickname(device_id);
        names.text = names.text.Insert(0,newNickname+"\n");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
