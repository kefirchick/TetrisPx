﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{    
    public GameObject[] figures;
    
    public float spawnTime;
        
    private GameObject figure;
    private GameObject block;
    
    private float randomColour;

    private bool isSpawn = false;
    private bool isSpeedIncrease = false;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn first figure
        Invoke("Spawn", 0);
        isSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn random figure in time interval
        if (isSpawn != true)
        {
            Invoke("Spawn", spawnTime);
            isSpawn = true;
        }

        //Increasing spawn speed
        if (isSpeedIncrease != true)
        {
            Invoke("speedIncrease", 30);
            isSpeedIncrease = true;
        }
    }

    //Spawn random figure in time interval
    void Spawn()
    {
        figure = Instantiate(figures[Random.Range(0, 7)], new Vector3(5, 20, 0), Quaternion.Euler(0, 0, 1));

        //Painting instanciated figure
        randomColour = Random.Range(0f, 1f);
        for (int i = 0; i < figure.transform.childCount; i++)
        {
            block = figure.transform.GetChild(i).gameObject;
            block.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(randomColour, 0.5f, 0.75f);
        }
        isSpawn = false; //To start a new spawn cycle
    }

    void speedIncrease()
    {
        //Increasing spawn speed
        if (spawnTime > 3) spawnTime--;
        isSpeedIncrease = false;
    }
}
