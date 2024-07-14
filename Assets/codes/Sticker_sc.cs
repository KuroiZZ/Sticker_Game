using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sticker_sc : MonoBehaviour, IPointerDownHandler, IDragHandler, IDropHandler, IPointerClickHandler, IPointerUpHandler
{

    GameObject SizeButton;
    GameObject ResetButton;
    GameObject ReverseButton;
    GameObject RotateButton;
    Vector2 StickerStartPosition;
    bool isSticker_OutsideMenu;
    bool isPointer_OutsideSticker;
    bool Stickeble;
    bool isStickerOnDrag;
    bool areButtonsActive;
    // Start is called before the first frame update
    internal void Start()
    {
        SizeButton = this.transform.GetChild(0).gameObject;
        SizeButton.SetActive(false);

        ResetButton = this.transform.GetChild(1).gameObject;
        ResetButton.SetActive(false);

        ReverseButton = this.transform.GetChild(2).gameObject;
        ReverseButton.SetActive(false);

        RotateButton = this.transform.GetChild(3).gameObject;
        RotateButton.SetActive(false);

        isSticker_OutsideMenu = false;
        isPointer_OutsideSticker = true;
        Stickeble = false;
        isStickerOnDrag = false;
        areButtonsActive = false;

        StickerStartPosition = this.transform.position;
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
        if(collision.gameObject.CompareTag("menu")) //if sticker is starting to collision with "menu" 
        {
            isSticker_OutsideMenu = false;
            Stickeble = false;
        } 
    }
    internal void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("paper")&&isSticker_OutsideMenu) //while sticker collisions with "paper" and sticker is outside of menu 
        {
            Stickeble = true;
        }
        if(collision.gameObject.CompareTag("menu")) //while sticker collisions with "menu"
        {
            isSticker_OutsideMenu = false;
        }  
    }
    internal void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("menu")) //if sticker is ending the collision with "menu"
        {
            isSticker_OutsideMenu = true;
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
        if(!isStickerOnDrag)
        {
            ActivateButtons();
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        DragSticker();
    }
    public void OnDrop(PointerEventData eventData)
    {
        isStickerOnDrag = false;
        DragBackSticker();
    }
    
    internal void DragSticker()
    {
        if(!areButtonsActive) 
        {
            Vector2 mousePosition = Input.mousePosition;
            if(mousePosition != (Vector2)this.transform.position)
            {
                isStickerOnDrag = true;
            }
            this.transform.position = mousePosition; //sticker is moved to mouse position
        }
    }
    internal void DragBackSticker()
    {
        if(!Stickeble)
        {
            this.transform.position = StickerStartPosition; //Puts sticker back in the original place 
            ResetButton_sc.Reset_All(SizeButton,ResetButton,ReverseButton,RotateButton,this.gameObject); //Resets sticker 
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
            RotateButton.SetActive(true);
            areButtonsActive = true;
        }
    }
    internal void DeactivateButtons()
    {
        SizeButton.SetActive(false);
        ResetButton.SetActive(false);
        ReverseButton.SetActive(false);
        RotateButton.SetActive(false);
        areButtonsActive = false;
    }
}
