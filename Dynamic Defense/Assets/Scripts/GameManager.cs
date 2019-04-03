using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Score").GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score");
        GameObject.Find("Wave").GetComponent<Text>().text = "Wave: " + PlayerPrefs.GetInt("wave");
        if (Input.GetKeyDown("m"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
