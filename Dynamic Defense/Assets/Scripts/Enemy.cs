using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = Time.deltaTime * speed;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3 (0.0f,.5f,0.0f), step);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            gameObject.SetActive(false);
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
