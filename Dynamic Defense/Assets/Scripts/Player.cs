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
    public AudioClip hurtSound;
    public GameObject deathPanel;
    CameraShake shake;
    private AudioSource source;
    GameObject[] weaponList;
    public int currentWeapon = 0;
    GameObject jokeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f;
        shake = gameObject.GetComponent<CameraShake>();
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        weaponList = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weaponList)
        {
            weapon.SetActive(false);
        }
        weaponList[currentWeapon].SetActive(true);
        jokeWeapon = GameObject.FindGameObjectWithTag("JokeWeapon");
        jokeWeapon.SetActive(false);

        Debug.Log(weaponList[0]);
        Debug.Log(weaponList[1]);
        Debug.Log(weaponList[2]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon();
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            weaponList[currentWeapon].SetActive(false);
            jokeWeapon.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // decrement health, kill enemy, show particles
            health -= 0.1f;
            shake.Shake();
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            Destroy(collision.gameObject);
            if(health>=0.0f)source.PlayOneShot(hurtSound, 0.3f);
            if (health <= 0.0f && !deathPanel.activeSelf) // if health is zero, game over
            {
                GameObject.Find("Health").GetComponent<Text>().text = "HP 0%";
                deathPanel.SetActive(true);
                Invoke("changeScene", 2.0f);
            }
            else // otherwise display new health
            {
                if(!deathPanel.activeSelf)GameObject.Find("Health").GetComponent<Text>().text = "HP " + Mathf.CeilToInt(health * 100) + "%";
            }
        }
    }

    // Switch to gameover scene
    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public void SwitchWeapon()
    {
        jokeWeapon.SetActive(false);
        weaponList[currentWeapon].SetActive(false);
        currentWeapon++;
        if (currentWeapon >= weaponList.Length)
        {
            currentWeapon = 0;
        }
        weaponList[currentWeapon].SetActive(true);
    }
}
