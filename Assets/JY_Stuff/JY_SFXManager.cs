using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JY_SFXManager : MonoBehaviour
{
    public AudioClip[] sfx;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void playSound(int i)
    {
        aud.PlayOneShot(sfx[i]);
    }
}
