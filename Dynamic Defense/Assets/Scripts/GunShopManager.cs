using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShopManager : MonoBehaviour
{
    private int pastWave;
    private int currentWave;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.Find("WaveBeatText").GetComponent<Text>().text = "You Beat Wave " + PlayerPrefs.GetInt("wave") + ", your score is " + PlayerPrefs.GetInt("score");
        GameObject.Find("Cash").GetComponent<Text>().text = "Cash: $" + PlayerPrefs.GetInt("money");
        pastWave = PlayerPrefs.GetInt("wave");
        currentWave = pastWave;
        
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if (pastWave == currentWave)
        {
            currentWave = pastWave + 1;
            PlayerPrefs.SetInt("wave", currentWave);
        }
    }

    // Purchase Rifle
    public void Rifle()
    {
        if (PlayerPrefs.GetInt("money") >= 50) {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 50);
            player.GetComponent<Player>().currentWeapon = 2;
            player.GetComponent<Player>().SwitchWeapon();
        }
    }

    // Purchase Shotgun
    public void Shotgun()
    {
        if (PlayerPrefs.GetInt("money") >= 60)
        {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 60);
        }
    }

    // Purchase Lazer Rifle
    public void LazerRifle()
    {
        if (PlayerPrefs.GetInt("money") >= 200)
        {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 200);
        }
    }

    // Purchase Revolver
    public void Revolver()
    {
        if (PlayerPrefs.GetInt("money") >= 20)
        {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 20);
        }
    }
}
