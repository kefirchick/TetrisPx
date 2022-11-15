using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject cursorPrefab;
    private GameObject cursorInstance;
    private Collider2D col;
 
    private TargetJoint2D targetJoint;
    
    private Vector2 mousePosition;
    
    private bool canMove;
    private bool isCursor;

    void Start() {
        col = GetComponent<BoxCollider2D>();
        if (col.enabled == false) col = GetComponent<CircleCollider2D>();
        targetJoint = GetComponent<TargetJoint2D>();
        canMove = false;
        isCursor = false;
    }

    void Update() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            if (col == Physics2D.OverlapPoint(mousePosition)) {
                canMove = true;
                targetJoint.enabled = true;
            } else {
                canMove = false;
                targetJoint.enabled = false;
            }
        }
        if (canMove) {
            targetJoint.target = mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            canMove = false;
            targetJoint.enabled = false;
        }
        cursorHandle(mousePosition);
    }

    void cursorHandle(Vector2 mousePosition) {
        if (canMove && !isCursor) {
            cursorInstance = Instantiate(cursorPrefab, mousePosition, Quaternion.identity);
            isCursor = true;
        }
        if (canMove && isCursor) {
            cursorInstance.transform.position = mousePosition;
            float xShift = mousePosition.x - transform.position.x;
            float yShift = mousePosition.y - transform.position.y;
            cursorInstance.transform.Rotate(0f, 0f, 2f + xShift * xShift + yShift * yShift, Space.Self);
        }
        if (!canMove && isCursor) {
            Destroy(cursorInstance);
            isCursor = false;
        }
    }
}
