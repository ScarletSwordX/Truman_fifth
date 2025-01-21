using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene2BA : MonoBehaviour
{
    public bool isF;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Switch();
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
    void Switch()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            GameObject go = GameObject.FindWithTag("Door3");
            go.transform.position = new Vector3(78, 1, 0);
            transform.position = new Vector3(129, 1, 0);
        }
    }
}