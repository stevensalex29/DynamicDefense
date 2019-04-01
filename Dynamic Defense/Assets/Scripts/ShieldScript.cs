using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private GameObject facingEnemy;
    public GameObject temp;
    float timer = 0;
    bool canPush = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit rayCast;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out rayCast))
        {
            Debug.Log("Hit");
            return rayCast.collider.gameObject;
        }
        else
        {
            return null;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        temp = GetMouseHoverObject(15);
        timer += Time.deltaTime;
        if (timer >= 5.00f)
        {
            canPush = true;
            timer = 0;
        }
        if (temp.gameObject.tag == "Enemy")
        {
            facingEnemy = temp;
            Debug.Log("Push");
            

            if (Input.GetMouseButton(1) && canPush)
            {
                push();
                canPush = false;
            }
        }
        
    }
    void push()
    {
        if(facingEnemy == null)
        {
            return;
        }
        Rigidbody rb = facingEnemy.GetComponent<Rigidbody>();
        if(rb!=null)
        {
            Vector3 pushVector = facingEnemy.transform.position;
            float speed = pushVector.magnitude / Time.deltaTime;
            Vector3 throwVelocity = speed * pushVector.normalized;

            throwVelocity += Camera.main.transform.forward * 10;

            rb.velocity = throwVelocity;
            rb.useGravity = true;
        }
        facingEnemy = null;
    }
}
