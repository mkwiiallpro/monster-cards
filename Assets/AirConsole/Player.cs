using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
public class Player : ScriptableObject 
{
    string name;
    List<Monster> monsters;
}