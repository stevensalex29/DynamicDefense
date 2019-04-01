using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float shake_decay;
    float shake_intensity;
    Vector3 originPosition;
    Quaternion originRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
                            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);
            shake_intensity -= shake_decay;
        }
    }

    public void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = .1f;
        shake_decay = 0.002f;
    }
}
