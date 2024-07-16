using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor.PackageManager.Requests;

public class RotateButton_sc : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Vector3 mouse_pos;
    public Transform target;
    private Vector3 object_pos;
    private float angle;
    private float offset_angle;
    private float StickerRotationY;
    private float StickerRotationX;
    GameObject Sticker;
    // Start is called before the first frame update
    public void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;
        float tan_x = this.gameObject.transform.position.x - Sticker.transform.position.x;
        float tan_y = this.gameObject.transform.position.y - Sticker.transform.position.y;
        offset_angle = (Mathf.Atan2(tan_y, tan_x) * Mathf.Rad2Deg);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        StickerRotationY = Sticker.transform.rotation.eulerAngles.y;
        StickerRotationX = Sticker.transform.rotation.eulerAngles.x;
    }

    public void OnDrag(PointerEventData eventData)
    {
        mouse_pos = Input.mousePosition;
        float tan_x = mouse_pos.x - Sticker.transform.position.x;
        float tan_y = mouse_pos.y - Sticker.transform.position.y;
        angle = (Mathf.Atan2(tan_y, tan_x) * Mathf.Rad2Deg) - offset_angle;
        if(StickerRotationY == 180) //if sticker is reversed
        {
            Sticker.transform.rotation = Quaternion.Euler(StickerRotationX, StickerRotationY, -angle);
        }
        else //if sticker is not reversed
        {
            Sticker.transform.rotation = Quaternion.Euler(StickerRotationX, StickerRotationY, angle);
        }
    }
}
