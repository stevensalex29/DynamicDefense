using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShieldScript : MonoBehaviour
{
    private GameObject facingEnemy;
    public GameObject temp;
    float timer = 0;
    bool canPush = true;
    private float percent;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3.0f;
    }
    

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit rayCast;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out rayCast))
        {
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
        temp = GetMouseHoverObject(10);
        timer += Time.deltaTime;
        percent = timer / 3.00f;
        GameObject.Find("PushCooldown").GetComponent<Image>().fillAmount = percent;
        if (timer >= 3.00f)
        {
            timer = 3.00f;
            canPush = true;
            
        }
        if(temp != null)
        {
            if (temp.gameObject.tag == "Enemy")
            {
                facingEnemy = temp;

                if (Input.GetMouseButton(1) && canPush)
                {
                    push();
                    canPush = false;
                    timer = 0;
                }
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
            float speed = 15 / Time.deltaTime;
            Vector3 throwVelocity = speed * pushVector.normalized;

            throwVelocity += Camera.main.transform.forward * 10;

            //rb.velocity = throwVelocity;
            rb.AddForce(throwVelocity);
            rb.useGravity = true;
        }
        /*
        else
        {
            Vector3 pushVector = facingEnemy.transform.position;
            float speed = Time.deltaTime;
            Vector3 throwVelocity = speed * pushVector.normalized;
            throwVelocity += Camera.main.transform.forward * 13;
            facingEnemy.gameObject.transform.Translate(throwVelocity);
        }
        */
        facingEnemy = null;
    }
}
