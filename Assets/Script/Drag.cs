using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 depth;
    private Vector3 offset;
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
        OnMouseDrag();
    }

    private void OnMouseDown()
    {
        depth = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, depth.z);
        offset=transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0)&offset.x<0.3&offset.y<0.3)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, depth.z);
            transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}
