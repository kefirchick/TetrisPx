using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrapDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy blocks that flew out
        if (collision.tag == "Block") Destroy(collision.gameObject.transform.parent.gameObject);
        UILogic.instance.DownScore();
    }
}
