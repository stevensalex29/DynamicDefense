using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform startPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject newBullet = Instantiate(bullet, startPos.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 4000.0f);
        }
    }
}
