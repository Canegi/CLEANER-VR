using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basuraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Basura")
        {
            Destroy(collision.gameObject); 
        }
    }
}
