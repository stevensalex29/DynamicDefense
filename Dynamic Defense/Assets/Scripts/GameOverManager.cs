using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.Find("Score").GetComponent<Text>().text = "Final Score: " + PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("wave", 1);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("score", 0);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
