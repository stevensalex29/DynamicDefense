﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathParticle;
    public AudioClip deathSound;
    private AudioSource source;
    private float speed;
    private int health;
    private int waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        waveNumber = PlayerPrefs.GetInt("wave");

        if (waveNumber >= 0 && waveNumber < 4){
            health = 1;
        }
        if (waveNumber >= 4 && waveNumber < 8) {
            health = 2;
        }
        if (waveNumber >= 8)
        {
            health = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xvalue = 0.0f;
        float zvalue = 0.0f;
        float step = Time.deltaTime * speed;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(xvalue, 1f, zvalue), step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            source.PlayOneShot(deathSound,0.05f);
            // Update score
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 10);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money + 1);
            

            health -= collision.gameObject.GetComponent<Bullet>().damage;

            if (health <= 0) {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "PistolBullet")
        {
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            source.PlayOneShot(deathSound, 0.05f);
            // Update score
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 10);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money + 1);

            health -= collision.gameObject.GetComponent<Bullet>().damage;

            if (health <= 0)
            {
                Debug.Log(health);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "LaserBullet")
        {
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            source.PlayOneShot(deathSound, 0.05f);
            // Update score
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 10);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money + 1);

            health -= collision.gameObject.GetComponent<Bullet>().damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "RifleBullet")
        {
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            source.PlayOneShot(deathSound, 0.05f);
            // Update score
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 10);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money + 1);

            health -= collision.gameObject.GetComponent<Bullet>().damage;

            if (health <= 0)
            {
                Debug.Log(health);
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "RevolverBullet")
        {
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            source.PlayOneShot(deathSound, 0.05f);
            // Update score
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 10);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money + 1);

            health -= collision.gameObject.GetComponent<Bullet>().damage;

            if (health <= 0)
            {
                Debug.Log(health);
                Destroy(gameObject);
            }
        }

    }
    public void setSpeed(float _speed)
    {
        speed = _speed;
    }
    public float getSpeed()
    {
        return speed;
    }

}
