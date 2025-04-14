using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{
    public Text monsterInfoText;
    public RawImage monsterImage;

    private Monster monster;

    void Start()
    {
        Texture2D sampleTexture = new Texture2D(128, 128);
        sampleTexture.SetPixel(0, 0, Color.red);
        sampleTexture.Apply();

        monster = new Monster("Fire Beast", "Player1", 100, 20, "Fire", sampleTexture);

        UpdateMonsterDisplay();
    }

    void UpdateMonsterDisplay()
    {
        monsterInfoText.text = $"{monster.Name} ({monster.Type})\n" +
                               $"HP: {monster.Health}\n" +
                               $"DMG: {monster.Damage + monster.Boost}\n" +
                               $"Boost: {monster.Boost}";

        monsterImage.texture = monster.Drawing;
    }
}