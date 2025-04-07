using UnityEngine;

public class Monster
{
    public string Name { get; private set; }
    public string PlayerID { get; private set; }
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public int Boost { get; private set; }
    public string Type { get; private set; }
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
}
