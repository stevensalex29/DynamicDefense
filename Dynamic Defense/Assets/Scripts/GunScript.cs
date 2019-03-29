using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform startPos;

    float timer = 0;
    bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
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
            GameObject newBullet = Instantiate(bullet, startPos.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000.0f);
            canShoot = false;
        }
    }
}
