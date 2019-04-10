using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunShopManager : MonoBehaviour
{
    private int pastWave;
    private int currentWave;

    GameObject currentPri;
    GameObject currentSec;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameObject.Find("WaveBeatText").GetComponent<Text>().text = "You Beat Wave " + PlayerPrefs.GetInt("wave") + ", your score is " + PlayerPrefs.GetInt("score");
        pastWave = PlayerPrefs.GetInt("wave");
        currentWave = pastWave;

        currentPri = GameObject.Find("CurrentPrimary");
        currentSec = GameObject.Find("CurrentSecondary");

        foreach (string gun in GunCheck.gunCheck.gunBought)
        {
            if (gun == "Rifle")
                GameObject.Find("Rifle").GetComponentInChildren<Text>().text = "Rifle";
            else if (gun == "Shotgun")
                GameObject.Find("Shotgun").GetComponentInChildren<Text>().text = "Shotgun";
            else if (gun == "Laser")
                GameObject.Find("Laser").GetComponentInChildren<Text>().text = "Laser";
            else if (gun == "Revolver")
                GameObject.Find("Revolver").GetComponentInChildren<Text>().text = "Revolver";

            if (GunCheck.gunCheck.currentPrimary == gun)
                currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find(gun).GetComponent<RectTransform>().localPosition;
            if (GunCheck.gunCheck.currentSecondary == gun)
                currentSec.GetComponent<RectTransform>().localPosition = GameObject.Find(gun).GetComponent<RectTransform>().localPosition;
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Cash").GetComponent<Text>().text = "Cash: $" + PlayerPrefs.GetInt("money");
        if (pastWave == currentWave)
        {
            currentWave = pastWave + 1;
            PlayerPrefs.SetInt("wave", currentWave);
        }
    }

    public void DiskGun()
    {
        GunCheck.gunCheck.currentPrimary = "DiskGun";
        currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("DiskGun").GetComponent<RectTransform>().localPosition;
    }

    public void Pistol()
    {
        GunCheck.gunCheck.currentSecondary = "Pistol";
        currentSec.GetComponent<RectTransform>().localPosition = GameObject.Find("Pistol").GetComponent<RectTransform>().localPosition;
    }

    // Purchase Rifle
    public void Rifle()
    {
        if (PlayerPrefs.GetInt("money") >= 50 && !GunCheck.gunCheck.gunBought.Contains("Rifle")) {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 50);
            GunCheck.gunCheck.currentPrimary = "Rifle";
            GunCheck.gunCheck.gunBought.Add("Rifle");
            currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("Rifle").GetComponent<RectTransform>().localPosition;
            GameObject.Find("Rifle").GetComponentInChildren<Text>().text = "Rifle";
        }
        else if (GunCheck.gunCheck.gunBought.Contains("Rifle"))
        {
            GunCheck.gunCheck.currentPrimary = "Rifle";
            currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("Rifle").GetComponent<RectTransform>().localPosition;
        }
    }

    // Purchase Shotgun
    public void Shotgun()
    {
        if (PlayerPrefs.GetInt("money") >= 100 && !GunCheck.gunCheck.gunBought.Contains("Shotgun"))
        {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 100);
            GunCheck.gunCheck.currentPrimary = "Shotgun";
            GunCheck.gunCheck.gunBought.Add("Shotgun");
            currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("Shotgun").GetComponent<RectTransform>().localPosition;
            GameObject.Find("Shotgun").GetComponentInChildren<Text>().text = "Shotgun";
        }
        else if (GunCheck.gunCheck.gunBought.Contains("Shotgun"))
        {
            GunCheck.gunCheck.currentPrimary = "Shotgun";
            currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("Shotgun").GetComponent<RectTransform>().localPosition;
        }
    }

    // Purchase Laser
    public void Laser()
    {
        if (PlayerPrefs.GetInt("money") >= 200 && !GunCheck.gunCheck.gunBought.Contains("Laser"))
        {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 200);
            GunCheck.gunCheck.currentPrimary = "Laser";
            GunCheck.gunCheck.gunBought.Add("Laser");
            currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("Laser").GetComponent<RectTransform>().localPosition;
            GameObject.Find("Laser").GetComponentInChildren<Text>().text = "Laser";
        }
        else if (GunCheck.gunCheck.gunBought.Contains("Laser"))
        {
            GunCheck.gunCheck.currentPrimary = "Laser";
            currentPri.GetComponent<RectTransform>().localPosition = GameObject.Find("Laser").GetComponent<RectTransform>().localPosition;
        }
    }

    // Purchase Revolver
    public void Revolver()
    {
        if (PlayerPrefs.GetInt("money") >= 25 && !GunCheck.gunCheck.gunBought.Contains("Revolver"))
        {
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - 25);
            GunCheck.gunCheck.currentSecondary = "Revolver";
            GunCheck.gunCheck.gunBought.Add("Revolver");
            currentSec.GetComponent<RectTransform>().localPosition = GameObject.Find("Revolver").GetComponent<RectTransform>().localPosition;
            GameObject.Find("Revolver").GetComponentInChildren<Text>().text = "Revolver";
        }
        else if (GunCheck.gunCheck.gunBought.Contains("Revolver"))
        {
            GunCheck.gunCheck.currentSecondary = "Revolver";
            currentSec.GetComponent<RectTransform>().localPosition = GameObject.Find("Revolver").GetComponent<RectTransform>().localPosition;
        }
    }
}
