using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    public GameObject go;

    public void Rotate()
    {    
        go.GetComponent<SpawnFigures>().Rotate();
    }
}
