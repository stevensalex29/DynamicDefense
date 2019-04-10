using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5.0f);
    }

    // Destroy gameobject when it collides
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
            return;
        
        if (collision.gameObject.tag != "Player" && gameObject.tag != "JokeBullet")
            Destroy(gameObject);

    }
}
