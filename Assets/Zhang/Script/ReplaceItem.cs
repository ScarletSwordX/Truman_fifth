using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceItem : MonoBehaviour
{
    public GameObject replaced;
    
    public bool isF;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Switch1();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isF = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isF = false;
    }
    void Switch1()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            replaced.SetActive(true);
            gameObject.SetActive(false);
    }
    }
}