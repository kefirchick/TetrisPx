using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEraseLogic : MonoBehaviour
{
    public GameObject[] arrayOfBlocks;
    public GameObject[] arrayOfFigures;
    public ParticleSystem explosion;
    public float lineLength;

    private float blockSize;
    private float lowestLevel;
    private ParticleSystem thisExplosion;
    private Color blockColor;
    private float checkY;
    private float lineLuft;
    private int lineCount;
    public AudioSource eraseSound;

    void Start()
    {
        lineLuft = 0.2f;
        lowestLevel = 0f;
        lineLength = PlayerPrefs.GetFloat("lengthPref", 7);
    }
    void Update()
    {
        garbageHandle();
        arrayOfBlocks = GameObject.FindGameObjectsWithTag("Block");
        for (float y = lowestLevel; y < 20f; y += 0.1f)
        {
            lineCount = 0;
            foreach (GameObject countBlocks in arrayOfBlocks)
            {
                checkY = countBlocks.transform.position.y;
                if ((checkY > y - lineLuft) && (checkY < y + lineLuft))
                {
                    lineCount++;
                }
            }
            if (lineCount >= lineLength)
            {
                StartCoroutine(eraseLine(y));
            }
        }
    }

    IEnumerator eraseLine(float y)
    {
        if (!eraseSound.isPlaying)
        {
            eraseSound.pitch = Random.Range(0.8f, 1.2f);
            eraseSound.Play();
        }
        foreach (GameObject destroyBlocks in arrayOfBlocks)
        {
            checkY = destroyBlocks.transform.position.y;
            if ((checkY > y - lineLuft) && (checkY < y + lineLuft))
            {
                yield return new WaitForSeconds(0.05f);
                eraseBlock(destroyBlocks);
            }
        }
    }

    void eraseBlock(GameObject destroyBlocks)
    {
        blockColor = destroyBlocks.GetComponent<SpriteRenderer>().color;
        thisExplosion = Instantiate(explosion, destroyBlocks.transform.position, Quaternion.identity);
        var main = thisExplosion.main;
        main.startColor = blockColor;
        Destroy(destroyBlocks);
        UILogic.instance.UpScore();
    }

    void garbageHandle()
    {
        arrayOfFigures = GameObject.FindGameObjectsWithTag("Figure");
        foreach (GameObject figure in arrayOfFigures)
        {
            if (figure.transform.childCount == 0) Destroy(figure);
        }
    }
}