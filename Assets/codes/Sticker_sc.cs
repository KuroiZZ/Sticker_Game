using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticker_sc : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IPointerClickHandler, IPointerUpHandler
{
    GameObject pivot;
    GameObject SizeButton;
    GameObject ResetButton;
    GameObject ReverseButton;
    Vector2 PivotStartPosition;
    bool isSticker_OutsideMenu;
    bool isPointer_OutsideSticker;
    bool Stickeble;
    bool onDrag;
    // Start is called before the first frame update
    internal void Start()
    {
        pivot = this.transform.parent.gameObject;

        SizeButton = this.transform.GetChild(0).gameObject;
        SizeButton.SetActive(false);

        ResetButton = this.transform.GetChild(1).gameObject;
        ResetButton.SetActive(false);

        ReverseButton = this.transform.GetChild(2).gameObject;
        ReverseButton.SetActive(false);

        PivotStartPosition = pivot.transform.position;

        isSticker_OutsideMenu = false;
        isPointer_OutsideSticker = true;
        Stickeble = false;
        onDrag = false;
    }

    // Update is called once per frame
    internal void Update()
    {
        if(Input.GetMouseButtonDown(0) && isPointer_OutsideSticker) 
        {
            DeactivateButtons();
        }
    }
    internal void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("menu"))
        {
            isSticker_OutsideMenu = false;
            Stickeble = false;
        } 
    }
    internal void OnCollisionStay2D(Collision2D collision)
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
    internal void OnCollisionExit2D(Collision2D collision)
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
            ActivateButtons();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Drag();
    }
    public void OnDrop(PointerEventData eventData)
    {
        onDrag = false;
        Drag_Back();
    }
    internal void Drag()
    {
        if(!SizeButton.activeInHierarchy)
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 pivotPosition;
            if(mousePosition != (Vector2)this.transform.position)
            {
                onDrag = true;
            }
            this.transform.position = mousePosition;
            pivotPosition.x = this.transform.position.x - GetComponent<RectTransform>().rect.width/2*pivot.transform.localScale.x;
            pivotPosition.y = this.transform.position.y + GetComponent<RectTransform>().rect.height/2*pivot.transform.localScale.y;
            pivot.transform.position = pivotPosition;
        }
    }
    internal void Drag_Back()
    {
        if(!Stickeble)
        {
            pivot.transform.position = PivotStartPosition; //Puts sticker back in the original place 
            ResetButton_sc.Reset_All(SizeButton,ResetButton,ReverseButton,pivot,this.gameObject); //Resets sticker 
            DeactivateButtons();
        }
    }
    internal void ActivateButtons()
    {
        if(Stickeble)
        {
            SizeButton.SetActive(true);
            ResetButton.SetActive(true);
            ReverseButton.SetActive(true);
        }
    }
    internal void DeactivateButtons()
    {
        SizeButton.SetActive(false);
        ResetButton.SetActive(false);
        ReverseButton.SetActive(false);
    }
}
