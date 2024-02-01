using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SizeButton_sc : MonoBehaviour, IDragHandler
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        ReSize_parent();
    }
    void ReSize_parent()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector3 temp  = parent.transform.localScale;

        if(mousePosition.x > this.transform.position.x)
        {
            temp.x += 0.03f;
        }
        else if(mousePosition.x < this.transform.position.x)
        {
            temp.x -= 0.03f;
        }

        if(mousePosition.y < this.transform.position.y)
        {
            temp.y += 0.03f;
        }
        else if(mousePosition.y > this.transform.position.y)
        {
            temp.y -= 0.03f;
        }

        parent.transform.localScale = temp;
    }
}
