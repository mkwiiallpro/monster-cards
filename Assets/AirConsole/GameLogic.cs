using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
public class AirConsoleGameLogic : MonoBehaviour
{
    // All Serialized Game Objects
    [SerializeField]
    GameObject groupStartMenu;
    [SerializeField]
    GameObject voteMenu;
    [SerializeField]
    GameObject leftMonster;
    [SerializeField]
    GameObject rightMonster;

    // Everything Else Relevant to the Game
    public int round;
    int numPlayers; 
    bool enoughPlayers;
    public Text names;

    [SerializeField]
    List<int> votes;

    void Awake() {
        // Beta Release only supports two player games
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
    }
    // Start is called before the first frame update
    void Start()
    {
        enoughPlayers = false;
        numPlayers = 0;
        votes = new List<int>();
    }
    void OnMessage(int from, JToken data) 
    {
        Debug.Log("Button pressed: "+data.ToString());
        AirConsole.instance.Message(from, "Full of pixels!");
        if((string)data == "vote-left"){
            votes[0]++;
        }
        else if((string)data == "vote-right"){
            votes[1]++;
        }
    }
    void OnConnect(int device_id)
    {
        string newNickname = AirConsole.instance.GetNickname(device_id);
        names.text = names.text.Insert(0,newNickname+"\n");
        // Make sure 2 people are online before starting the game
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
            if (AirConsole.instance.GetControllerDeviceIds().Count >= 2)
            {
                enoughPlayers = true;
                Debug.Log("Enough players have joined!");
            }
        }
    }
    public void PressStartGroup()
    {
        if(enoughPlayers)
        {
            groupStartMenu.SetActive(false);
            voteMenu.SetActive(true);
            leftMonster.SetActive(true);
            rightMonster.SetActive(true);
            round = 0;
            votes.Add(0);
            votes.Add(0);
        }
        else
        {
            // Tell the user that not enough players have joined
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
