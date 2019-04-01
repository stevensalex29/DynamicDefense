using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathParticle;
    public AudioClip deathSound;
    private AudioSource source;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("AudioSource").GetComponent<AudioSource>();
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
            source.PlayOneShot(deathSound,0.05f);
            // Update score
            int score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 10);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money + 1);
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
