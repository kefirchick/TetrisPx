using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    public GameObject go;
    public AudioSource chalkSound;

    public void Rotate()
    {
        chalkSound.Play();
        go.GetComponent<SpawnFigures>().Rotate();
    }
}
