using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform startPos;
    public AudioClip bulletSound;
    private AudioSource source;

    float timer = 0;
    float fireRate = 0.5f;
    bool canShoot = true;

    bool rapid;
    int ammo;
    int ammoMax;
    float reloadTime = 0;
    float reloadSpeed;

    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        if (gameObject.name == "DiskGun")
        {
            rapid = true;
            fireRate = 0.3f;
            ammoMax = 15;
            reloadSpeed = 1.0f;
        }
        else if (gameObject.name == "Rifle")
        {
            rapid = true;
            fireRate = 0.15f;
            ammoMax = 30;
            reloadSpeed = 2.0f;
        }
        else if (gameObject.name == "Pistol")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 20;
            reloadSpeed = 1.0f;
        }
        else if (gameObject.name == "Revolver")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 8;
            reloadSpeed = 0.5f;
        }
        else if (gameObject.name == "Shotgun")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 10;
            reloadSpeed = 0.75f;
        }
        ammo = ammoMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ammo == 0)
        {
            GameObject.Find("Reload").GetComponent<Text>().text = "Realoading " + ((reloadTime/reloadSpeed) * 100.0f).ToString("F0") + "%";
            reloadTime += Time.deltaTime;
            if (reloadTime >= reloadSpeed)
            {
                ammo = ammoMax;
                reloadTime = 0;
                GameObject.Find("Reload").GetComponent<Text>().text = "";
            }
        }
        GameObject.Find("Ammo").GetComponent<Text>().text = "Ammo: " + ammo + "/" + ammoMax;

        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            canShoot = true;
            timer = 0;
        }

        if (rapid)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else if (!rapid)
        {
            canShoot = true;
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (canShoot && ammo != 0)
        {
            if(gameObject.name =="Shotgun")
            {
                List<GameObject> bullets = new List<GameObject>();
                for (int i = 0; i <= 4; i++)
                {
                    GameObject bullet1 = Instantiate(bullet, startPos.position, Camera.main.transform.rotation * bullet.transform.rotation);
                    bullets.Add(bullet1);

                }


                //bullets.Add(bullet1);
                //bullets.Add(bullet1);
                //bullets.Add(bullet1);
                //bullets.Add(bullet1);
                int counter = -10;
                source.PlayOneShot(bulletSound, 0.05f);
                for (int i =0;i<bullets.Count;i++)
                {
                    
                    Vector3 shotPos = Quaternion.Euler(0,counter , 0) * Camera.main.transform.forward;
                    bullets[i].GetComponent<Rigidbody>().AddForce(shotPos * 3500.0f);
                    counter += 5;
                }
                //GameObject bullet2 = Instantiate(bullet, startPos.position, Camera.main.transform.rotation * bullet.transform.rotation);
                //GameObject bullet3 = Instantiate(bullet, startPos.position, Camera.main.transform.rotation * bullet.transform.rotation);
                //GameObject bullet4 = Instantiate(bullet, startPos.position, Camera.main.transform.rotation * bullet.transform.rotation);
                //Vector3 shot1Pos = Quaternion.Euler(0, 10, 0) * Camera.main.transform.forward;
                //Vector3 shot2Pos = Quaternion.Euler(0, 15, 0) * Camera.main.transform.forward;
                //Vector3 shot3Pos = Quaternion.Euler(0, -15, 0) * Camera.main.transform.forward;
                //Vector3 shot4Pos = Quaternion.Euler(0, -10, 0) * Camera.main.transform.forward;
                //bullet1.GetComponent<Rigidbody>().AddForce(shot1Pos * 3500.0f);
                //bullet2.GetComponent<Rigidbody>().AddForce(shot2Pos * 3500.0f);
                //bullet3.GetComponent<Rigidbody>().AddForce(shot3Pos * 3500.0f);
                //bullet4.GetComponent<Rigidbody>().AddForce(shot4Pos * 3500.0f);
                ammo--;
                canShoot = false;
            }
            else
            {
                GameObject newBullet = Instantiate(bullet, startPos.position, Camera.main.transform.rotation * bullet.transform.rotation);
                source.PlayOneShot(bulletSound, 0.05f);
                newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 3500.0f);
                ammo--;
                canShoot = false;
            }
            
        }
    }
}
