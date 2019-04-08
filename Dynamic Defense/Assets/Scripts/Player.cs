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
    List<GameObject> weapons = new List<GameObject>();
    int currentWeapon = 0;
    GameObject jokeWeapon;
    GunCheck gunCheck;

    // Start is called before the first frame update
    void Start()
    {
        health = 1.0f;
        shake = gameObject.GetComponent<CameraShake>();
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        gunCheck = GunCheck.gunCheck;
        weaponList = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weaponList)
        {
            weapon.SetActive(false);
            if (weapon.name == gunCheck.currentPrimary)
            {
                weapons.Add(weapon);
                weapon.SetActive(true);
            }
            else if (weapon.name == gunCheck.currentSecondary)
            {
                weapons.Add(weapon);
            }
        }
        jokeWeapon = GameObject.FindGameObjectWithTag("JokeGun");
        jokeWeapon.SetActive(false);
        GameObject.Find("GunName").GetComponent<Text>().text = weapons[currentWeapon].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Weapon").GetComponent<GunScript>().reloading)
            SwitchWeapon();
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
                GameObject.Find("Health").GetComponent<Image>().fillAmount = health;
                deathPanel.SetActive(true);
                Invoke("changeScene", 2.0f);
            }
            else // otherwise display new health
            {
                if(!deathPanel.activeSelf)GameObject.Find("Health").GetComponent<Image>().fillAmount = health;
            }
        }
    }

    // Switch to gameover scene
    public void changeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            jokeWeapon.SetActive(false);
            weapons[currentWeapon].SetActive(false);
            currentWeapon++;
            if (currentWeapon >= weapons.Count)
            {
                currentWeapon = 0;
            }
            weapons[currentWeapon].SetActive(true);
            GameObject.Find("GunName").GetComponent<Text>().text = weapons[currentWeapon].name;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            weapons[currentWeapon].SetActive(false);
            jokeWeapon.SetActive(true);
            GameObject.Find("GunName").GetComponent<Text>().text = "Joke Gun";
        }
        
    }
}
