using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressStart()
    {
        SceneManager.LoadScene("CombatGame");
    }

    public void PressClear()
    {
        Debug.Log("Hello World");
       // Draw.ResetColor();
    }
}
