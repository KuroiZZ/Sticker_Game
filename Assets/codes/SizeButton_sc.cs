using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor.PackageManager.Requests;

public class SizeButton_sc : MonoBehaviour, IDragHandler
{
    GameObject Sticker;
    GameObject pivot;
    GameObject Reset_Button;
    GameObject Reverse_Button;
    GameObject Rotate_Button;
    Vector2 prevMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;

        Reset_Button = Sticker.transform.GetChild(1).gameObject;

        Reverse_Button = Sticker.transform.GetChild(2).gameObject;

        Rotate_Button = Sticker.transform.GetChild(3).gameObject;

        pivot = Sticker.transform.parent.gameObject;

        prevMousePosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        ReSize_Sticker();
        Fix_Size(this.gameObject,Reset_Button,Reverse_Button,Rotate_Button,pivot);
    }
    void ReSize_Sticker()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 scale = pivot.transform.localScale;
        //With scale.x comparations we determine pivots max and min size
        //With (mousePosition.x - this.transform.position.x) comparations we determine if pivot is going to get larger or get smaller 
        if((scale.x >= 2 && (mousePosition.x - this.transform.position.x) > 0) || (scale.x <= 0.5 && (mousePosition.x - this.transform.position.x) < 0))
        {
            scale = pivot.transform.localScale;
        }
        else
        {
            scale.x += (mousePosition.x - this.transform.position.x)*0.005f;
            scale.y += (mousePosition.x - this.transform.position.x)*0.005f;
        }

          
        pivot.transform.localScale = scale;
        prevMousePosition = mousePosition;
    }
    public static void Fix_Size(GameObject sizeB, GameObject resetB, GameObject reverseB, GameObject rotateB, GameObject StickerParent)
    {
        //This function keeps the little buttons' size fixed.
        float FixScale = 1; 
        sizeB.transform.localScale = new Vector2(FixScale/StickerParent.transform.localScale.x,FixScale/StickerParent.transform.localScale.y);
        resetB.transform.localScale = new Vector2(FixScale/StickerParent.transform.localScale.x,FixScale/StickerParent.transform.localScale.y);
        reverseB.transform.localScale = new Vector2(FixScale/StickerParent.transform.localScale.x,FixScale/StickerParent.transform.localScale.y);
        rotateB.transform.localScale = new Vector2(FixScale/StickerParent.transform.localScale.x,FixScale/StickerParent.transform.localScale.y);
    }
}
