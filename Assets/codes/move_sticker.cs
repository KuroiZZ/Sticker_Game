using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class move_sticker : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D objectCollider;
    Vector2 startPosition;
    Vector2 mousePosition;
    GameObject button;
    bool Stickeble;
    bool isOutside_Menu;
    bool isOutside_Sticker;
    bool isButtonActive;
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
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
        if(collision.gameObject.CompareTag("menu"))
        {
            isOutside_Menu = true;
        }
        if(collision.gameObject.CompareTag("menu"))
        {
            Stickeble = false;
        }
    }
    void OnMouseDrag()
    {
        Drag();
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
        DragBack();
        isOutside_Sticker = true;
    }
    // Update is called once per frame
    void Update()
    {
        Buttons_Off();
    }
    void Drag()
    {
        if(!button.activeInHierarchy)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePosition;
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
