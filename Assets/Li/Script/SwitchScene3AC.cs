using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene3AC : MonoBehaviour
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
            GameObject go = GameObject.Find("Door5");
            go.transform.position = new Vector3(71, 1, 0);
            transform.position = new Vector3(27, 35, 0);
        }
    }
}
