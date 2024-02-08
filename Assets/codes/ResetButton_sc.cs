using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetButton_sc : MonoBehaviour, IPointerClickHandler
{
    GameObject Sticker;
    GameObject pivot;
    GameObject Size_Button;
    GameObject Reverse_Button;
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;
        Size_Button = Sticker.transform.GetChild(0).gameObject;
        Reverse_Button = Sticker.transform.GetChild(2).gameObject;
        pivot = Sticker.transform.parent.gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Reset_All(Size_Button,this.gameObject,Reverse_Button,pivot,Sticker);
    }
    public static void Reset_All(GameObject sizeB, GameObject resetB, GameObject reverseB,GameObject StickerParent, GameObject Sticker)
    {
        StickerParent.transform.localScale = new Vector2(1,1);

        SizeButton_sc.Fix_Size(sizeB,resetB,reverseB,StickerParent);

        if(Sticker.transform.localRotation.y == -180 || Sticker.transform.localRotation.y == 180)
        {
            ReverseButton_sc.ReverseSticker(sizeB,resetB,reverseB,Sticker);
        }
    }
}