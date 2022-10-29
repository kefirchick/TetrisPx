using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEraseLogic : MonoBehaviour
{
    public GameObject[] arrayOfBlocks;
    public AudioSource eraseSound;
    public ParticleSystem explosion;
    public float lineLength;

    private float blockSize;
    private float lowestLevel;
    private ParticleSystem thisExplosion;
    private Color blockColor;
    private float checkY;
    private float lineLuft;
    private int lineCount;
    
    // Start is called before the first frame update
    void Start()
    {
        blockSize = 10 / lineLength;
        lineLuft = 0.2f;
        lowestLevel = 0.5f - 26f / blockSize;
        // Debug.Log($"{blockSize} {lineLuft} {lowestLevel}");
    }
    // Update is called once per frame
    void Update()
    {
        arrayOfBlocks = GameObject.FindGameObjectsWithTag("Block");
        for (float y = lowestLevel; y < 0f; y += 0.1f)
        {
            lineCount = 0;
            foreach (GameObject countBlocks in arrayOfBlocks)
            {
                checkY = countBlocks.transform.localPosition.y;
                if ((checkY > y - lineLuft) && (checkY < y + lineLuft))
                {
                    lineCount++;
                }
            }
            if (lineCount >= lineLength)
            {
                eraseLine(y);
            }
            if (lineCount > 0) Debug.Log($"{lineCount}");
        }
    }

    void eraseLine(float y) {
        this.GetComponent<AudioSource>().pitch = Random.Range(0.7f, 1.4f);
        eraseSound.Play();
        foreach (GameObject destroyBlocks in arrayOfBlocks)
        {
            checkY = destroyBlocks.transform.localPosition.y;
            if ((checkY > y - lineLuft) && (checkY < y + lineLuft))
            {
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
}
