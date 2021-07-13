using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource impact;

    private float soundVolume;

    // Start is called before the first frame update
    void OnCollisionEnter2D (Collision2D collision)
    {
        //Different collision sound depends on velocity with random pitch
        if (collision.relativeVelocity.magnitude > 3)
        {
            soundVolume = collision.relativeVelocity.magnitude / 40;
            if (soundVolume > 0.5f) soundVolume = 0.5f;
            GetComponent<AudioSource>().volume = soundVolume;
            GetComponent<AudioSource>().pitch = Random.Range(0.7f, 1.3f);
            impact.Play();
        }
    }
}
