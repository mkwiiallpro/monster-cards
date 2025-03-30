using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
public class AirConsoleGameLogic : MonoBehaviour
{

    void Awake() {
        Debug.Log("Hello!");
        AirConsole.instance.onMessage += OnMessage;
    }
    void OnMessage(int from, JToken data) {
        Debug.Log("Button pressed: ",data.ToString());
        AirConsole.instance.Message(from, "Full of pixels!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
