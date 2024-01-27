using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class background : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D objectCollider;
    public Vector2 cornerTL; //corner top left
    public Vector2 cornerBR; //corner bottom right
    void Start()
    {
        objectCollider = GetComponent<Collider2D>(); 
        cornerTL.x = objectCollider.bounds.center.x - objectCollider.bounds.size.x/2;
        cornerTL.y = objectCollider.bounds.center.y - objectCollider.bounds.size.y/2;
        cornerBR.x = objectCollider.bounds.center.x + objectCollider.bounds.size.x/2;
        cornerBR.y = objectCollider.bounds.center.y + objectCollider.bounds.size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
