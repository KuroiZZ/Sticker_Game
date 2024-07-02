using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor.PackageManager.Requests;

public class RotateButton_sc : MonoBehaviour, IDragHandler
{
    GameObject Sticker;

    // Start is called before the first frame update
    public void Start()
    {
        Sticker = gameObject.transform.parent.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("a");
    }
}
