using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTheGameScript : MonoBehaviour
{
    public GameObject inicio, inicioesponja;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)        
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = inicio.transform.position;
        }
        if(other.gameObject.tag == "Esponja")
        {
            other.transform.position = inicioesponja.transform.position;
        }
        if (other.gameObject.tag == "Basura")
        {
            other.transform.position = inicioesponja.transform.position;
        }
    }
}
