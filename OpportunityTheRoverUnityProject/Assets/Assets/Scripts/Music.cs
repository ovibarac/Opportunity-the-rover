using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource muzica;

    void Start()
    {
        muzica = GetComponent<AudioSource>();
        muzica.Play();
    }
}
