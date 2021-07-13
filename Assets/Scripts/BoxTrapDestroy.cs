using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrapDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy blocks that flew out
        Debug.Log(collision.tag);
        if (collision.tag == "Block") Destroy(collision.gameObject);
        UILogic.instance.DownScore();
    }
}
