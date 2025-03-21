using UnityEngine;
using UnityEngine.SceneManagement;
public class SoloStartMenu : MonoBehaviour
{
    public void PressStart()
    {
        SceneManager.LoadScene("Game");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
