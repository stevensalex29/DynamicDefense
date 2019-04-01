using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShopManager : MonoBehaviour
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
        
    }

    // Purchase Rifle
    public void Rifle()
    {
        if (PlayerPrefs.GetInt("money") >= 50) {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 50);
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
