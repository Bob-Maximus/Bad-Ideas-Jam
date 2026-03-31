using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BoxSound : MonoBehaviour
{
    public AudioClip sound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
