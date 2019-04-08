using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using System;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    private List<GameObject> enemyList;
    private GameObject[] enemySpawns;
    private int waveNumber;
    private int enemiesLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        waveNumber = PlayerPrefs.GetInt("wave");
        enemySpawns = GameObject.FindGameObjectsWithTag("EnemySpawn");
        enemiesLeft = 10 + ((waveNumber-1)*2);

        for (int i = 0;i<enemiesLeft;i++)
        {
            int enemySpawner = UnityEngine.Random.Range(0, enemySpawns.Length);
            /*
            if(canSpawn(enemySpawner))
            {
                GameObject g = Instantiate(enemy1, enemySpawns[enemySpawner].transform.position, Quaternion.identity);
                g.GetComponent<Enemy>().setSpeed(2.0f);
                enemyList.Add(g);
            }
            */
            GameObject g = Instantiate(enemy1, enemySpawns[enemySpawner].transform.position, Quaternion.identity);
            g.GetComponent<Enemy>().setSpeed(2.0f);
            enemyList.Add(g);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                enemyList.Remove(enemyList[i]);
                enemiesLeft--;
            }

        }
        GameObject.Find("EnemyLeft").GetComponent<Text>().text = "Enemies Left: " + enemiesLeft;

        if (enemiesLeft == 0)
        {
            if(!GameObject.Find("Player").GetComponent<Player>().deathPanel.activeSelf)Invoke("changeScene", 2.0f);
        }
        
    }

    // Switch to gunshop scene
    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GunShop");
    }
    
    Vector3 randPos()
    {
        return new Vector3(UnityEngine.Random.Range(-35.0f, 35.0f), .5f, UnityEngine.Random.Range(-35.0f, 35.0f));
    }
    public bool canSpawn(int i)
    {
        Collider col = enemySpawns[i].GetComponent<Collider>();
        for(int j =0;j<enemyList.Count;j++)
        {
            if (col.bounds.Intersects(enemyList[j].GetComponent<Collider>().bounds))
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        return true;
        
    }

}
