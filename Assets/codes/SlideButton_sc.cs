using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideButton_sc : MonoBehaviour, IPointerClickHandler
{
    GameObject Canvas;
    GameObject Menu;
    GameObject Paper;
    GameObject Arrow;
    Animator Menu_Animator;
    Animator Paper_Animator;
    Animator Arrow_Animator;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = gameObject.transform.parent.parent.gameObject;
        Paper = Canvas.transform.GetChild(0).gameObject;
        Menu = Canvas.transform.GetChild(1).gameObject;
        Arrow = this.transform.GetChild(0).gameObject;
        Menu_Animator = Menu.GetComponent<Animator>();   
        Paper_Animator = Paper.GetComponent<Animator>();
        Arrow_Animator = Arrow.GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool isShown = Menu_Animator.GetBool("isShown");

        bool isSmalled = Paper_Animator.GetBool("isSmalled");

        bool isTurned = Arrow_Animator.GetBool("IsTurned");
        
        Menu_Animator.SetBool("isShown", !isShown); 
        Paper_Animator.SetBool("isSmalled", !isSmalled);
        Arrow_Animator.SetBool("IsTurned",!isTurned);
    }
}
