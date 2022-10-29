using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Collider2D col;
 
    private TargetJoint2D targetJoint;
    
    private Vector2 mousePosition;
    
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        if (col.enabled == false) col = GetComponent<CircleCollider2D>();
        targetJoint = GetComponent<TargetJoint2D>();
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Get mouse position
        //Allow moving then click on block
        if (Input.GetMouseButtonDown(0))
        {
            if (col == Physics2D.OverlapPoint(mousePosition))
            {
                canMove = true;
                targetJoint.enabled = true;
            }
            else
            {
                canMove = false;
                targetJoint.enabled = false;
            }
        }
        //Moving target of joint component of this block
        if (canMove == true)
        {
            targetJoint.target = mousePosition;
        }
        //Drop the block on button up
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            targetJoint.enabled = false;
        }
    }
}
