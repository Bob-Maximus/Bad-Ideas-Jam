using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public bool grounded;
    int groundedTimer;
    public GameObject landEffect;

    public AudioClip sound;

    void Update()
    {
        if (groundedTimer >= 2)
        {
            grounded = false;
        } else
        {
            grounded = true;
        }
        
        groundedTimer += 1;
    }

    private void OnTriggerStay2D(Collider2D col)
    {

        groundedTimer = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
            Instantiate(landEffect, gameObject.transform);
            transform.DetachChildren();
        }
    }
}
