using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casetoCode : MonoBehaviour
{
    public GameObject canvas2; // Reference to Canvas2
    private bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        if (canvas2 != null)
        {
            canvas2.SetActive(false); // Ensure Canvas2 is initially inactive
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.F))
        {
            if (canvas2 != null)
            {
                canvas2.SetActive(true); // Activate Canvas2 when F is pressed
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            canvas2.SetActive(false); // Deactivate Canvas2 when player exits trigger

        }
    }
}