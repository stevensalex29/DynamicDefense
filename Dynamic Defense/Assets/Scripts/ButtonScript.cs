using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play again
    public void playAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_Default");
    }

    // Main menu
    public void mainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    // Quit Application
    public void Quit()
    {
        Application.Quit();
    }
}
