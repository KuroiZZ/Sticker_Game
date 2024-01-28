using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class move_sticker : MonoBehaviour
{
    // Start is called before the first frame update
    bool isDraggable;
    Collider2D objectCollider;
    background backG;
    Vector2 startPosition;
    bool Stickeble;
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
        Stickeble = false;
        startPosition = this.transform.position;
    }
    void OnCollisionEnter2D()
    {
        Stickeble = true;
    }
    void OnCollisionExit2D()
    {
        Stickeble = false;
    }
    // Update is called once per frame
    void Update()
    {
        Drag();
    }
    void Drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            if(objectCollider == Physics2D.OverlapPoint(mousePosition))
            {
                isDraggable = true;
            }
            else
            {
                isDraggable = false;
            }
        }
        if(isDraggable)
        {
            this.transform.position = mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isDraggable = false;
            DragBack();
        }
    }
    void DragBack()
    {
        if(!Stickeble)
        {
            this.transform.position = startPosition;
        }
    }
}
