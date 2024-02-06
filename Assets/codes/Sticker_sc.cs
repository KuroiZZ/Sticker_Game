using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticker_sc : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IPointerClickHandler, IPointerUpHandler
{
    GameObject pivot;
    GameObject sizeButton;
    //Vector2 startPosition;
    Vector2 startPivotPosition;
    bool isSticker_OutsideMenu;
    bool isPointer_OutsideSticker;
    bool Stickeble;
    bool onDrag;
    // Start is called before the first frame update
    void Start()
    {
        pivot = gameObject.transform.parent.gameObject;
        sizeButton = gameObject.transform.GetChild(0).gameObject;
        sizeButton.SetActive(false);

        //startPosition = this.transform.position;
        startPivotPosition = pivot.transform.position;

        isSticker_OutsideMenu = false;
        isPointer_OutsideSticker = true;
        Stickeble = false;
        onDrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        Set_sizeButton_Deactive();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("menu"))
        {
            isSticker_OutsideMenu = false;
            Stickeble = false;
        } 
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("paper")&&isSticker_OutsideMenu)
        {
            Stickeble = true;
        }
        if(collision.gameObject.CompareTag("menu"))
        {
            isSticker_OutsideMenu = false;
        }  
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("menu"))
        {
            isSticker_OutsideMenu = true;
        }
        if(collision.gameObject.CompareTag("menu"))
        {
            Stickeble = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointer_OutsideSticker = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointer_OutsideSticker = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!onDrag)
        {
            Set_sizeButton_Active();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Drag();
    }
    public void OnDrop(PointerEventData eventData)
    {
        onDrag = false;
        ReturnToStart();
    }
    void Drag()
    {
        if(!sizeButton.activeInHierarchy)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 pivotPosition;
            if(mousePosition != (Vector2)this.transform.position)
            {
                onDrag = true;
            }
            this.transform.position = mousePosition;
            pivotPosition.x = this.transform.position.x - GetComponent<RectTransform>().rect.width/2;
            pivotPosition.y = this.transform.position.y + GetComponent<RectTransform>().rect.height/2;
            pivot.transform.position = pivotPosition;
        }
    }
    void ReturnToStart()
    {
        if(!Stickeble)
        {
            //this.transform.position = startPosition;
            pivot.transform.position = startPivotPosition;
        }
    }
    void Set_sizeButton_Active()
    {
        if(Stickeble)
        {
            sizeButton.SetActive(true);
        }
    }
    void Set_sizeButton_Deactive()
    {
        if(Input.GetMouseButtonDown(0) && isPointer_OutsideSticker)
        {
            sizeButton.SetActive(false);
        }
    }
}
