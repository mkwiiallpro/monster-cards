using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using TMPro;
public class AirConsoleGameLogic : MonoBehaviour
{
    // All Serialized Game Objects
    [SerializeField]
    GameObject groupStartMenu;
    [SerializeField]
    GameObject drawMenu;
    [SerializeField]
    GameObject voteMenu;
    [SerializeField]
    GameObject gameOverMenu;

    [SerializeField]
    Material leftMonster;
    [SerializeField]
    Material rightMonster;

    [SerializeField]
    TextMeshProUGUI leftVotes;
    [SerializeField]
    TextMeshProUGUI rightVotes;
    [SerializeField]
    TextMeshProUGUI roundNumber;
    [SerializeField]
    TextMeshProUGUI winnerText;
    [SerializeField]
    TextMeshProUGUI nameText;

    // Everything Else Relevant to the Game
    public int round;
    bool enoughPlayers;
    public Text names;

    [SerializeField]
    List<int> deviceIDs;

    [SerializeField]
    List<int> votes;

    [SerializeField]
    List<Texture2D> currentMonsters;
    [SerializeField]
    List<string> monsterNames;
    [SerializeField]
    List<string> monsterTypes;

    [SerializeField]
    List<int> score;

    public int gameMode;

    void Awake() {
        // Beta Release only supports two player games
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onConnect += OnConnect;
    }
    // Start is called before the first frame update
    void Start()
    {
        enoughPlayers = false;
        gameMode = 0;
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        votes.Add(0);
        score.Add(0);
        currentMonsters.Add(null);
        monsterNames.Add("");
        monsterTypes.Add("None");
        
        
    }

    // Receive Signals from AirConsole
    void OnMessage(int from, JToken data) 
    {
        Debug.Log("Button pressed");

        // Handle Drawing Signals
        if(data["colorMap"] != null && gameMode == 1){
            // Turns sent data into a Texture2D
            string drawData = data["colorMap"].ToString();
            Color[] temp = new Color[262144];
            for(int i =0; i<262144;i++){
                if(drawData[i] == 'A'){
                    temp[i] = Color.black;
                }
                else{
                    temp[i] = Color.white;
                }
            }
            Texture2D generatedTexture = new Texture2D(512,512,TextureFormat.RGBA32, false);
            generatedTexture.SetPixels(temp);
            generatedTexture.Apply();
            currentMonsters[from] = generatedTexture;
            
            // Adds the user to the "Done" list
            nameText.text += AirConsole.instance.GetNickname(from);
            nameText.text += "\n";

            // Send confirmation
            AirConsole.instance.Message(from, "Monster Received");
        }

        // Handle Vote Signals
        if(data["text"] != null && gameMode == 2){
            if(data["text"].ToString() == "vote-left"){
                votes[from] = 1;
                AirConsole.instance.Message(from, "Vote Received");
            }
            else if(data["text"].ToString() == "vote-right"){
                votes[from] = 2;
                AirConsole.instance.Message(from, "Vote Received");
            }
        }

        // Handle Monster Data
        if(data["monsterName"] != null && gameMode == 1)
        {
            Debug.Log("We did a thing:" + data["monsterName"].ToString());
            monsterNames[from] = data["monsterName"].ToString();
        }
        if(data["monsterType"] != null && gameMode == 1)
        {
            monsterTypes[from] = data["monsterType"].ToString();
            
        }
        
    }


    void OnConnect(int device_id)
    {
        string newNickname = AirConsole.instance.GetNickname(device_id);
        names.text = names.text.Insert(0,newNickname+"\n");
        deviceIDs.Add(device_id);
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

    // Press "Start" on "GroupStartMenu"
    public void PressStartGroup()
    {
        // Check if there are enough players
        if(enoughPlayers)
        {
            groupStartMenu.SetActive(false);
            drawMenu.SetActive(true);
            leftVotes.text = "";
            rightVotes.text = "";
            round = 1;
            gameMode = 1;
            nameText.text = "Done:\n";
        }
        else
        {
            // Tell the user that not enough players have joined
        }
    }

    // Press "Results" on "VoteMenu"
    public void PressResults()
    {
        int numVotes = 0;
        int numLeft = 0;
        int numRight = 0;
        foreach(int i in votes)
        {
            if(i != 0){
                numVotes++;
            }
            if(i == 1){
                numLeft++;
            }
            if(i == 2){
                numRight++;
            }
        }

        
        // Check if anyone has voted
        if(numVotes >= 0)
        {
            leftVotes.text = "Votes: "+numLeft;
            rightVotes.text = "Votes: "+numRight;
            if(numLeft >= numRight)
            {
                score[deviceIDs[0]]++;
            }
            if(numLeft <= numRight)
            {
                score[deviceIDs[1]]++;
            }
        }
        else
        {

        }
    }
    // Press "Next" on "DrawMenu"
    public void PressNextDraw()
    {
        
        gameMode = 2;
        voteMenu.SetActive(true);
        drawMenu.SetActive(false);
        for(int i = 0; i<10; i++){
            votes[i] =0;
        }
        leftVotes.text = "Name: "+monsterNames[deviceIDs[0]]+"\n";
        leftVotes.text += "Type: "+monsterTypes[deviceIDs[0]]+"\n";
        leftMonster.SetTexture("_BaseMap",currentMonsters[deviceIDs[0]]);

        rightVotes.text = "Name: "+monsterNames[deviceIDs[1]]+"\n";
        rightVotes.text += "Type: "+monsterTypes[deviceIDs[1]]+"\n";
        rightMonster.SetTexture("_BaseMap",currentMonsters[deviceIDs[1]]);
    }

    // Press "Next" on "VoteMenu"
    public void PressNext()
    {
        if(round < 3)
        {
            round++;
            gameMode = 1;
            voteMenu.SetActive(false);
            drawMenu.SetActive(true);
            leftVotes.text = "";
            rightVotes.text = "";
            nameText.text = "Done:\n";
        }
        else
        {
            gameMode = 3;
            gameOverMenu.SetActive(true);
            voteMenu.SetActive(false);
            leftVotes.text = "";
            rightVotes.text = "";
            int highscore = 0;
            string win = "";
            foreach(int i in deviceIDs)
            {
                Debug.Log(score[i]);
                Debug.Log(AirConsole.instance.GetNickname(i));
                if(highscore == score[i])
                {
                    win += AirConsole.instance.GetNickname(i);
                }
                else if(highscore < score[i])
                {
                    highscore = score[i];
                    win = AirConsole.instance.GetNickname(i);
                }
            }
            winnerText.text = "Winner: "+win;
            // The game ends after three rounds
        }
        
    }

    // Press "Same Players" on "GameOverMenu"
    public void PressSamePlayers()
    {
        gameOverMenu.SetActive(false);
        drawMenu.SetActive(true);
        leftVotes.text = "";
        rightVotes.text = "";
        nameText.text = "Done:\n";
        round = 1;
        gameMode = 1;
        for(int i = 0; i<votes.Count; i++){
            votes[i] = 0;
            score[i] = 0;
            currentMonsters[i] = null;
        }
    }
    // Press "Quit" on "GameOverMenu"
    void OnDestroy()
    {
        //unregister events
        if(AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
            AirConsole.instance.onConnect -= OnConnect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == 0)
        {
            roundNumber.text = "";
        }
        else
        {
            roundNumber.text = "Round: "+round;
        }
    }
}
