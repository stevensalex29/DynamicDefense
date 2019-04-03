using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform startPos;
    public AudioClip bulletSound;
    private AudioSource source;

    float timer = 0;
    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= 0.25f)
        {
            canShoot = true;
            timer = 0;
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            GameObject newBullet = Instantiate(bullet, startPos.position, Camera.main.transform.rotation);
            source.PlayOneShot(bulletSound, 0.05f);
            newBullet.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 3500.0f);
            canShoot = false;
        }
    }
}
