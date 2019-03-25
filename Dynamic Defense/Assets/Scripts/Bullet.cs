using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 5.0f);
    }

    // Destroy gameobject when it collides
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
