using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ResetButton_sc : MonoBehaviour, IPointerClickHandler
{
    GameObject Sticker;
    GameObject Size_Button;
    GameObject Reverse_Button;
    GameObject Rotate_Button;
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;
        Size_Button = Sticker.transform.GetChild(0).gameObject;
        Reverse_Button = Sticker.transform.GetChild(2).gameObject;
        Rotate_Button = Sticker.transform.GetChild(3).gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Reset_All(Size_Button,this.gameObject,Reverse_Button,Rotate_Button,Sticker);
    }
    public static void Reset_All(GameObject sizeB, GameObject resetB, GameObject reverseB, GameObject rotateB, GameObject Sticker)
    {
        Sticker.transform.localScale = new Vector2(1, 1); //resets stickers size

        SizeButton_sc.Fix_Size(sizeB,resetB,reverseB,rotateB,Sticker); //resets buttons size 

        if(Sticker.transform.rotation.eulerAngles.y == 180) //resets stickers reverse
        {
            ReverseButton_sc.ReverseSticker(sizeB,resetB,reverseB,rotateB,Sticker);
        }
        Sticker.transform.rotation = Quaternion.Euler(0f, 0f, 0f); //resets stickers rotation 
    }
}