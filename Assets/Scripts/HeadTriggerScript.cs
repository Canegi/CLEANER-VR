using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTriggerScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip introaudio, ring, finalaudio; 
    public GameObject pomo1, pomo2;
    private Collider objetoCollider1, objetoCollider2;
    public bool intro, final;
    public int limpio;

    // Start is called before the first frame update
    void Start()
    {
        objetoCollider1 = pomo1.GetComponent<Collider>();
        objetoCollider2 = pomo2.GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
        limpio = 0;
        intro = false;
        final = false;
        audioSource.loop = true;
        audioSource.clip = ring;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(limpio == 37)
        {
            final = true;
            audioSource.loop = true;
            audioSource.clip = ring;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "MOVIL" && !intro)
        {
            audioSource.loop = false;
            intro = true;
            audioSource.PlayOneShot(introaudio);
            objetoCollider1.enabled = true;
            objetoCollider2.enabled = true;
        }

        if (other.gameObject.name == "MOVIL" && final)
        {
            audioSource.PlayOneShot(finalaudio);
        }
    }

}
