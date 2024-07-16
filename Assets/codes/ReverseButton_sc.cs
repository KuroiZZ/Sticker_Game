using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReverseButton_sc : MonoBehaviour, IPointerClickHandler
{
    GameObject Sticker;
    GameObject SizeButton;
    GameObject ResetButton;
    GameObject Rotate_Button;
    void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;

        SizeButton = Sticker.transform.GetChild(0).gameObject;

        ResetButton = Sticker.transform.GetChild(1).gameObject;

        Rotate_Button = Sticker.transform.GetChild(3).gameObject;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ReverseSticker(SizeButton,ResetButton,this.gameObject,Rotate_Button,Sticker);
    }
    internal static void ReverseSticker(GameObject sizeB, GameObject resetB, GameObject reverseB, GameObject rotateB, GameObject Sticker)
    {
        Vector2 SizeButton_Position = sizeB.transform.position; //We get buttons' first position to use it after reverse 
        Vector2 ResetButton_Position = resetB.transform.position;
        Vector2 ReverseButton_Position = reverseB.transform.position;
        Vector2 RotateButton_Position = rotateB.transform.position;

        if(Sticker.transform.rotation.eulerAngles.y == 180)
        {
            Sticker.transform.Rotate(0f, -180f, 0f); //sticker is reversed here
            Debug.Log(Sticker.transform.rotation.eulerAngles.y);

            sizeB.transform.Rotate(0f, -180f, 0f);  //Buttons are reversed back since they shouldn't be reversed.
            resetB.transform.Rotate(0f, -180f, 0f);//And we protected their image here
            reverseB.transform.Rotate(0f, -180f, 0f);
            rotateB.transform.Rotate(0f, -180f, 0f);
        }
        else
        {
            Sticker.transform.Rotate(0f, 180f, 0f); //sticker is reversed here

            sizeB.transform.Rotate(0f, 180f, 0f);  //Buttons are reversed back since they shouldn't be reversed.
            resetB.transform.Rotate(0f, 180f, 0f);//And we protected their image here
            reverseB.transform.Rotate(0f, 180f, 0f);
            rotateB.transform.Rotate(0f, 180f, 0f);
        }

        sizeB.transform.position = SizeButton_Position;//We use their first positions to make them stay in their place
        resetB.transform.position = ResetButton_Position;//So we protected their position here
        reverseB.transform.position = ReverseButton_Position;
        rotateB.transform.position = RotateButton_Position;
    }
}
