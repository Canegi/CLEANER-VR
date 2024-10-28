using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeakerScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] cancion1, cancion2, cancion3; // Cambiar a AudioClip
    private int currentSongIndex = -1; // Para llevar el control de la canci�n actual

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StopAudio(); // Asegurarse de que no se reproduzca nada al inicio
    }

    void Update()
    {
        // Reproduce la canci�n actual si no est� reproduci�ndose
        if (currentSongIndex != -1 && !audioSource.isPlaying)
        {
            PlayCurrentSong();
        }
    }

    public void Speaker()
    {
        currentSongIndex++; // Cambia a la siguiente canci�n
        if (currentSongIndex > 2) // Reinicia si superamos el n�mero de canciones
        {
            StopAudio();
        }
        else
        {
            PlayCurrentSong();
        }
    }

    private void PlayCurrentSong()
    {
        switch (currentSongIndex)
        {
            case 0:
                audioSource.clip = cancion1[0]; // Cambia a la canci�n 1 (puedes elegir el �ndice)
                break;
            case 1:
                audioSource.clip = cancion2[0]; // Cambia a la canci�n 2 (puedes elegir el �ndice)
                break;
            case 2:
                audioSource.clip = cancion3[0]; // Cambia a la canci�n 3 (puedes elegir el �ndice)
                break;
        }
        audioSource.Play(); // Reproduce la canci�n seleccionada
    }

    private void StopAudio()
    {
        audioSource.Stop();
        currentSongIndex = -1; // Reinicia el �ndice
    }
}
