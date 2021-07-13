using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{
    public GameObject figureC;
    public GameObject figureI;
    public GameObject figureZ1;
    public GameObject figureZ2;
    public GameObject figureL1;
    public GameObject figureL2;
    public GameObject figureT;
    
    public float spawnTime;
        
    private GameObject randomFigure;
    private GameObject figureOfColour;
    private GameObject blockOfColour;
    
    private float randomColour;

    private int randomFigureNumber;

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
        //Choose random figure type
        randomFigureNumber = Random.Range(0, 7);
        switch (randomFigureNumber)
        {
            case 0: 
                randomFigure = figureC;
                break;
            case 1:
                randomFigure = figureI;
                break;
            case 2:
                randomFigure = figureZ1;
                break;
            case 3:
                randomFigure = figureZ2;
                break;
            case 4:
                randomFigure = figureL1;
                break;
            case 5:
                randomFigure = figureL2;
                break;
            case 6:
                randomFigure = figureT;
                break;
        }
        figureOfColour = Instantiate(randomFigure, new Vector3(5, 20, 0), Quaternion.Euler(0, 0, 1));
        //Painting instanciated figure
        randomColour = Random.Range(0f, 1f);
        for (int i = 0; i < figureOfColour.transform.childCount; i++)
        {
            blockOfColour = figureOfColour.transform.GetChild(i).gameObject;
            blockOfColour.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(randomColour, 0.5f, 0.75f);
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
