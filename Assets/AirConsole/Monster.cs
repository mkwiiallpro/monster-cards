
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using TMPro;
public class Monster : MonoBehaviour
{
    [SerializeField]
    public string Name;

    public string PlayerID { get; private set; }

    [SerializeField]
    public int Health;

    public int Damage { get; private set; }
    public int Boost { get; private set; }

    [SerializeField]
    public string Type;

    public Texture2D Drawing { get; private set; }

    public Monster(string name, string playerID, int health, int damage, string type, Texture2D drawing)
    {
        Name = name;
        PlayerID = playerID;
        Health = health;
        Damage = damage;
        Type = type;
        Drawing = drawing;
        Boost = 0;
    }

    public void ApplyBoost(int boostAmount)
    {
        Boost += boostAmount;
    }

    public void TakeDamage(int damage)
    {
        Health -= Mathf.Max(0, damage);
    }

    public void UpdateDrawing(Texture2D newDrawing)
    {
        Drawing = newDrawing;
    }

    void Start()
    {
        Name = "";
        Type = "None";
        Health = 10;
    }
}
