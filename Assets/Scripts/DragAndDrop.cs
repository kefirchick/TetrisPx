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
    public AudioSource dragSound;

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
            if (col && col == Physics2D.OverlapPoint(mousePosition)) {
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
        } else if (canMove && isCursor) {
            cursorInstance.transform.position = mousePosition;
            float xShift = mousePosition.x - transform.position.x;
            float yShift = mousePosition.y - transform.position.y;
            float shift =  xShift * xShift + yShift * yShift;
            cursorInstance.transform.Rotate(0f, 0f, 2f + shift, Space.Self);
            dragSoundPlay(shift);
        } else {
            Destroy(cursorInstance);
            isCursor = false;
        }
    }

    void dragSoundPlay(float shift) {
        if (!dragSound.isPlaying) {
            shift = (shift > 100f) ? 1.5f : 0.5f + shift / 100f;
            Debug.Log(shift);
            dragSound.pitch = shift;
            dragSound.Play();
        }
    }
}