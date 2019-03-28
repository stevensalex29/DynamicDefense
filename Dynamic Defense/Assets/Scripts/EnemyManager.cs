using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    private List<GameObject> enemyList;
    private GameObject[] enemySpawns;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        
        enemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");

        for (int i = 0;i<10;i++)
        {

            GameObject g = Instantiate(enemy1, enemySpawns[UnityEngine.Random.Range(0,enemySpawns.Length)].transform.position,Quaternion.identity);
            g.GetComponent<Enemy>().setSpeed(2.0f);
            enemyList.Add(g);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if(enemyList[i] ==null)
            {
                enemyList.Remove(enemyList[i]);
            }
            
        }
        if (enemyList.Count < 11)
        {
            GameObject g = Instantiate(enemy1, enemySpawns[UnityEngine.Random.Range(0, enemySpawns.Length)].transform.position, Quaternion.identity);
            g.GetComponent<Enemy>().setSpeed(2.0f);
            enemyList.Add(g);
        }
        
    }
    
    Vector3 randPos()
    {
        return new Vector3(UnityEngine.Random.Range(-35.0f, 35.0f), .5f, UnityEngine.Random.Range(-35.0f, 35.0f));
    }
}
