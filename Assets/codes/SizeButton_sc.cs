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
    Vector2 prevMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;

        Reset_Button = Sticker.transform.GetChild(1).gameObject;

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
        Fix_Size(this.gameObject,Reset_Button,pivot);
    }
    void ReSize_Sticker()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 scale = pivot.transform.localScale;

        if((mousePosition.x > prevMousePosition.x && mousePosition.y < prevMousePosition.y) ||
        (mousePosition.x < prevMousePosition.x && mousePosition.y > prevMousePosition.y))
        {
            scale.x += (mousePosition.x - this.transform.position.x)*0.005f;
            scale.y += (mousePosition.x - this.transform.position.x)*0.005f;
        }
          
        pivot.transform.localScale = scale;
        prevMousePosition = mousePosition;
    }
    public static void Fix_Size(GameObject sizeB, GameObject resetB, GameObject StickerParent)
    {
        float FixScale = 1; 
        sizeB.transform.localScale = new Vector2(FixScale/StickerParent.transform.localScale.x,FixScale/StickerParent.transform.localScale.y);
        resetB.transform.localScale = new Vector2(FixScale/StickerParent.transform.localScale.x,FixScale/StickerParent.transform.localScale.y);
    }
}
