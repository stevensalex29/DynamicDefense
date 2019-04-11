using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Level_Default");
    }

    // Main menu
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Quit Application
    public void Quit()
    {
        Application.Quit();
    }

    // Help
    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    // go to gun shop
    public void GunStore() {
        SceneManager.LoadScene("GunShop");
    }
}
