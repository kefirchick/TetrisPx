using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFigures : MonoBehaviour
{    
    public GameObject[] figures;
    public GameObject[] figureImages;
    public float spawnTime;
    public float lineLength;
    
    float blockSize;
    float screenWidth;
    GameObject figure;
    public GameObject nextFigure = null;
    float randomColour;
    int nextFigureNumb = -1;
    bool isSpawn = false;
    bool isSpeedIncrease = false;
    Vector3 scaleVector;
    public Quaternion nextFigureRot;
    public AudioSource spawnSound;

    void Start()
    {
        Invoke("Spawn", 0);
        isSpawn = true;
        screenWidth = 20f * ((float)Screen.width / (float)Screen.height);
        lineLength = PlayerPrefs.GetFloat("lengthPref", 7);
        blockSize = screenWidth / (lineLength + 0.2f);
        scaleVector = new Vector3(blockSize, blockSize, 0);

        GameObject.Find("BorderLeft").transform.localPosition = new Vector3(-1 - screenWidth / 2, -10, 0);
        GameObject.Find("BorderRight").transform.localPosition = new Vector3(1 + screenWidth / 2, -10, 0);
        GameObject.Find("TrapLeft").transform.position = new Vector3(4 - screenWidth / 2, 28, 0);
        GameObject.Find("TrapRight").transform.position = new Vector3(6 + screenWidth / 2, 28, 0);
    }

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
        GameObject block;

        if (nextFigureNumb >= 0) {
            // Instantiating figure
            spawnSound.Play();
            figure = Instantiate(figures[nextFigureNumb], new Vector3(5, 26, 0), nextFigureRot);
            figure.transform.localScale = scaleVector;

            //Painting instanciated figure
            randomColour = Random.Range(0f, 1f);
            for (int i = 0; i < figure.transform.childCount; i++)
            {
                block = figure.transform.GetChild(i).gameObject;
                block.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(randomColour, 0.7f, 1f);
            }
        }
        isSpawn = false; //To start a new spawn cycle
        createNextFigure();
        UILogic.instance.SetTimer(spawnTime);
    }

    void speedIncrease()
    {
        // Uncomment this for growing difficulty:
        // if (spawnTime > 0) spawnTime--;
        isSpeedIncrease = false;
    }

    void createNextFigure()
    {
        if (nextFigure) Destroy(nextFigure);
        switch (PlayerPrefs.GetFloat("shapePref", 0f)) {
            case 0:
                nextFigureNumb = Random.Range(0, figures.Length / 2);
                break;
            case 1:
                nextFigureNumb = Random.Range(0, figures.Length);
                break;
            case 2:
                nextFigureNumb = Random.Range(figures.Length / 2, figures.Length);
                break;
        }
        nextFigureRot = Quaternion.identity;
        nextFigure = Instantiate(figureImages[nextFigureNumb], new Vector3(7.7f, 15.7f, 0f), nextFigureRot);
    }

    public void Rotate()
    {
        nextFigureRot.eulerAngles -= new Vector3(0f, 0f, 90f);
        nextFigure.transform.eulerAngles = nextFigureRot.eulerAngles;
    }
}
