using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Key3 : MonoBehaviour
{
    public bool isF;
    int a;
    int b;
    int c;
    public GameObject TextBox;
    public TextMeshProUGUI Text1;
    public string npcText1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        password();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isF = true;
        a = 0;
        b = 0;
        c = 0;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isF = false;
        TextBox.SetActive(false);
        a = 0;
        b = 0;
        c = 0;
    }

    void password()
    {
        if (isF & Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(true);
            Text1.text = npcText1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            a = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) & a == 1)
        {
            b = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7) & b == 1)
        {
            c = 1;
        }
        if (a == 1 & b == 1 & c == 1 & Input.GetKeyDown(KeyCode.F))
        {
            TextBox.SetActive(false);
            GameObject.Find("BookShelf").GetComponent<BookShelf3>().enabled = true;
            this.enabled = false;
        }
    }
}
