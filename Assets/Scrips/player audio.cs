using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraudio : MonoBehaviour
{
    public AudioSource cSource;

    public AudioClip damage;
    public AudioClip jump;

 
    void Start()
    {

    }

    public void Damage()
    {
        cSource.PlayOneShot(damage);
    }

    public void Jump()
    {
        cSource.PlayOneShot(jump);
    }
}
