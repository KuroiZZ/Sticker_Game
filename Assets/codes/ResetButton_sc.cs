using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetButton_sc : MonoBehaviour, IPointerClickHandler
{
    GameObject Sticker;
    GameObject pivot;
    GameObject Size_Button;
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;
        Size_Button = Sticker.transform.GetChild(0).gameObject;
        pivot = Sticker.transform.parent.gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Reset_All(Size_Button,this.gameObject,pivot);
    }
    public static void Reset_All(GameObject sizeB, GameObject resetB, GameObject StickerParent)
    {
        StickerParent.transform.localScale = new Vector2(1,1);
        SizeButton_sc.Fix_Size(sizeB,resetB,StickerParent); 
    }
}