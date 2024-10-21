using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainScript : MonoBehaviour
{
    public bool grabing;
    private Vector3 initialPosition;
    public float returnSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        grabing = false;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(grabing == false)
        {
            if(transform.position.y > initialPosition.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
            }
            if (transform.position.y < initialPosition.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
            }
        }
    }

    public void grab()
    {
        grabing = true;
    }

    public void nograb()
    {
        grabing = false;
    }
}
