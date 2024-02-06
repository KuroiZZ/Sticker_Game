using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SizeButton_sc : MonoBehaviour, IDragHandler
{
    GameObject parent;
    GameObject parentsParent;
    Vector2 prevMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        parentsParent = parent.transform.parent.gameObject;
        prevMousePosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        ReSize_parent();
        Fix_Size();
    }
    void ReSize_parent()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 scale = parentsParent.transform.localScale;

        if((mousePosition.x > prevMousePosition.x && mousePosition.y < prevMousePosition.y) ||
        (mousePosition.x < prevMousePosition.x && mousePosition.y > prevMousePosition.y))
        {
            scale.x += (mousePosition.x - this.transform.position.x)*0.005f;
            scale.y += (mousePosition.x - this.transform.position.x)*0.005f;
        }
          
        parentsParent.transform.localScale = scale;
        prevMousePosition = mousePosition;
    }
    void Fix_Size()
    {
        float FixScale = 1; 
        this.transform.localScale = new Vector2(FixScale/parentsParent.transform.localScale.x,FixScale/parentsParent.transform.localScale.y);
    }
}
