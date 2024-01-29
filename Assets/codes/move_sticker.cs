using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class move_sticker : MonoBehaviour
{
    // Start is called before the first frame update
    bool isDraggable;
    public Collider2D objectCollider;
    Vector2 startPosition;
    GameObject button;
    bool Stickeble;
    bool isOutside_Menu;
    bool isOutside_Sticker;
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        isDraggable = false;
        Stickeble = false;
        isOutside_Menu = false;
        startPosition = this.transform.position;
        button = gameObject.transform.GetChild(0).gameObject;
        button.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("menu"))
        {
            isOutside_Menu = false;
            Stickeble = false;
        } 
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("paper")&&isOutside_Menu)
        {
            Stickeble = true;
        }
        if(collision.gameObject.CompareTag("menu"))
        {
            isOutside_Menu = false;
        }  
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Stickeble = false;
        if(collision.gameObject.CompareTag("menu"))
        {
            isOutside_Menu = true;
        }
    }
    void OnMouseDown()
    {
        isOutside_Sticker = false;
        if(Stickeble)
        {
            button.SetActive(true);
        }
    }
    void OnMouseUp()
    {
        isOutside_Sticker = true;
    }
    // Update is called once per frame
    void Update()
    {
        Drag();
        Buttons_Off();
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
    void Buttons_Off()
    {
        if(Input.GetMouseButtonDown(0) && isOutside_Sticker)
        {
            button.SetActive(false);
        }
    }
}
