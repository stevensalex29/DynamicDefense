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
    private GameObject crosshair;

    float timer = 0;
    float fireRate = 0.5f;
    bool canShoot = true;

    bool rapid;
    int ammo;
    int ammoMax;
    public bool reloading = false;
    float reloadTime = 0;
    float reloadSpeed;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair");
        GameObject.Find("Reload").GetComponent<Image>().fillAmount = 0;
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        if (gameObject.name == "DiskGun")
        {
            rapid = true;
            fireRate = 0.3f;
            ammoMax = 15;
            reloadSpeed = 3.0f;
            damage = 1;
        }
        else if (gameObject.name == "Rifle")
        {
            rapid = true;
            fireRate = 0.15f;
            ammoMax = 30;
            reloadSpeed = 2.0f;
            damage = 1;
        }
        else if (gameObject.name == "Pistol")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 20;
            reloadSpeed = 1.5f;
            damage = 1;
        }
        else if (gameObject.name == "Revolver")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 8;
            reloadSpeed = 0.75f;
            damage = 1;
        }
        else if (gameObject.name == "Shotgun")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 10;
            reloadSpeed = 1.0f;
            damage = 1;
        }
        else if (gameObject.name == "JokeGun")
        {
            rapid = false;
            fireRate = 0;
            ammoMax = 10;
            reloadSpeed = 0.1f;
            damage = 1;
        }
        ammo = ammoMax;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Manual reload
        if (Input.GetKeyDown(KeyCode.R) && ammo != ammoMax)
        {
            ammo = 0;
            reloading = true;
        }

        //Reload
        if (reloading)
        {
            crosshair.SetActive(false);
            GameObject.Find("Reload").GetComponent<Image>().fillAmount = reloadTime/reloadSpeed;
            reloadTime += Time.deltaTime;
            if (reloadTime >= reloadSpeed)
            {
                ammo = ammoMax;
                reloadTime = 0;
                reloading = false;
                GameObject.Find("Reload").GetComponent<Image>().fillAmount = 0;
                crosshair.SetActive(true);
            }
        }

        //Update reload text
        GameObject.Find("Ammo").GetComponent<Text>().text = "Ammo: " + ammo + "/" + ammoMax;
        if(ammo == 1) GameObject.Find("AmmoBar").GetComponent<Image>().fillAmount = .1f;
        else GameObject.Find("AmmoBar").GetComponent<Image>().fillAmount = (float)ammo / ammoMax;

        //Shoot delay
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            canShoot = true;
            timer = 0;
        }

        //Check rapid fire
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
                if (ammo == 0)
                    reloading = true;
            }
            else
            {
                GameObject newBullet = Instantiate(bullet, startPos.position, Camera.main.transform.rotation * bullet.transform.rotation);
                source.PlayOneShot(bulletSound, 0.05f);
                newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 3500.0f);
                ammo--;
                canShoot = false;
                if (ammo == 0)
                    reloading = true;
            }
            
        }
    }
}
