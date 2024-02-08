using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReverseButton_sc : MonoBehaviour, IPointerClickHandler
{
    GameObject Sticker;
    GameObject SizeButton;
    GameObject ResetButton;
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;

        SizeButton = Sticker.transform.GetChild(0).gameObject;

        ResetButton = Sticker.transform.GetChild(1).gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ReverseSticker(SizeButton,ResetButton,this.gameObject,Sticker);
    }
    internal static void ReverseSticker(GameObject sizeB, GameObject resetB, GameObject reverseB,GameObject Sticker)
    {
        Vector2 SizeButton_Position = sizeB.transform.position;
        Vector2 ResetButton_Position = resetB.transform.position;
        Vector2 ReverseButton_Position = reverseB.transform.position;

        Sticker.transform.Rotate(0f, 180f, 0f);

        sizeB.transform.position = SizeButton_Position;
        resetB.transform.position = ResetButton_Position;
        reverseB.transform.position = ReverseButton_Position;

        sizeB.transform.Rotate(0f, 180f, 0f);
        resetB.transform.Rotate(0f, 180f, 0f);
        reverseB.transform.Rotate(0f, 180f, 0f);
    }
}
