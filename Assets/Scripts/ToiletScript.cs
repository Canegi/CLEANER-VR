using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        float angleX = NormalizeAngle(transform.eulerAngles.x);

        if (angleX > -70)
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180)
            angle -= 360;
        return angle;
    }
}
