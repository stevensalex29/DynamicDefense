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
}
