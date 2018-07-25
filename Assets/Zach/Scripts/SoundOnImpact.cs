using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnImpact : MonoBehaviour {

    public AudioSource myAudio;

    private void OnCollisionEnter(Collision collision)
    {
        myAudio.PlayOneShot(myAudio.clip);
    }
}
