using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticker_buttons : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D objectCollider;
    move_sticker sticker;
    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Disappear_Appear();
    }
    void Disappear_Appear()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            if(sticker.objectCollider == Physics2D.OverlapPoint(mousePosition))
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
