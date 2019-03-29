using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathParticle;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * speed;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3 (0.0f,1f,0.0f), step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Bullet")
        {
            GameObject particle = Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation) as GameObject;
            Destroy(gameObject);
        }
            
    }
    public void setSpeed(float _speed)
    {
        speed = _speed;
    }
    public float getSpeed()
    {
        return speed;
    }

}
