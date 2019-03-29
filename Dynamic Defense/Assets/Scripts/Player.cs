using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Attribute
    private float health;
    public GameObject deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // decrement health, kill enemy, show particles
            health -= 0.1f;
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            if (health <= 0.0f) // if health is zero, game over
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            }
            else // otherwise display new health
            {
                GameObject.Find("Health").GetComponent<Text>().text = Mathf.CeilToInt(health * 100) + "%";
            }
        }
    }
}
