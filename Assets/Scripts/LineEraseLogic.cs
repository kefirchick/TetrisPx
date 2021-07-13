using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEraseLogic : MonoBehaviour
{
    public GameObject[] arrayOfBlocks;

    public AudioSource eraseSound;

    public ParticleSystem explosion;

    private ParticleSystem thisExplosion;

    private Color blockColor;

    private float checkY;
    private float lineLuft = 0.3f;
    
    private int lineCount;
    
    // Update is called once per frame
    void Update()
    {
        // Erase compleated lines
        arrayOfBlocks = GameObject.FindGameObjectsWithTag("Block");
        for (float y = -19.5f; y < 0f; y++)
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
            if (lineCount > 9)
            {
                this.GetComponent<AudioSource>().pitch = Random.Range(0.7f, 1.4f);
                eraseSound.Play();
                foreach (GameObject destroyBlocks in arrayOfBlocks)
                {
                    checkY = destroyBlocks.transform.localPosition.y;
                    if ((checkY > y - lineLuft) && (checkY < y + lineLuft))
                    {
                        blockColor = destroyBlocks.GetComponent<SpriteRenderer>().color;
                        thisExplosion = Instantiate(explosion, destroyBlocks.transform.position, Quaternion.identity);
                        var main = thisExplosion.main;
                        main.startColor = blockColor;
                        Destroy(destroyBlocks);
                        UILogic.instance.UpScore();
                    }
                }
            }
        }
    }
}
