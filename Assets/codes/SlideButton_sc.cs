using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideButton : MonoBehaviour, IPointerClickHandler
{
    GameObject Menu;

    Animator Menu_Animator;
    // Start is called before the first frame update
    void Start()
    {
        Menu = gameObject.transform.parent.gameObject;
        Menu_Animator = Menu.GetComponent<Animator>();   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool isShown = Menu_Animator.GetBool("isShown");
        
        Menu_Animator.SetBool("isShown", !isShown);
    }
}
