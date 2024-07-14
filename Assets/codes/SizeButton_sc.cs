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
    Vector3 startScale;
    float startDistance;
    Vector3 StickerPosition;
    Vector2 buttonPosition;
    // Start is called before the first frame update
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;
        startScale = Sticker.transform.localScale;
        
        StickerPosition = Sticker.transform.position;
        buttonPosition = this.transform.position;
        startDistance = Vector2.Distance(StickerPosition,buttonPosition);

        Reset_Button = Sticker.transform.GetChild(1).gameObject;

        Reverse_Button = Sticker.transform.GetChild(2).gameObject;

        Rotate_Button = Sticker.transform.GetChild(3).gameObject;

        pivot = Sticker.transform.parent.gameObject;
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
        
        Vector2 Mouse_Position = Input.mousePosition;
        Vector2 SizeButton_Position = this.transform.position;
        Vector2 StickerScale = Sticker.transform.localScale;
        Vector2 ReverseButton_Position = Reverse_Button.transform.position;
        
        //Calculating the distance between mouse and stickers center so we can also calculate the new size scale 
        float endDistance = Vector2.Distance(Mouse_Position, StickerPosition); 
        float new_scale = endDistance / startDistance;

        //With StickerScale.x comparations we determine pivots max and min size
        //With (StickerScale.x < new_scale) comparations we determine if sticker is going to get larger or get smaller 
        if((StickerScale.x >= 2f) && (StickerScale.x < new_scale))
        {
            StickerScale.x = 2;
            StickerScale.y = 2;
            Sticker.transform.localScale = StickerScale;
        }
        else if((StickerScale.x <= 0.5f) && (StickerScale.x > new_scale))
        {
            StickerScale.x = 0.5f;
            StickerScale.y = 0.5f;
            Sticker.transform.localScale = StickerScale;
        }
        else
        {
            //(Mouse_Position - ReverseButton_Position).magnitude is the distance between top left corner of sticker and mouse
            //(Mouse_Position - SizeButton_Position).magnitude is the distance between bottom right corner of sticket and mouse 
            //cornerDetector is positive if mouse is closer to bottom right corner and negative if mouse is closer to top left corner 
            float cornerDetector = (Mouse_Position - ReverseButton_Position).magnitude - (Mouse_Position - SizeButton_Position).magnitude;
            if( ((StickerScale.x < new_scale) && (cornerDetector > 0)) || (StickerScale.x > new_scale))
            {
                Sticker.transform.localScale = startScale * new_scale;
            }
           
        }

        //pivot.transform.localScale = scale;
        
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
