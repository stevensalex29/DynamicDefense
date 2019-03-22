using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    private List<GameObject> enemyList;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        for(int i = 0;i<10;i++)
        {
            GameObject g = Instantiate(enemy1, randPos(),Quaternion.identity);
            g.GetComponent<Enemy>().setSpeed(2.0f);
            enemyList.Add(g);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    Vector3 randPos()
    {
        return new Vector3(UnityEngine.Random.Range(-35.0f, 35.0f), .5f, UnityEngine.Random.Range(-35.0f, 35.0f));
    }
}
