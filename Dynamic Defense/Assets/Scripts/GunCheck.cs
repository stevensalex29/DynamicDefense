using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCheck : MonoBehaviour
{
    public static GunCheck gunCheck;

    public string currentPrimary = "DiskGun";
    public string currentSecondary = "Pistol";

    void Awake()
    {
        if (gunCheck == null)
        {
            gunCheck = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
